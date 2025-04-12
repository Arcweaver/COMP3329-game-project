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

public class Lvl3_Skill_CallGuard : Skill
{
    public Lvl3_Skill_CallGuard()
    {
        //skill description
        skillName = "lvl 3 boss call guard";
        description = "Call a guard to attack the player.";

        //load prefab
        skillshotPrefabPath = "Prefabs/lvl3Guard";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath); //enemy


        //cooldown
        cooldown = 30f;
        globalCooldown = 1f;

        //timers
        cooldownTimer = 3f;  // seconds before the boss can act
        globalCooldownTimer = 0;  
    }
}

public class Lvl3_Skill_Gurad_BasicAttack : Skill
{
    // Skill properties
    public Lvl3_Skill_Gurad_BasicAttack()
    {
        //skill description
        skillName = "lvl 3 guard basic attack";
        description = "cleave attack";

        //load prefab
        skillshotPrefabPath = "Prefabs/lvl3GuardBasicAttackPrefab";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath); //skillshot


        //cooldown
        cooldown = 1f;
        globalCooldown = 2.5f;  //disable skill usage

        //load stat modifier
        statModifier = new Lvl3_Guard_Standstill_Modifier(globalCooldown);  //to stop movement

        //timers
        cooldownTimer = 3f;  // seconds before the boss can act
        globalCooldownTimer = 0;
    }
}

public class Lvl3_Skill_HolyNova : Skill
{
    public Lvl3_Skill_HolyNova()
    {
        //skill description
        skillName = "lvl 3 boss holy nova";
        description =   "Fire a cluster of holy bolts spreading outwards. If they hit a unit (except the king), leave behind a sanctified ground. The sanctified ground deals some damage every second to the player if they are in it." +
                        "Additional effects for holy bolts:" +
                        "Player: Deal damage." +
                        "Guard: Movement speed buff." +
                        "Corpse: Revive them and give them movement speed buff. They will not leave behind a corpse when they die.";

        //load prefab
        skillshotPrefabPath = "Prefabs/lvl3HolyNova";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath); //enemy


        //cooldown
        cooldown = 5f;
        globalCooldown = 1f; 

        //timers
        cooldownTimer = 0f;  // seconds before the boss can act
        globalCooldownTimer = 0;  
    }

    protected override void GenerateSkillshot(Vector3 position, Vector3 direction, UnitTemplate userUnit)
    {
        //generate multiple skillshot in random directions
        int numberOfDirections = Random.Range(6, 11); //default 8
        for (int i = 0; i < numberOfDirections; i++)
        {
            float angle = i * (360f / numberOfDirections) * Mathf.Deg2Rad;
            Vector3 _dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            base.GenerateSkillshot(position, _dir, userUnit);
        }
    }
}