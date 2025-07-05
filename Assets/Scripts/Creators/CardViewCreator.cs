using DG.Tweening;
using UnityEngine;

public class CardViewCreator : Singleton<CardViewCreator>
{
    [SerializeField]
    private CardView cardViewPrefab;

    public CardView CreateCardView(Card card, Vector3 positon, Quaternion rotation)
    {
        CardView cardView = Instantiate(cardViewPrefab, positon, rotation, transform);
        cardView.transform.localScale = Vector3.zero;
        cardView.transform.DOScale(Vector3.one, 0.15f);
        cardView.UpdateCardInfo(card);
        return cardView;
    }
}
