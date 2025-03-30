using UnityEngine;

// template skillshot class
public class lvl2_SporeBurst_skillshot : Skillshot
{
    public int damage = 15;

    private void Start()
    {
        speed = 130f;

        opponentTag = "Player";
    }



    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);
    }


    }