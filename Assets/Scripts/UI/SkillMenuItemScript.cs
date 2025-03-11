using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillMenuItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Tooltip tooltip;
    public CustomizationUI.SkillProp skill;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        HideTooltip();
    }
    public void SetIcon()
    {
        gameObject.GetComponent<Image>().sprite = skill.icon;
        gameObject.GetComponentInChildren<TMP_Text>().text = skill.skillName;
    }
    private void ShowTooltip()
    {
        tooltip.Show();
        tooltip.SetHeader(skill.skillName);
        tooltip.SetDescription(skill.description);
    }
    private void HideTooltip()
    {
        tooltip.Hide();
    }
}
