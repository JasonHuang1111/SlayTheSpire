using TMPro;
using UnityEngine;

/// <summary>
/// 单张卡片预制体
/// </summary>
public class CardView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tittle;

    [SerializeField]
    private TMP_Text description;

    [SerializeField]
    private TMP_Text mana;

    [SerializeField]
    private SpriteRenderer imgSR;

    [SerializeField]
    private GameObject wrapper;

    //当前卡牌持有的数据
    public Card Card { get; private set; }

    public void UpdateCardInfo(Card card)
    {
        Card = card;
        tittle.text = card.Title;
        description.text = card.Description;
        mana.text = card.Mana.ToString();
        imgSR.sprite = card.Image;
    }
}