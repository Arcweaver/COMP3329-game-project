using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SkillUIManager : MonoBehaviour
{
    [SerializeField] private Button[] skillButtons = new Button[4];
    [SerializeField] private Image[] cooldownOverlays = new Image[4];
    public PlayerController controller;

    void Start()
    {

        List<Skill> skills = new List<Skill>();
        skills.Add(controller.skill1);
        skills.Add(controller.skill2);
        skills.Add(controller.skill3);
        skills.Add(controller.skill4);


        for (int i = 0; i < skillButtons.Length; i++)
        {
            if (skills[i] == null)
            {
                Debug.LogError($"Skill at index {i} is null!");
                continue;
            }
            int index = i;
            skillButtons[i].image.sprite = skills[i].icon;
            //skillButtons[i].onClick.AddListener(() => ActivateSkill(index));   //i do not know how to fix
        }
    }

    void Update()
    {
        /*
        if (playerSkills == null) return; // Early exit if not assigned

        Skill[] skills = playerSkills.GetSkills();
        if (skills == null || skills.Length == 0) return; // Early exit if no skills

        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i] == null) continue; // Skip null skills

            float maxCooldown = Mathf.Max(skills[i].cooldownTimer, skills[i].globalCooldownTimer);
            if (maxCooldown > 0)
            {
                skillButtons[i].interactable = false;
                float fillAmount = maxCooldown / skills[i].cooldown;
                cooldownOverlays[i].fillAmount = fillAmount;
            }
            else
            {
                skillButtons[i].interactable = true;
                cooldownOverlays[i].fillAmount = 0;
            }
        }*/
    }

    
    /*void ActivateSkill(int skillIndex)

        if (skillIndex < skills.Length && skills[skillIndex] != null && skills[skillIndex].CanUseSkill())
        {
            playerSkills.UseSkill(skillIndex);
        }
    }*/
}