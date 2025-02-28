using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public PlayerStat playerHealth; 
    public Text healthText;
    public Image healthBar;

    void Update()
    {
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        healthText.text = $"Health: {playerHealth.CurrentHealth}";
        float fillAmount = (float)playerHealth.CurrentHealth / playerHealth.maxHealth;
        healthBar.fillAmount = fillAmount;
    }
}
