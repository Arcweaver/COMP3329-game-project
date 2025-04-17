using UnityEngine;

public class Lvl3_Purge_Hammer_Skillshot : Skillshot
{
    public int damage = 5;

    private void Start()
    {
        //skill speed
        speed = 20f;

        opponentTag = "Player";
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);
    }
}