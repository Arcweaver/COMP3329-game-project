using UnityEngine;

public class Lvl3_AshenHollow_Skillshot : Skillshot
{
    public int damage = 2000;

    private void Start()
    {
        //skill speed
        speed = 0f;

        opponentTag = "Player";
    }

    void Update()
    {
        
    }

    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);
    }


    // Collision check
    void OnTriggerEnter2D(Collider2D obj)
    { 
        if (obj.name == "player")
        {
            UnitTemplate playerUnit = obj.GetComponent<UnitTemplate>();
            SkillEffect(playerUnit);
        }
    }
}