using UnityEngine;

public class Lvl3_AshenHollow_Skillshot : Skillshot
{
    public int damage = 2000;
    public float activeTimer;

    private void Start()
    {
        //skill speed
        speed = 0f;

        opponentTag = "Player";

        //custom timer
        activeTimer = 2f;
    }

    void Update()
    {
        if (activeTimer > 0f)
        {
            activeTimer -= Time.deltaTime;
        }
    }

    protected override void SkillEffect(UnitTemplate enemy)
    {
        if ( activeTimer <= 0)
        {
            CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);
        }
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