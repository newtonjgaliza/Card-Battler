using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer illustrationRender;

    [SerializeField] private TextMeshPro cardNameText;

    [SerializeField] private TextMeshPro descriptionText;

    [SerializeField] private TextMeshPro actionsText;

    private Vector3 originalScale;

    private Vector3 originalPosition;

    private SortingGroup sortingGroup;

    private int originalSortingOrder;

    [SerializeField] private float hoverScale = 2f;

    [SerializeField] private float hoverOffset = 2f;

    void Awake()
    {
        sortingGroup = GetComponent<SortingGroup>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.localPosition;
        originalSortingOrder = sortingGroup.sortingOrder;
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

    private void OnMouseEnter()
    {
        Debug.Log("Mouse Entered!");
        transform.localScale = originalScale * hoverScale;
        transform.localPosition += new Vector3(0, hoverOffset, 0);
        sortingGroup.sortingOrder += 1;
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        transform.localScale = originalScale;
        transform.localPosition = originalPosition;
        sortingGroup.sortingOrder = originalSortingOrder;
    }
}
