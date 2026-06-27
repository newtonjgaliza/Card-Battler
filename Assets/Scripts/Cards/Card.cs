using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

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

    private static bool isBeingDragged = false;

    private CardData cardData;

    private Collider2D cardCollider;

    void Awake()
    {
        sortingGroup = GetComponent<SortingGroup>();
        cardCollider = GetComponent<Collider2D>();
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
        this.cardData = cardData;
        illustrationRender.sprite = cardData.illustration;
        cardNameText.text = cardData.cardName;
        descriptionText.text = cardData.description;
        actionsText.text = cardData.actionCost.ToString();
    }

    private void OnMouseEnter()
    {
        if(isBeingDragged)
        {
            return;
        }

        transform.localScale = originalScale * hoverScale;
        transform.localPosition += new Vector3(0, hoverOffset, 0);
        sortingGroup.sortingOrder += 1;
    }

    private void OnMouseExit()
    {
        if(isBeingDragged)
        {
            return;
        }

        transform.localScale = originalScale;
        transform.localPosition = originalPosition;
        sortingGroup.sortingOrder = originalSortingOrder;
    }

    private void OnMouseDrag()
    {
        isBeingDragged = true;
        gameObject.transform.position = GetMousePosition();
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition.z = transform.position.z - Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseUp()
    {
        isBeingDragged = false;
        transform.localScale = originalScale;
        transform.localPosition = originalPosition;
        sortingGroup.sortingOrder = originalSortingOrder;
    }

    public CardData GetCardData() => cardData;

    private void OnDestroy()
    {
        isBeingDragged = false;
    }

    public void SetInteractable(bool interactable)
    {
        cardCollider.enabled = interactable;
    }
    
}
