using UnityEngine;

/// <summary>
/// 卡牌悬停系统
/// </summary>
public class CardViewHoverSystem : Singleton<CardViewHoverSystem>
{
    [SerializeField]
    private CardView cardViewHover;

    public void Show(Card card, Vector3 position)
    {
        cardViewHover.gameObject.SetActive(true);
        cardViewHover.UpdateCardInfo(card);
        cardViewHover.transform.position = position;
    }

    public void Hide()
    {
        cardViewHover.gameObject.SetActive(false);
    }


}
