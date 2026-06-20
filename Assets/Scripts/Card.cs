using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer illustrationRender;

    [SerializeField] private TextMeshPro cardNameText;

    [SerializeField] private TextMeshPro descriptionText;

    [SerializeField] private TextMeshPro actionsText;

    [SerializeField] private CardData tempCardData;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadCardData(tempCardData);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCardData(CardData cardData)
    {
        illustrationRender.sprite = cardData.illustration;
        cardNameText.text = cardData.cardName;
        descriptionText.text = cardData.description;
        actionsText.text = cardData.actionCost.ToString();
    }
}
