using UnityEditor;
using UnityEngine;

public class Lvl3_Guard_BasicAttack_Skillshot : Skillshot
{
    public float hitTimer;
    public int damage = 20;

    private void Start()
    {
        //skill speed
        speed = 0f;

        opponentTag = "Player";

        //skill persists for indication. Triggers hit on timer expiration
        hitTimer = 0.7f * 1.7f;
    }

    void Update()
    {//orientation
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
                return;
            }
        }
    }




    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);
    }



    //override to avoid unintended behaviour
    void OnTriggerEnter2D(Collider2D obj)
    { }

}