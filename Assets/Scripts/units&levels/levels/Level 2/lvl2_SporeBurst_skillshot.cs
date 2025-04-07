using UnityEngine;

// template skillshot class
public class lvl2_SporeBurst_skillshot : Skillshot
{
    public int damage = 15;
    private lvl2_ObjTracker tracker;

    [System.Obsolete]
    private void Start()
    {
        speed = 130f;

        opponentTag = "Player";

        tracker = FindObjectOfType<lvl2_ObjTracker>();
    }



    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);
        tracker.isHitBySpore = true;
    }


    }