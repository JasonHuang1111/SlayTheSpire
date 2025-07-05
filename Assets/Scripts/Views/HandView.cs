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
    /// 更新手牌位置
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    private IEnumerator UpdateCardPositions(float duration)
    {
        if (handCards.Count == 0) yield break;
        //计算卡牌之间的间距 1就是曲线的总长度
        float caradSpacing = 1f / maxHandCount;
        //计算发牌第一张牌的位置
        float firstCardPosition = 0.5f - (handCards.Count - 1) * caradSpacing / 2;
        Spline spline = splineContainer.Spline;

        //依次更新手牌中的卡牌位置
        for (int i = 0; i < handCards.Count; i++)
        {
            float position = firstCardPosition + i * caradSpacing;

            Vector3 splinePositon = spline.EvaluatePosition(position);
            Vector3 forward = spline.EvaluateTangent(position);
            Vector3 up = spline.EvaluateUpVector(position);

            Quaternion rotation = Quaternion.LookRotation(-up, Vector3.Cross(-up, forward).normalized);


            handCards[i].transform.DOMove(splinePositon + transform.position + 0.01f * i * Vector3.back, duration);
            handCards[i].transform.DORotate(rotation.eulerAngles, duration);
        }
        yield return new WaitForSeconds(duration);
    }
}
