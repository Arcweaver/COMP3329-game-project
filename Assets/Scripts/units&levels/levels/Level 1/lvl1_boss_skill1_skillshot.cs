using UnityEngine;

// template skillshot class
public class lvl1_boss_skill1_skillshot : Skillshot
{
    public float hitTimer;
    public int damage = 20;
    private lvl1_ObjTracker tracker;

    [System.Obsolete]
    private void Start()
    {
        //skill speed
        speed = 0f;

        opponentTag = "Player";

        //skill persists for indication. Triggers hit on timer expiration
        hitTimer = 2f;

        tracker = FindObjectOfType<lvl1_ObjTracker>();
    }

    void Update()
    {
        //no movement for this case

        //orientation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //update timer
        hitTimer -= Time.deltaTime;

        //collision check and destroy skillshot
        //might need sprite change for "shooting" the skill?
        if (hitTimer < 0f)
        {
            CheckPlayerInZone();
            Destroy(gameObject);
        }
    }

    //collision check
    private void CheckPlayerInZone()
    {
        // Find the player GameObject
        GameObject player = GameObject.FindGameObjectWithTag(opponentTag);

        if (player != null)
        {
            // Check if the player is within the bounds of the collider
            Collider2D playerCollider = player.GetComponent<Collider2D>();
            if (playerCollider != null && GetComponent<Collider2D>().IsTouching(playerCollider))
            {
                UnitTemplate playerUnit = player.GetComponent<UnitTemplate>();
                SkillEffect(playerUnit);
                Debug.Log("Boss skill 1 hit!");
                return;
            }
        }
        Debug.Log("Boss skill 1 miss!");
    }



    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);

        //for testing without boss usage
        //CombatParser.CombatParsing(null, null, 0, enemy, enemy.GetModifiedStats(), damage);

        // Update the objective tracker
        if (tracker != null)
        {
            tracker.isHitBySkill = true;
        }
    }

    

    //override to avoid unintended behaviour
    void OnTriggerEnter2D(Collider2D obj)
    { }

}