using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationUI : MonoBehaviour
{
    public GameObject skillMenuItemPrefab;
    public GameObject skillMenu;
    public string selected;
    public List<Skill> skills;

    void Start()
    {
        HideSkillMenu();
        selected = null;
        skills.Add(gameObject.AddComponent<FrostfireLanceSkill>());
        skills.Add(gameObject.AddComponent<QuicksilverSkill>());
        skills[0].icon = Resources.Load<Sprite>("frostfire_lance");
    }

    public void ShowSkillMenu()
    {
        skillMenu.SetActive(true);
    }

    public void HideSkillMenu()
    {
        skillMenu.SetActive(false);
    }

    public void SetSelected(string selected)
    {
        this.selected = selected;
    }

    public void ShowSkills()
    {
        foreach(Transform child in skillMenu.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Skill skill in skills) 
        {
            GameObject skillMenuItem = Instantiate(skillMenuItemPrefab, skillMenu.transform);
            skillMenuItem.GetComponent<Image>().sprite = skill.icon;
            skillMenuItem.GetComponentInChildren<TMP_Text>().text = skill.skillName;
            skillMenuItem.transform.SetParent(skillMenu.transform);
        }
    }
}
