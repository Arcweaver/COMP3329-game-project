using UnityEngine;

public class Lvl3_Smite_Skillshot : Skillshot
{
    public float hitTimer;
    public int damage = 20;

    private void Start()
    {
        //skill speed
        speed = 0f;

        opponentTag = "Player";

        //skill persists for indication. Triggers hit on timer expiration
        hitTimer = 3f;
    }

    void Update()
    {
        //update timer
        hitTimer -= Time.deltaTime;

        //collision check and destroy skillshot
        //might need sprite change for "shooting" the skill?
        if (hitTimer < 0f)
        {
            Destroy(gameObject);
        }
    }

    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);
    }

    // Collision check
    void OnTriggerStay2D(Collider2D obj)
    {
        Debug.Log(hitTimer);
        if (obj.name == "player" && hitTimer - Time.deltaTime < 0f)
        {
            UnitTemplate playerUnit = obj.GetComponent<UnitTemplate>();
            SkillEffect(playerUnit);
        }
    }

    //override to avoid unintended behaviour
    void OnTriggerEnter2D(Collider2D obj)
    { }
}