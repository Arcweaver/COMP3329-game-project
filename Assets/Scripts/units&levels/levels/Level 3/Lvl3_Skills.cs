using UnityEngine;

public class Lvl3_Skill_Smite : Skill
{
    // Skill properties
    public Lvl3_Skill_Smite()
    {
        //skill description
        skillName = "lvl 3 boss smite";
        description = "Every few (10) seconds, fire a holy energy at the player's position, hitting after a few seconds. (circle indicator)";

        //load prefab
        skillshotPrefabPath = "Prefabs/lvl3Smite";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath); //enemy


        //cooldown
        cooldown = 5f;
        globalCooldown = 1f; 

        //timers
        cooldownTimer = 3f;  // seconds before the boss can act
        globalCooldownTimer = 0;  
    }
}