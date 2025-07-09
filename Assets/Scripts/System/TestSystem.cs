using UnityEngine;

public class TestSystem : MonoBehaviour
{
    [SerializeField]
    private HandView handView;
    [SerializeField]
    private CardDataSO cardDataSO;
    [SerializeField]
    private CardView cardView;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Card card = new Card(cardDataSO);
            CardView cardView = CardViewCreator.Instance.CreateCardView(card, Vector3.zero, Quaternion.identity);
            StartCoroutine(handView.AddCard(cardView));
        }
    }
}
