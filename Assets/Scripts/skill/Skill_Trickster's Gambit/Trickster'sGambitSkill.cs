using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TrickstersGambit : Skill, ISkill
{
    // Skill properties
    public TrickstersGambitModifier TGStatModifier;

    public TrickstersGambit()
    {
        //skill description
        id = 5;
        skillName = "Trickster's Gambit";
        description = "Roll 2 die. Low rolls (<=6) increase your damage by twice the value for 5 seconds. High rolls fire a blast travelling forward for 10 times the value as damage.";

        //load icon
        iconPath = "Icon/TrickstersGambit";
        icon = Resources.Load<Sprite>(iconPath);

        //cooldown
        cooldown = 6f;

        //load stat modifier
        statModifier = new TrickstersGambitModifier(affix);
        TGStatModifier = (TrickstersGambitModifier) statModifier;

        //load prefab
        skillshotPrefabPath = "Prefabs/TrickstersGambitPrefab";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath);

        //timers
        cooldownTimer = 0;
        globalCooldownTimer = 0;

    }

    private float remainingCooldown = 0f;
    private bool isOnCooldown = false;

    public override void UseSkill(Vector3 position, Vector3 direction, UnitTemplate userUnit)
    {
        if (CanUseSkill() && userUnit.Stamina >= staminaCost)
        {
            //use stamina
            userUnit.Stamina -= staminaCost;

             // Skillshot or Modifer?
            int roll1 = Random.Range(1, 6);
            int roll2 = Random.Range(1, 6);
            Debug.Log(roll1 + roll2);
            if (roll1 + roll2 <= 6)
            {
                TGStatModifier.damageBonus = roll1 + roll2;
                ApplyStatModifier(TGStatModifier, userUnit);
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

    void Update()
    {
        if (isOnCooldown)
        {
            remainingCooldown -= Time.deltaTime;
            if (remainingCooldown <= 0)
            {
                remainingCooldown = 0;
                isOnCooldown = false;
            }
        }
    }

    public void Activate()
    {
        if (!isOnCooldown)
        {
            Debug.Log("Quicksilver Skill Activated!");
            remainingCooldown = cooldown;
            isOnCooldown = true;
        }
    }



    public string GetSkillName() => skillName;
    public Sprite GetIcon() => icon;
    public float GetCooldownTime() => cooldown;
    public float GetRemainingCooldown() => remainingCooldown;
    public bool IsOnCooldown() => isOnCooldown;
}

