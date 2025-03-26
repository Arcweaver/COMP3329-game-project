using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FrostfireLanceSkill : Skill
{
    // Skill properties
    public FrostfireLanceSkill()
    {
        //skill description
        id = 1;
        skillName = "Frostfire Lance";
        description = "Conjure and fire a frostfire lance, dealing 135 damage to enemies in its path.";

        //affix description
        affix1Name = "Splitting Lances";
        affix1Description = "Also fire 2 lesser lances to the sides, dealing 60 damage";
        affix2Name = "Extreme Temperatures";
        affix2Description = " Also cause a freezeburn, dealing 30 damage after 1 second.";
        affix3Name = "Paradox";
        affix3Description = " Firing it to your right deals 20 more damage. Firing to your left reduces its cooldown by 1.";

        //load icon
        iconPath = "Icon/HolyJudgement";
        icon = Resources.Load<Sprite>(iconPath);

        //load prefab
        skillshotPrefabPath = "Prefabs/frostfireLancePrefab";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath);

        //cooldown and stamina
        cooldown = 6f;
        staminaCost = 20f;

        //timers
        cooldownTimer = 0;
        globalCooldownTimer = 0;
}

   
    //to fire different missiles, override this and also declare another skillshot
    //protected override void GenerateSkillshot(Vector3 position, Vector3 direction, UnitTemplate userUnit)
    //{
    //    GameObject skillshot = Object.Instantiate(skillshotPrefab, position, Quaternion.identity);
    //    Skillshot skillshotComponent = skillshot.GetComponent<Skillshot>();
    //    if (skillshotComponent != null)
    //    {
    //        skillshotComponent.Initialize(direction, affix, userUnit);
    //    }
    //}

    //protected virtual void ApplyStatModifier(UnitTemplate userUnit)
    //{
    //    // Logic for applying the stat modifier
    //    if (statModifier != null)
    //    {
    //        userUnit.AddModifier(statModifier);
    //    }
    //}
}


