using UnityEngine;

// template skillshot class
public class FrostfireLanceSkillshot : Skillshot
{

    private void Start()
    {
        //skill speed
        speed = 200f;
        //uncomment this if it is enemy skill
        //opponentTag = "Player" 
    }



    protected override void SkillEffect(EnemyTemplate enemy)
    {
        //get the unit stats to do crit modification/damage amp magic  :)
        //UnitStat sourceStat = unit.GetModifiedStats();
        //sourceStat.criticalModifier = 3f; //for example
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), 135);
    }

}
