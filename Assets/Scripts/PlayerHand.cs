using UnityEngine;
using System.Collections.Generic;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Deck deck;

    [SerializeField] private Transform[] cardSlots;

    [SerializeField] private GameObject cardPrefab;

    [SerializeField] private int startingHandSize = 2;

    private List<Card> cardsInHand = new List<Card>();

    [SerializeField] private DiscardPile discardPile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < startingHandSize; i++)
        {
            DrawNextCard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawNextCard()
    {
        if(cardSlots == null || cardsInHand.Count >= cardSlots.Length)
        {
            Debug.Log("Hand is full or slots are null");
            return;
        }

        CardData cardData = deck.DrawCard();

        if(cardData == null)
        {
            Debug.Log("No more cards in the deck!");
            return;
        }

        int slotIndex = cardsInHand.Count;
        GameObject newCard = Instantiate(cardPrefab, cardSlots[slotIndex].position, Quaternion.identity);
        Card cardComponent = newCard.GetComponent<Card>();
        cardComponent.LoadCardData(cardData);
        cardsInHand.Add(cardComponent);
        cardsInHand[slotIndex].transform.SetParent(cardSlots[slotIndex]);
    }

    public void PlayCard(Card card)
    {
        Debug.Log("Play Card");
        cardsInHand.Remove(card);
        discardPile.DiscardCard(card.GetCardData());
        Destroy(card.gameObject);
        RepositionCards();
    }

    private void RepositionCards()
    {
        //Unparent each card from current slot
        for(int i = 0; i < cardsInHand.Count; i++)
        {
            cardsInHand[i].transform.SetParent(null);
        }

        for(int i = 0; i < cardsInHand.Count; i++)
        {
            cardsInHand[i].transform.SetParent(cardSlots[i]);
            cardsInHand[i].transform.position = cardSlots[i].position;
        }
    }

}
