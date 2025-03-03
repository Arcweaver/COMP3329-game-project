using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Skill : MonoBehaviour
{
    // Skill properties
    public int id;
    public string skillName;
    public string description;
    public Sprite icon; // skill icon

    // Affix properties
    public int affix = 0; // One of the three affixes. 0 means no affix.
    public string affix1Name;
    public string affix1Description;
    public string affix2Name;
    public string affix2Description;
    public string affix3Name;
    public string affix3Description;

    //generated objects
    public string skillshotPrefabPath = "Prefabs/frostfireLancePrefab";
    public GameObject skillshotPrefab; // The skillshot prefab
    public StatModifier statModifier; // The stat modifier to apply

    // Cooldown properties
    public float cooldown = 3f; // Skill cooldown duration
    public float cooldownTimer;
    public float globalCooldown = 0.5f; // Global cooldown for all skills
    public float globalCooldownTimer; 

    void Start()
    {
        //init the prefabs
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath);
        //timer
        cooldownTimer = 0;
        globalCooldownTimer = 0;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        globalCooldownTimer -= Time.deltaTime;
    }

    // Method to use the skill
    public virtual void UseSkill(Vector3 position, Vector3 direction, UnitTemplate userUnit)
    {
        if (CanUseSkill())
        {
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

            if (skillshotPrefab == null)
            {
                Debug.Log($"Failed to load prefeb for {skillName}!");
            }
        }
        else
        {
            Debug.Log($"{skillName} is on cooldown or during global cooldown.");
        }
    }

    public void TriggerGCD(Vector3 position, Vector3 direction)
    {
        if (CanUseSkill() || Mathf.Max(globalCooldownTimer, cooldownTimer) <= globalCooldown)
        {
            // Start GCD
            globalCooldownTimer = globalCooldown;
        }
        else
        {
            Debug.Log($"{skillName} is on cooldown or during global cooldown.");
        }
    }

    protected bool CanUseSkill()
    {
        return globalCooldownTimer<=0 && cooldownTimer<=0;
    }

    protected virtual void GenerateSkillshot(Vector3 position, Vector3 direction, UnitTemplate userUnit)
    {
        GameObject skillshot = Object.Instantiate(skillshotPrefab, position, Quaternion.identity);
        Skillshot skillshotComponent = skillshot.GetComponent<Skillshot>();
        if (skillshotComponent != null)
        {
            skillshotComponent.Initialize(direction, affix, userUnit);
        }
    }

    //modifier to skill user
    protected virtual void ApplyStatModifier(UnitTemplate userUnit)
    {
        // Logic for applying the stat modifier
        if (statModifier != null)
        {
            userUnit.AddModifier(statModifier);
        }
    }
}


