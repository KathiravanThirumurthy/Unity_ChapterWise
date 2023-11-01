using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CardArranger : MonoBehaviour
{
    public GameObject[] cardPrefabs;
    public Transform cardContainer;
    private List<GameObject> cardInstances;
    public int rowCount = 2;
    public int columnCount = 4;
    private Card firstCard;
    private Card secondCard;
    /*
     Pseudocode


     */

    void Start()
    {
        cardInstances = new List<GameObject>();

        foreach (var prefab in cardPrefabs)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject card = Instantiate(prefab, Vector3.zero, Quaternion.Euler(0, 270, 0));
                card.transform.parent = cardContainer;
                cardInstances.Add(card);
            }
        }

        ShuffleCards(cardInstances);
        ArrangeCards(cardInstances);
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                Card card = hitObject.GetComponent<Card>();

                if (card != null && !card.IsMatched)
                {
                    if (firstCard == null)
                    {
                        firstCard = card;
                        firstCard.FlipToFront();
                    }
                    else if (secondCard == null && firstCard != card)
                    {
                        secondCard = card;
                        secondCard.FlipToFront();

                        StartCoroutine(CheckForMatch());
                    }
                }
            }
        }

    }


    void DeactivateCard(Card card)
    {
       
        card.IsMatched = true;
        card.gameObject.SetActive(false);

    }

       

    void ShuffleCards(List<GameObject> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int randomIndex = Random.Range(i, cards.Count);
            GameObject temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    void ArrangeCards(List<GameObject> cards)
    {
        // Adjust based on your card size
        float cardWidth = 3.0f; 
        float cardHeight = 3.0f; 

        for (int i = 0; i < cards.Count; i++)
        {
            int row = i / columnCount;
            int column = i % columnCount;

            float posX = column * cardWidth;
            float posY = -row * cardHeight;

            cards[i].transform.position = new Vector3(posX, posY, 0);
        }
    }

    IEnumerator CheckForMatch()
    {
        yield return new WaitForSeconds(1f); // Adjust the duration as needed

        if (firstCard.symbol == secondCard.symbol)
        {
            // Match found
            Debug.Log("Match found: " + firstCard.symbol);
            DeactivateCard(firstCard);
            DeactivateCard(secondCard);
        }
        else
        {
            // No match found
            Debug.Log("No match found");
            firstCard.FlipToBack();
            secondCard.FlipToBack();
        }

        firstCard = null;
        secondCard = null;
    }

}
