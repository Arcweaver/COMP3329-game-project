using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillMenuItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltipPrefab;
    public GameObject tooltip;
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
        tooltip = Instantiate(tooltipPrefab, transform);
        TMP_Text tooTipSkillName = tooltip.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        TMP_Text tooTipDescription = tooltip.transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
        tooTipSkillName.text = skill.skillName;
        tooTipDescription.text = skill.description;
    }
    private void HideTooltip()
    {
        Destroy(tooltip);
    }
}
