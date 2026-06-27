using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject playerSprite;
    private Vector3 originalPosition;
    private Animator animationController;

    private void Awake()
    {
        animationController = playerSprite.GetComponent<Animator>();
    }

    private void Start()
    {
        originalPosition = playerSprite.transform.position;
    }

    private void OnEnable()
    {
        PlayerEvents.OnCardPlayed += HandleCardPlayed;
    }

    private void OnDisable()
    {
        PlayerEvents.OnCardPlayed -= HandleCardPlayed;
    }

    private void HandleCardPlayed(CardData cardData)
    {
        Debug.Log("handler ran"); 

        if(cardData.attackPower > 0)
        {
            //attack
            Attack(cardData);
        }
    }

    private void Attack(CardData cardData)
    {
        Debug.Log("Attack! " + cardData.attackPower);
        StartCoroutine(PlayerAttackAnimation());
    }

    private IEnumerator PlayerAttackAnimation()
    {
        Vector3 targetPosition = originalPosition + new Vector3(4f, 0, 0);

        float duration = .5f;
        float timeElapsed = 0f;

        while(timeElapsed < duration)
        {
            playerSprite.transform.position = Vector3.Lerp(originalPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        animationController.Play("Attack");
        yield return new WaitForSeconds(.5f);
        //animationController.Play("Idle");

        timeElapsed = 0f;
        while(timeElapsed < duration)
        {
            playerSprite.transform.position = Vector3.Lerp(targetPosition, originalPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }
}
