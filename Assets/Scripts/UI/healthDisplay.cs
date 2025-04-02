using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthDisplay : MonoBehaviour
{
    public UnitTemplate unit; 
    public Text healthText;
    public Image healthBar;

    void Update()
    {
        UpdateHealthDisplay();

        if (unit.currentHealth <= 0)
        {
            HandleGameOver();
        }
    }

    private void UpdateHealthDisplay()
    {
        if (healthText != null)
        {
            healthText.text = $"Health: {unit.currentHealth}";
        }
        float fillAmount = (float)unit.currentHealth / unit.maxHealth;
        healthBar.fillAmount = fillAmount;
    }

    public virtual void HandleGameOver()
    {
        PlayerPrefs.SetInt("PlayerWon", 0); // Player lost
        PlayerPrefs.SetString("LevelResult", "You were defeated. Try again!");
        PlayerPrefs.Save(); // Save PlayerPrefs data
        SceneManager.LoadScene("CompletionUI"); // Switch to the game over screen
    }
}
