using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class DiscardPile : MonoBehaviour
{
    [SerializeField] private List<CardData> discardPile = new List<CardData>();

    [SerializeField] private GameObject cardPrefab;

    private const float VERTICAL_SPACING = .25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DiscardCard(CardData cardData)
    {
        Debug.Log("Discarding card + " + cardData);
        discardPile.Add(cardData);

        GameObject discardedCard = Instantiate(cardPrefab, transform);
        discardedCard.GetComponent<Card>().LoadCardData(cardData);
        SortingGroup sortingGroup = discardedCard.GetComponent<SortingGroup>();
        discardedCard.GetComponent<Card>().SetInteractable(false);
        sortingGroup.sortingOrder = discardPile.Count - 1;
        
        discardedCard.transform.SetParent(transform);

        discardedCard.transform.localPosition = new Vector3(0f, (discardPile.Count - 1) * -VERTICAL_SPACING, 0f);
    }
}
