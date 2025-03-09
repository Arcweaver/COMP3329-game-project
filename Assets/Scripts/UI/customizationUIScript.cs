using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationUI : MonoBehaviour
{
    public GameObject skillSet;
    public GameObject skillMenu;
    public GameObject skillMenuItemPrefab;
    public int skillSetIndex;
    public struct SkillProp
    {
        public SkillProp(string skillName, string description, Sprite icon)
        {
            this.skillName = skillName;
            this.description = description;
            this.icon = icon;
        }
        public string skillName;
        public string description;
        public Sprite icon; 
    };
    public List<SkillProp> skills;
    public List<SkillProp> selectedSkills;

    void Start()
    {
        HideSkillMenu();
        skillSetIndex = -1;
        skills = new List<SkillProp>
        {
            new("test1", "This is a test 1", null),
            new("test2", "This is a test 2", null)
        };
        selectedSkills = new List<SkillProp>
        {
            new(),
            new(),
            new(),
            new(),
            new(),
        };
    }
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
    public void ShowSkills()
    {
        foreach (Transform child in skillMenu.transform) Destroy(child.gameObject);
        for (int i = 0; i < skills.Count; i++)
        {
            SkillProp skill = skills[i];
            GameObject skillMenuItem = Instantiate(skillMenuItemPrefab, skillMenu.transform);
            skillMenuItem.transform.SetSiblingIndex(i);
            skillMenuItem.GetComponent<Image>().sprite = skill.icon;
            skillMenuItem.GetComponentInChildren<TMP_Text>().text = skill.skillName;
            skillMenuItem.GetComponent<Button>().onClick.AddListener(() => {
                SetSkill(skillMenuItem);
            });
            skillMenuItem.transform.SetParent(skillMenu.transform);
        }
    }
    public void SetSkill(GameObject currentSkillMenuItem)
    {
       selectedSkills[skillSetIndex] = skills[currentSkillMenuItem.transform.GetSiblingIndex()];
       GameObject selectedSkill = skillSet.transform.GetChild(skillSetIndex).gameObject;
       Debug.Log(selectedSkill);
       selectedSkill.GetComponentInChildren<TMP_Text>().text = selectedSkills[skillSetIndex].skillName;
    }
}
