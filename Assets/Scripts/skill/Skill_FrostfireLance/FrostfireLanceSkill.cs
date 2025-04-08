using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FrostfireLanceSkill : Skill, ISkill
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
        iconPath = "Icon/FrostfireLance";
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
            Debug.Log("Frostfire Lance Skill Activated!");
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


