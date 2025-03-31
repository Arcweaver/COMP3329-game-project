using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TrickstersGambit : Skill
{
    // Skill properties
    public TrickstersGambit()
    {
        //skill description
        id = 5;
        skillName = "Trickster's Gambit";
        description = "Roll 2 die. Low rolls (<=6) increase your damage by twice the value for 5 seconds. High rolls fire a blast travelling forward for 10 times the value as damage.";

        //load icon
        iconPath = "Icon/DragonCharge";
        icon = Resources.Load<Sprite>(iconPath);

        //cooldown
        cooldown = 1f;

        //load stat modifier
        statModifier = new TrickstersGambitModifier(affix);

        //load prefab
        skillshotPrefabPath = "Prefabs/TrickstersGambitPrefab";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath);

        //timers
        cooldownTimer = 0;
        globalCooldownTimer = 0;
    }

    public override void UseSkill(Vector3 position, Vector3 direction, UnitTemplate userUnit)
    {
        if (CanUseSkill() && userUnit.stamina >= staminaCost)
        {
            //use stamina
            userUnit.stamina -= staminaCost;

             // Skillshot or Modifer?
            int roll1 = Random.Range(1, 6);
            int roll2 = Random.Range(1, 6);
            Debug.Log(roll1 + roll2);
            if (roll1 + roll2 <= 6)
            {
                ApplyStatModifier(userUnit);
                Debug.Log("Trickster's Gambit applied stat!");
            }
            else 
            {
                skillshotPrefab.GetComponent<TrickstersGambitSkillshot>().damage = (roll1 + roll2) * 10;
                GenerateSkillshot(position, direction, userUnit);
            }

            // Start GCD
            globalCooldownTimer = globalCooldown;
            // Set the next use time for the skill based on cooldown
            cooldownTimer = cooldown;
            //also trigger other skill's gcd
            //userUnit.triggerGCD();

            // null logging
            //if (skillshotPrefab == null)
            //{
            //    Debug.Log($"Failed to load prefeb for {skillName}!");
            //}
            //if (statModifier == null)
            //{
            //    Debug.Log($"Failed to load the stat modifier for {skillName}!");
            //}
        }
        else
        {
            Debug.Log($"{skillName} is on cooldown or during global cooldown.");
        }
    }
}

