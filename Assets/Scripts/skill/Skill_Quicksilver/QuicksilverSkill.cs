using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class QuicksilverSkill : Skill
{
    // Skill properties
    void Start()
    {
        //skill description
        id = 2;
        skillName = "Quicksilver";
        description = "Increase movement speed by 50% for 5 seconds.";

        //affix description
        affix1Name = "Concentrated Sprint";
        affix1Description = "Movement speed bonus increased to 100%. Ends upon using weapon attacks or other skills.";
        affix2Name = "Prolonged Sprint";
        affix2Description = "No longer has a duration. Cost 5 more stamina per second active. Reactivate to cancel the effect.";
        affix3Name = "Synchronization";
        affix3Description = "Continue moving for at least 2 seconds during this effect will reduce the cooldown of all abilities by 2 seconds. Stamina cost increased to 20.";

        //load icon
        //iconPath = "xxx"
        //icon = Resources.Load<Sprite>(iconPath);

        //load stat modifier
        statModifier = new QuicksilverModifier(affix);

        //cooldown
        cooldown = 10f;

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

