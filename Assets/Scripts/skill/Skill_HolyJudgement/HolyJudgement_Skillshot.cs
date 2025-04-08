using UnityEngine;

// template skillshot class
public class HolyJudgementSkillshot : Skillshot
{

    private void Start()
    {
        //skill speed
        speed = 100;
        //uncomment this if it is enemy skill
        //opponentTag = "Player" 
    }

    public override void Initialize(Vector3 dir, int affixValue, Skill skill, UnitTemplate userUnit)
    {
        unit = userUnit;
        direction = dir.normalized;
        affix = affixValue;
        sourceSkill = skill;
        Destroy(gameObject, 0.5f); // Destroy skillshot after 5 seconds if it doesn't hit anything
    }

    protected override void SkillEffect(UnitTemplate enemy)
    {
        //get the unit stats to do crit modification/damage amp magic  :)
        UnitStat sourceStat = unit.GetModifiedStats();
        sourceStat.criticalModifier *= 2f; //for example
        CombatParser.CombatParsing(unit, sourceStat, 0, enemy, enemy.GetModifiedStats(), 100);
    }

}
