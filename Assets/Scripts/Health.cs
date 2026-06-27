using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int totalHealth = 100;
    private int currentHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = totalHealth;
    }

    public void HealDamage(int amount)
    {
        Debug.Log("heal damage");

        if(amount <= 0)
        {
            return;            
        }

        currentHealth += amount;

        if(currentHealth > totalHealth)
        {
            currentHealth = totalHealth;
        }
        Debug.Log(currentHealth);

    }
    

}
