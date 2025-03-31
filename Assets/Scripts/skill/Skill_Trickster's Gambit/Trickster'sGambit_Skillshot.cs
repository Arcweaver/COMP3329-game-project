using UnityEngine;

// template skillshot class
public class TrickstersGambitSkillshot : Skillshot
{
    public int damage = 0;

    private void Start()
    {
        //skill speed
        speed = 200f;
        //uncomment this if it is enemy skill
        //opponentTag = "Player" 
    }



    protected override void SkillEffect(UnitTemplate enemy)
    {
        //get the unit stats to do crit modification/damage amp magic  :)
        //UnitStat sourceStat = unit.GetModifiedStats();
        //sourceStat.criticalModifier = 3f; //for example
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);
    }

}
