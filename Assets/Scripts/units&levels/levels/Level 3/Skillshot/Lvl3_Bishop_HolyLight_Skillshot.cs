using UnityEditor;
using UnityEngine;

public class Lvl3_Guard_Holy_Skillshot : Skillshot
{
    public float hitTimer;
    public int damage = -30;

    private void Start()
    {
        //skill speed
        speed = 0f;

        opponentTag = "Player";

        //skill persists for indication. Triggers hit on timer expiration
        hitTimer = 10f;
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
            CheckBossInZone();
            Destroy(gameObject);
        }
    }

    //collision check
    private void CheckBossInZone()
    {
        // Find the player GameObject
        GameObject boss = GameObject.Find("boss_3");

        if (boss != null)
        {
            // Check if the player is within the bounds of the collider
            Collider2D bossCollider = boss.GetComponent<Collider2D>();
            if (bossCollider != null && GetComponent<Collider2D>().IsTouching(bossCollider))
            {
                UnitTemplate bossUnit = boss.GetComponent<UnitTemplate>();
                SkillEffect(bossUnit);
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