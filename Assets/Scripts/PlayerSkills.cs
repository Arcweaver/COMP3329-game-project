using UnityEngine;
using System.Collections.Generic;

public class PlayerSkills : MonoBehaviour
{
    private List<Skill> activeSkills;
    [SerializeField] private UnitTemplate playerUnit;

    void Start()
    {
        // Debug
        activeSkills = StaticData.selectedSkills;
        if (activeSkills == null)
        {
            Debug.LogError("StaticData.selectedSkills is null!");
            return;
        }
        if (activeSkills.Count != 4)
        {
            Debug.LogError($"StaticData.selectedSkills has {activeSkills.Count} skills, expected 4!");
            return;
        }
        for (int i = 0; i < activeSkills.Count; i++)
        {
            if (activeSkills[i] == null)
            {
                Debug.LogError($"Skill at index {i} in StaticData.selectedSkills is null!");
            }
        }  // End of debug

        activeSkills = StaticData.selectedSkills;
        if (activeSkills == null || activeSkills.Count != 4)
        {
            Debug.LogError("StaticData.selectedSkills must contain exactly 4 skills!");
            return;
        }

        if (playerUnit == null)
        {
            playerUnit = GetComponent<UnitTemplate>();
            if (playerUnit == null)
            {
                Debug.LogError("PlayerSkills requires a SkillTemplate component on the Player!");
            }
        }
    }

    void Update()
    {
        foreach (var skill in activeSkills)
        {
            skill.UpdateCooldown();
        }

        for (int i = 0; i < activeSkills.Count && i < 4; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && activeSkills[i].CanUseSkill()) // Now accessible
            {
                UseSkill(i);
            }
        }
    }
    
    public void UseSkill(int index)
    {
        if (index >= 0 && index < activeSkills.Count)
        {
            Vector3 position = transform.position;
            Vector3 direction = transform.forward;
            activeSkills[index].UseSkill(position, direction, playerUnit);
        }
    }

    public Skill[] GetSkills()
    {
        return activeSkills.ToArray();
    }
}