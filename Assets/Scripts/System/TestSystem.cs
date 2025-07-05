using UnityEngine;

public class TestSystem : MonoBehaviour
{
    [SerializeField]
    private HandView handView;
    [SerializeField]
    private CardData cardData;
    [SerializeField]
    private CardView cardView;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Card card = new Card(cardData);
            CardView cardView = CardViewCreator.Instance.CreateCardView(card, Vector3.zero, Quaternion.identity);
            StartCoroutine(handView.AddCard(cardView));
        }
    }
}
