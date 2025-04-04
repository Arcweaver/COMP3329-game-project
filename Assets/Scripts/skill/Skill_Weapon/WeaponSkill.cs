using UnityEngine;

public class WeaponSkill : Skill
{
    public WeaponSkill()
    {
        //skill description
        id = 0;
        skillName = "Weapon";

        //load prefab
        skillshotPrefabPath = "Prefabs/WeaponParent";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath);

        //cooldown
        cooldown = 1f;

        //timers
        cooldownTimer = 0;
        globalCooldownTimer = 0;
    }

     public override void UseSkill(Vector3 position, Vector3 direction, UnitTemplate userUnit)
    {
        if (CanUseSkill())
        {
            // Generate skillshot if applicable
            if (skillshotPrefab != null)
            {
                GenerateSkillshot(position, direction, userUnit);
            }

            // Start cooldown
            cooldownTimer = cooldown;

        }
        else
        {
            Debug.Log($"{skillName} is on cooldown or during global cooldown.");
        }
    }
}
