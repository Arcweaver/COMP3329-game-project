using UnityEngine;

public class Lvl3_HolyNova_Ground_Skillshot : Skillshot
{
    public float hitTimer;
    public float durationTimer;
    public int damageAmp;
    public int damage = 1;


    private void Start()
    {
        //skill speed
        speed = 0f;

        opponentTag = "Player";

        //skill persists for indication. Triggers hit on timer expiration
        hitTimer = 1f;
        durationTimer = 4f;
        damageAmp = 1;
    }

    void Update()
    {
        //update timer
        durationTimer -= Time.deltaTime;

        //collision check and destroy skillshot
        //might need sprite change for "shooting" the skill?
        if (durationTimer < 0f)
        {
            Destroy(gameObject);
        }
    }


    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage * damageAmp);
    }

    // Collision check
    void OnTriggerStay2D(Collider2D obj)
    {
        //update timer
        hitTimer -= Time.deltaTime;

        if (obj.name == "player" && hitTimer - Time.deltaTime < 0f)
        {
            UnitTemplate playerUnit = obj.GetComponent<UnitTemplate>();
            SkillEffect(playerUnit);
            damageAmp += 1;
            hitTimer = 1f;
        }
    }

    //override to avoid unintended behaviour
    void OnTriggerEnter2D(Collider2D obj)
    { 
        
    }
}