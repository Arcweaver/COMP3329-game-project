using UnityEngine;
using UnityEngine.UI;

public class BossHealthDisplay : MonoBehaviour
{
    public BossTemplate bossHealth; 
    //public Text healthText;
    public Image healthBar;

    void Update()
    {
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        //healthText.text = $"Health: {bossHealth.bossCurrentHp}";
        float fillAmount = (float)bossHealth.bossCurrentHp / bossHealth.bossMaxHp;
        healthBar.fillAmount = fillAmount;
    }
}
