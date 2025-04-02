using UnityEngine;

public class HolyJudgement : Skill, ISkill
{
    public HolyJudgement()
    {
        //skill description
        id = 3;
        skillName = "HolyJudgement";
        description = "Smite enemies in front of you, dealing 100 damage. Deals 100% increased critical damage.";

        //load icon
        iconPath = "Icon/HolyJudgement";
        icon = Resources.Load<Sprite>(iconPath);

        //load prefab
        skillshotPrefabPath = "Prefabs/HolyJudgementPrefab";
        skillshotPrefab = Resources.Load<GameObject>(skillshotPrefabPath);

        //cooldown
        cooldown = 3f;
        staminaCost = 5f;

        //timers
        cooldownTimer = 0;
        globalCooldownTimer = 0;

    }

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
            Debug.Log("Holy Judgement Skill Activated!");
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
