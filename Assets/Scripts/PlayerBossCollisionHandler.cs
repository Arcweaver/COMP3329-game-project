using UnityEngine;

public class PlayerBossCollisionHandler : MonoBehaviour
{
    public int playerDamage = 10;  // Set the player's damage value
    public int bossDamage = 10;    // Set the boss's damage value

    // When the player hits the boss
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            // Get the BossHealth script and apply damage
            BossHealth bossHealth = collision.gameObject.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(playerDamage);
                // Update the objective tracker that the player hit the boss
                FindObjectOfType<GameObjectiveTracker>().PlayerHitsBoss();
            }
        }

        // When the boss hits the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth script and apply damage
            HealthDisplay playerHealth = collision.gameObject.GetComponent<HealthDisplay>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(bossDamage);
                // Update the objective tracker that the boss hit the player
                FindObjectOfType<GameObjectiveTracker>().BossHitsPlayer();
            }
        }
    }
}
