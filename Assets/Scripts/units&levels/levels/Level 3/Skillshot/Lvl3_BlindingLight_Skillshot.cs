using UnityEngine;

public class Lvl3_BlindingLight_Skillshot : Skillshot
{
    public float hitTimer;
    public int damage = 30;


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
        //orientation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

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
        enemy.AddModifier(new Lvl3_BlindingLight_Speed_Modifer(2f));
    }

    // Collision check
    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.name == "player" && hitTimer - Time.deltaTime < 0f)
        {
            PlayerController playerUnit = obj.GetComponent<PlayerController>();
            if (playerUnit.moveInput != Vector2.zero) SkillEffect(playerUnit);
        }
    }

    //override to avoid unintended behaviour
    void OnTriggerEnter2D(Collider2D obj)
    { 
        
    }
}