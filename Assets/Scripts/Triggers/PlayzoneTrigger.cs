using UnityEngine;

public class PlayzoneTrigger : MonoBehaviour
{
    [SerializeField] private PlayerHand playerHand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Card card))
        {
            playerHand.PlayCard(card);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Card card))
        {
            
        }
    }
}
