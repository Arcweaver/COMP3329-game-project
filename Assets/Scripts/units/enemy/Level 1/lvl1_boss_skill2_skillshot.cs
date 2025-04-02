using UnityEngine;

// template skillshot class
public class lvl1_boss_skill2_skillshot : Skillshot
{
    private GameObjectiveTracker tracker;
    public int damage = 20;

    private void Start()
    {
        speed = 200f;

        opponentTag = "Player";

        tracker = FindObjectOfType<GameObjectiveTracker>();
    }



    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);

        if (tracker != null)
        {
            tracker.BossHitsPlayer();
        }
    }


    }