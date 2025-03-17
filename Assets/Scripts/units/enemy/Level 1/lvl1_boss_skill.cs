using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Lvl1_Boss_Skill1 : Skill
{
    // Skill properties
    void Start()
    {
        //skill description
        skillName = "lvl 1 boss Lazer";
        description = "Rock lazer beam";

        //load prefab
        skillshotPrefabPath = "Prefabs/lvl1BossSkill1Prefab";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath); //skillshot

        //load stat modifier
        statModifier = new Lvl1_Boss_Skill1_Boss_Modifier();  //to stop movement

        //cooldown
        cooldown = 5f;
        globalCooldown = 3f;  //a trick to disable the use of other skills during this skill
                              //remember to have cd checking for relevent units
                              // ps. this is 2 seconds of channel beam + 1 second of real gcd

        //timers
        cooldownTimer = 3f;  //3 seconds before the boss can act
        globalCooldownTimer = 0;  
    }
}

public class Lvl1_Boss_Skill2 : Skill
{
    // Skill properties
    void Start()
    {
        //skill description
        skillName = "lvl 1 boss bullet";
        description = "a bullet";

        //load prefab
        skillshotPrefabPath = "Prefabs/lvl1BossSkill2Prefab";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath); //skillshot


        //cooldown
        cooldown = 5f;
        globalCooldown = 1f;  //set it to prevent ability chain casting
                              //or set to 0 if you want to allow chain casting

        //timers
        cooldownTimer = 3f;  //3 seconds before the boss can act
        globalCooldownTimer = 0;
    }
}







//modifiers (lazy declaration)
public class Lvl1_Boss_Skill1_Boss_Modifier : StatModifier
{
    public float speedBonus = 2f;

    public Lvl1_Boss_Skill1_Boss_Modifier()
    {
        duration = 2;
        timer = duration;
    }

    public override void ApplyStatChange(UnitStat stat)
    {
        stat.moveSpeed *= 0;
    }

    public override void ApplyChangeOnUpdate(UnitTemplate unit, UnitStat stat){}
    public override void ApplyExpirationChange(UnitTemplate unit){}
}