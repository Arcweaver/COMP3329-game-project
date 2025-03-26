using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationUI : MonoBehaviour
{
    public GameObject tooltip;
    public GameObject skillSet;
    public GameObject skillMenu;
    public GameObject skillMenuItemPrefab;
    public int skillSetIndex;
    public List<Skill> skills;
    public List<Skill> selectedSkills;

    // Init all variable
    void Awake()
    {
        skillSetIndex = -1;
        skills = StaticData.skills;
        selectedSkills = StaticData.selectedSkills;
        ShowSkillSet();
        HideSkillMenu();
    }

    // To record which skill in skill set is selected
    public void SetSkillSetIndex(int skillSetIndex)
    {
        this.skillSetIndex = skillSetIndex;
    }

    public void ShowSkillMenu()
    {
        skillMenu.SetActive(true);
    }

    public void HideSkillMenu()
    {
        skillMenu.SetActive(false);
    }

    // Create a skill menu item for each skill
    public void ShowSkills()
    {
        // Reset the menu
        foreach (Transform child in skillMenu.transform) Destroy(child.gameObject);

        // Create a skill menu item
        foreach (Skill skill in skills)
        {
            GameObject skillMenuItemObject = Instantiate(skillMenuItemPrefab, skillMenu.transform);
            SkillMenuItem skillMenuItem = skillMenuItemObject.GetComponent<SkillMenuItem>();
            skillMenuItem.skill = skill;
            skillMenuItem.tooltip = tooltip.GetComponent<Tooltip>();
            skillMenuItem.SetIcon();
            skillMenuItem.GetComponent<Button>().onClick.AddListener(() => {
                SetSkill(skillMenuItemObject);
            });
        }
    }

    // When click on a skill menu item, set it to skill set
    public void SetSkill(GameObject skillMenuItemObject)
    {
        Skill skillToSet = skillMenuItemObject.GetComponent<SkillMenuItem>().skill;

        // Clear duplicate skill
        for (int i = 0; i < selectedSkills.Count; i++)
        {
            if (selectedSkills[i].id == skillToSet.id)
                selectedSkills[i] = new();
        }

        selectedSkills[skillSetIndex] = skillToSet;
        StaticData.selectedSkills = selectedSkills;
        ShowSkillSet();
    }

    // Load the skill set to teh skill set UI
    private void ShowSkillSet()
    {
        for (int i = 0; i < skillSet.transform.childCount; i++)
        {
            GameObject skillSlot = skillSet.transform.GetChild(i).gameObject;
            skillSlot.GetComponent<Image>().sprite = selectedSkills[i].icon;
        }
    }
}
