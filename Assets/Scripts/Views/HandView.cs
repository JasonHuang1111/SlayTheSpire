using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Splines;

/// <summary>
/// 手牌视图
/// </summary>
public class HandView : MonoBehaviour
{
    [SerializeField]
    //样条线容器
    private SplineContainer splineContainer;

    /// <summary>
    /// 手牌最大数量
    /// </summary>
    public int maxHandCount = 10;

    /// <summary>
    /// 当前拥有的所有手牌的列表
    /// </summary>
    private readonly List<CardView> handCards = new();

    /// <summary>
    /// 创建卡牌后将卡牌添加到手牌当中
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    public IEnumerator AddCard(CardView card)
    {
        handCards.Add(card);
        yield return UpdateCardPositions(0.15f);
    }

    /// <summary>
    /// 更新手牌的位置，使其在样条曲线上居中排列并带有动画
    /// </summary>
    private IEnumerator UpdateCardPositions(float duration)
    {
        if (handCards.Count == 0) yield break;

        //计算每张卡牌之间的间距
        float caradSpacing = 1f / maxHandCount;

        // 计算第一个卡牌在曲线上的起始位置，并使得后续卡牌以0.5为中心居中排列
        float firstCardPosition = 0.5f - (handCards.Count - 1) * caradSpacing / 2;

        Spline spline = splineContainer.Spline;
        for (int i = 0; i < handCards.Count; i++)
        {
            //计算当前卡牌的位置
            float position = firstCardPosition + i * caradSpacing;

            //计算位置在样条曲线上的位置
            Vector3 splinePositon = spline.EvaluatePosition(position);
            //计算角度
            Vector3 forward = spline.EvaluateTangent(position);
            Vector3 up = spline.EvaluateUpVector(position);
            Quaternion rotation = Quaternion.LookRotation(-up, Vector3.Cross(-up, forward).normalized);

            //将卡牌移动到目标位置,并加上一点点偏移量避免卡牌之间出现重叠
            handCards[i].transform.DOMove(splinePositon + transform.position + 0.01f * i * Vector3.back, duration);
            handCards[i].transform.DORotate(rotation.eulerAngles, duration);
        }

        yield return new WaitForSeconds(duration);
    }
}
