using UnityEngine;

//SO只是一个数据模版,如果想要同一个种类的卡牌拥有多个实例,那就需要用一个类来装载并实例化
public class Card
{
    //名字就是SO游戏对象的名字
    public string Title => data.name;
    public string Description => data.Description;
    public Sprite Image => data.Image;
    public int Mana { get; private set; }

    private readonly CardDataSO data;

    /// <summary>
    /// 构造方法,初始化卡牌数据
    /// </summary>
    /// <param name="cardData"></param>
    public Card(CardDataSO cardData)
    {
        data = cardData;
        Mana = cardData.Mana;
    }
}
