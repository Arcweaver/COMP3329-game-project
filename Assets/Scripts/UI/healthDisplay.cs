using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public UnitTemplate unit; 
    public Text healthText;
    public Image healthBar;

    void Update()
    {
        UpdateHealthDisplay();
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
}
