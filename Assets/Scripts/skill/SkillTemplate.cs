using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Skill
{
    // Skill properties
    public int id;
    public string name;
    public string description;
    public Sprite icon; // Assuming you are using Unity's Sprite for icons

    // Affix properties
    public int affix; // One of the three affixes. 0 means no affix.
    public GameObject skillshotPrefab; // The skillshot prefab
    public StatModifier statModifier; // The stat modifier to apply

    // Cooldown properties
    public float cooldown; // Skill cooldown duration
    private float cooldownTimer; 
    private float globalCooldown = 0.5f; // Global cooldown for all skills
    private float globalCooldownTimer; 

    void Start()
    {
        cooldownTimer = 0;
        globalCooldownTimer = 0;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        globalCooldownTimer -= Time.deltaTime;
    }

    // Method to use the skill
    public void UseSkill(Vector3 position, Vector3 direction)
    {
        if (CanUseSkill())
        {
            // Start GCD
            globalCooldownTimer = globalCooldown;

            // Generate skillshot if applicable
            if (skillshotPrefab != null)
            {
                GenerateSkillshot(position, direction);
            }

            // Apply stat modifier if applicable
            if (statModifier != null)
            {
                ApplyStatModifier();
            }

            // Set the next use time for the skill based on cooldown
            cooldownTimer = cooldown;
        }
        else
        {
            Debug.Log($"{name} is on cooldown or during global cooldown.");
        }
    }

    public void TriggerGCD(Vector3 position, Vector3 direction)
    {
        if (CanUseSkill())
        {
            // Start GCD
            globalCooldownTimer = globalCooldown;
        }
        else
        {
            Debug.Log($"{name} is on cooldown or during global cooldown.");
        }
    }

    protected bool CanUseSkill()
    {
        return globalCooldownTimer<=0 && cooldownTimer<=0;
    }

    protected virtual void GenerateSkillshot(Vector3 position, Vector3 direction)
    {
        GameObject skillshot = Object.Instantiate(skillshotPrefab, position, Quaternion.identity);
        Skillshot skillshotComponent = skillshot.GetComponent<Skillshot>();
        if (skillshotComponent != null)
        {
            skillshotComponent.Initialize(direction, affix);
        }
    }

    protected virtual void ApplyStatModifier()
    {
        // Logic for applying the stat modifier
        if (statModifier != null)
        {
            statModifier.Apply();
        }
    }
}


