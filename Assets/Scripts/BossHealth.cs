using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            HandleVictory();
        }
    }

    private void HandleVictory()
    {
        PlayerPrefs.SetInt("PlayerWon", 1); // Player won
        PlayerPrefs.SetString("LevelResult", "You defeated the boss and unlocked a new skill!");
        PlayerPrefs.Save();
        SceneManager.LoadScene("CompletionUI"); // Switch to the victory screen
    }
}
