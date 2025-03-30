using System;
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
        skillshotPrefabPath = "Prefabs/lvl1BossSkill1Prefab";
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
        skillshotPrefabPath = "Prefabs/lvl1BossSkill2Prefab";
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
        skillshotPrefabPath = "Prefabs/lvl1BossSkill2Prefab";
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