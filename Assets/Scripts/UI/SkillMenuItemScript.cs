using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillMenuItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Tooltip tooltip;
    public Skill skill;

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
    }

    // Show the tooltip with info of the skill
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
