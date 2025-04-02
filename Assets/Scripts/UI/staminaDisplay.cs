using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StaminaDisplay : MonoBehaviour
{
    public UnitTemplate unit; 
    public Image staminaBar;

    void Update()
    {
        UpdateStaminaDisplay();
    }

    private void UpdateStaminaDisplay()
    {
        float fillAmount = (float)unit.Stamina / 100;
        staminaBar.fillAmount = fillAmount;
    }

}
