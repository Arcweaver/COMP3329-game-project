using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SkillUIManager : MonoBehaviour
{
    [SerializeField] private Button[] skillButtons = new Button[4];
    [SerializeField] private Image[] cooldownOverlays = new Image[4];
    List<Skill> skills = new List<Skill>();

    void Start()
    {
        skills.Add(StaticData.selectedSkills[0]);
        skills.Add(StaticData.selectedSkills[1]);
        skills.Add(StaticData.selectedSkills[2]);
        skills.Add(StaticData.selectedSkills[3]);


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
        if (skills == null || skills.Count < 4) return; // Early exit if no skills

        for (int i = 0; i < 4; i++)
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
        }
    }


    /*void ActivateSkill(int skillIndex)

        if (skillIndex < skills.Length && skills[skillIndex] != null && skills[skillIndex].CanUseSkill())
        {
            playerSkills.UseSkill(skillIndex);
        }
    }*/
}