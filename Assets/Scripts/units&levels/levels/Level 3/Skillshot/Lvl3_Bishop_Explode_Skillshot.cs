using UnityEditor;
using UnityEngine;

public class Lvl3_Bishop_Explode_Skillshot : Skillshot
{
    public int damage = 50;

    private void Start()
    {
        //skill speed
        speed = 0f;

        opponentTag = "Player";
        Destroy(gameObject, 2f);
    }

    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);
    }
}