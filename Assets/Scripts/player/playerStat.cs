using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private float damageTimer;
    public float damageInterval = 2f;

    public int CurrentHealth => currentHealth; 

    void Start()
    {
        currentHealth = maxHealth; 
    }

    private void Update()
    {
        // Check if the timer has elapsed
        damageTimer += Time.deltaTime;
        if (damageTimer >= damageInterval)
        {
            int coin = Random.Range(0, 2);
            if (coin == 0)
            {
                TakeDamage(Random.Range(5, 15));
            }
            else
            {
                Heal(Random.Range(5, 15));
            }
            
            damageTimer = 0; // Reset the timer
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Current Health: {currentHealth}");
    }


    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Current Health: {currentHealth}");
    }
}
