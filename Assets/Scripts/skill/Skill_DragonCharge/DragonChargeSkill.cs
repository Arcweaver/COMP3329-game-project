using UnityEngine;

public class DragonCharge : Skill
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
        cooldown = 1f;
        staminaCost = 15f;

        //load prefab
        skillshotPrefabPath = "Prefabs/DragonChargePrefab";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath);

        //timers
        cooldownTimer = 0;
        globalCooldownTimer = 0;
    }
}
