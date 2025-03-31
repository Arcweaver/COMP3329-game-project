using UnityEngine;

public class HolyJudgement : Skill
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
}
