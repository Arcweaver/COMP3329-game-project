using UnityEngine;

public class DragonCharge : Skill, ISkill
{
    public DragonCharge()
    {
        //skill description
        id = 4;
        skillName = "DragonCharge";
        description = "Charge Forward a distance (200% movespeed for 2 sec, towards mouse dir), stopping when hitting an enemy or terrain. When stopped due to collision, deal 70 damage in an area, and increase your critical chance by 100% for 5 seconds.";

        //load icon
        iconPath = "Icon/DragonCharge";
        icon = Resources.Load<Sprite>(iconPath);

        //cooldown
        cooldown = 7f;
        staminaCost = 15f;

        //load prefab
        skillshotPrefabPath = "Prefabs/DragonChargePrefab";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath);

        //timers
        cooldownTimer = 0;
        globalCooldownTimer = 0;

    }

    private float remainingCooldown = 0f;
    private bool isOnCooldown = false;

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
            Debug.Log("Dragon Charge Skill Activated!");
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
