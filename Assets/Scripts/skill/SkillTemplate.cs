using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Skill
{
    // Skill properties
    public int id;
    public string skillName;
    public string description;
    public string iconPath = "???";
    public Sprite icon; // skill icon
    public float staminaCost = 0f;

    // Affix properties
    public int affix = 0; // One of the three affixes. 0 means no affix.
    public string affix1Name;
    public string affix1Description;
    public string affix2Name;
    public string affix2Description;
    public string affix3Name;
    public string affix3Description;

    //generated objects
    public string skillshotPrefabPath;
    public GameObject skillshotPrefab; // The skillshot prefab
    public StatModifier statModifier; // The stat modifier to apply

    // Cooldown properties
    public float cooldown = 3f; // Skill cooldown duration
    public float cooldownTimer = 0;
    public float globalCooldown = 0.5f; // Global cooldown for all skills
    public float globalCooldownTimer = 0; 

    public Skill()
    {
        //init the prefabs
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath);

        //timer
        cooldownTimer = 0;
        globalCooldownTimer = 0;
    }

    public void UpdateCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        globalCooldownTimer -= Time.deltaTime;
    }

    // Method to use the skill
    public virtual void UseSkill(Vector3 position, Vector3 direction, UnitTemplate userUnit)
    {
        if (CanUseSkill() && userUnit.Stamina >= staminaCost)
        {
            //use stamina
            userUnit.Stamina -= staminaCost;

            // Generate skillshot if applicable
            if (skillshotPrefab != null)
            {
                GenerateSkillshot(position, direction, userUnit);
            }

            // Apply stat modifier to the user if applicable
            if (statModifier != null)
            {
                ApplyStatModifier(userUnit);
            }

            // Start GCD
            globalCooldownTimer = globalCooldown;
            // Set the next use time for the skill based on cooldown
            cooldownTimer = cooldown;
            //also trigger other skill's gcd
            //userUnit.triggerGCD();

            // null logging
            //if (skillshotPrefab == null)
            //{
            //    Debug.Log($"Failed to load prefeb for {skillName}!");
            //}
            //if (statModifier == null)
            //{
            //    Debug.Log($"Failed to load the stat modifier for {skillName}!");
            //}
        }
        else
        {
            Debug.Log($"{skillName} is on cooldown or during global cooldown. Cooldown: {cooldownTimer}, Global cooldown: {globalCooldownTimer}");
        }
    }

    public void TriggerGCD()
    {
        if (CanUseSkill() || Mathf.Max(globalCooldownTimer, cooldownTimer) <= globalCooldown)
        {
            // Start GCD
            globalCooldownTimer = globalCooldown;
        }
        else
        {
            Debug.Log($"{skillName} is already on cooldown/global cooldown.");
        }
    }

    public bool CanUseSkill() // I change it from protected to public (elsa)
    {
        return globalCooldownTimer<=0 && cooldownTimer<=0;
    }

    protected virtual void GenerateSkillshot(Vector3 position, Vector3 direction, UnitTemplate userUnit)
    {
        GameObject skillshot = Object.Instantiate(skillshotPrefab, position, Quaternion.identity);
        Skillshot skillshotComponent = skillshot.GetComponent<Skillshot>();
        if (skillshotComponent != null)
        {
            skillshotComponent.Initialize(direction, affix, this, userUnit);
        }
    }

    //modifier to skill user
    protected virtual void ApplyStatModifier(UnitTemplate userUnit)
    {
        ApplyStatModifier(statModifier, userUnit);
    }

    protected virtual void ApplyStatModifier(StatModifier modifier, UnitTemplate userUnit)
    {
        // Logic for applying the stat modifier
        if (modifier != null)
        {
            modifier.StartModifier();
            modifier.ApplyEffect(userUnit);
            userUnit.AddModifier(modifier);
        }
    }

    public void changeAffix(int newAffix)
    {
        if (newAffix >=0 &&  newAffix <= 3) affix = newAffix;
    }
}


