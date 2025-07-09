using UnityEngine;

[CreateAssetMenu(menuName = "DataS0/Card")]
public class CardDataSO : ScriptableObject
{
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public int Mana { get; private set; }
    [field: SerializeField] public Sprite Image { get; private set; }
}