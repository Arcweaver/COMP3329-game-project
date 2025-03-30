
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Lvl2_Skill_SpawnFungus : Skill
{
    // Skill properties
    public Lvl2_Skill_SpawnFungus()
    {
        //skill description
        skillName = "lvl 2 boss spawn fungus";
        description = "spawn fungus enemy";

        //load prefab
        skillshotPrefabPath = "Prefabs/lvl2Fungus";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath); //enemy


        //cooldown
        cooldown = 12f;
        globalCooldown = 1f; 

        //timers
        cooldownTimer = 3f;  // seconds before the boss can act
        globalCooldownTimer = 0;  
    }
}

public class Lvl2_Skill_InfectedSmash : Skill
{
    // Skill properties
    public Lvl2_Skill_InfectedSmash()
    {
        //skill description
        skillName = "lvl 2 boss infected smash";
        description = "smash in cone and destroy fungi";

        //load prefab
        skillshotPrefabPath = "Prefabs/lvl2InfectedSmashPrefab";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath); //skillshot

        //cooldown
        cooldown = 12f;
        globalCooldown = 3f;  //disable skill usage

        //load stat modifier
        statModifier = new Lvl2_Boss_Standstill_Modifier(globalCooldown);  //to stop movement

        //timers
        cooldownTimer = 3f;  // seconds before the boss can act
        globalCooldownTimer = 0;
    }
}


public class Lvl2_Skill_BasicAttack : Skill
{
    // Skill properties
    public Lvl2_Skill_BasicAttack()
    {
        //skill description
        skillName = "lvl 2 boss basic attack";
        description = "slow frontal cleave";

        //load prefab
        skillshotPrefabPath = "Prefabs/lvl2BasicAttackPrefab";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath); //skillshot


        //cooldown
        cooldown = 1f;
        globalCooldown = 2.5f;  //disable skill usage

        //load stat modifier
        statModifier = new Lvl2_Boss_Standstill_Modifier(globalCooldown);  //to stop movement

        //timers
        cooldownTimer = 3f;  // seconds before the boss can act
        globalCooldownTimer = 0;
    }
}

public class Lvl2_Skill_SporeBurst : Skill
{
    // Skill properties
    public Lvl2_Skill_SporeBurst()
    {
        //skill description
        skillName = "lvl 2 fungus spore burst";
        description = "spore burst";

        //load prefab
        skillshotPrefabPath = "Prefabs/lvl2SporeBurstPrefab";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath); //skillshot

        //cooldown
        cooldown = 0f;
        globalCooldown = 0f;  

        //timers
        cooldownTimer = 0f; 
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







//modifiers (lazy declaration)
public class Lvl2_Boss_Standstill_Modifier : StatModifier
{
    public float speedBonus = 2f;

    public Lvl2_Boss_Standstill_Modifier(float dura)
    {
        duration = dura;
        timer = duration;
    }

    public override void ApplyStatChange(UnitStat stat)
    {
        stat.moveSpeed *= 0;
    }

    public override void ApplyChangeOnUpdate(UnitTemplate unit, UnitStat stat){}
    public override void ApplyExpirationChange(UnitTemplate unit){}
}

public class Lvl2_Boss_Self_Debuff_Modifier : StatModifier
{
    public float speedBonus = 2f;

    public Lvl2_Boss_Self_Debuff_Modifier()
    {
        duration = 10;
        timer = duration;
    }

    public override void ApplyStatChange(UnitStat stat)
    {
        stat.damageTakenModifier += 1;
    }

    public override void ApplyChangeOnUpdate(UnitTemplate unit, UnitStat stat) { }
    public override void ApplyExpirationChange(UnitTemplate unit) { }
}