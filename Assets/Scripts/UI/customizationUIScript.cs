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
    // <Temporary Stroage>
    public struct SkillProp
    {
        public SkillProp(int id, string skillName, string description, Sprite icon)
        {
            this.id = id;
            this.skillName = skillName;
            this.description = description;
            this.icon = icon;
        }
        public int id;
        public string skillName;
        public string description;
        public Sprite icon; 
    };
    public List<SkillProp> skills;
    public List<SkillProp> selectedSkills;
    // </Temporary Stroage>

    // Init all variable
    void Awake()
    {
        skillSetIndex = -1;
        skills = new List<SkillProp>
        {
            new(0, "test1", "This is a test 1", null),
            new(1, "test2", "This is a test 2", null),
            new(2, "test2", "This is a test 2", null),
            new(3, "test3", "This is a test 3", null),
            new(4, "test4", "This is a test 4", null),
            new(5, "test5", "This is a test 5", null),
            new(6, "test6", "This is a test 6", null),
            new(7, "test7", "This is a test 7", null),
            new(8, "test8", "This is a test 8", null),
        };
        selectedSkills = new List<SkillProp>
        {
            new(),
            new(),
            new(),
            new(),
            new(),
        };
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
        foreach (SkillProp skill in skills)
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
        SkillProp skillToSet = skillMenuItemObject.GetComponent<SkillMenuItem>().skill;

        // Clear duplicate skill
        for (int i = 0; i < selectedSkills.Count; i++)
        {
            if (selectedSkills[i].id == skillToSet.id)
                selectedSkills[i] = new();
        }

        selectedSkills[skillSetIndex] = skillToSet;
        ShowSkillSet();
    }

    // Load the skill set to teh skill set UI
    private void ShowSkillSet()
    {
        for (int i = 0; i < skillSet.transform.childCount; i++)
        {
            GameObject skillSlot = skillSet.transform.GetChild(i).gameObject;
            skillSlot.GetComponentInChildren<TMP_Text>().text = selectedSkills[i].skillName;
        }
    }
}
