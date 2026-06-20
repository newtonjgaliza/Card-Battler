using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<CardData> drawPile = new List<CardData>();

    [SerializeField] private GameObject cardBack;
    
    private const float VERTICAL_SPACING = .1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(DrawCard());
        DeckDrawVisuals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CardData DrawCard()
    {
        if(drawPile.Count > 0)
        {
            int topIndex = drawPile.Count - 1;
            CardData data = drawPile[topIndex];
            drawPile.RemoveAt(topIndex);
            return data;
        }
        return null;
    }

    private void DeckDrawVisuals()
    {
        for(int i = 0; i < drawPile.Count; i++)
        {
            GameObject newCardBack = Instantiate(cardBack, transform);
            newCardBack.transform.localPosition = new Vector3(0f, -i * VERTICAL_SPACING, 0f);
        }
    }
}
