using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<CardData> drawPile = new List<CardData>();
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(DrawCard());
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
}
