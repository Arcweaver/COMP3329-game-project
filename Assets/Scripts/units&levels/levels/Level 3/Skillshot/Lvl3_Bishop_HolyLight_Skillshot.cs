using UnityEditor;
using UnityEngine;

public class Lvl3_Guard_Holy_Skillshot : Skillshot
{
    public float hitTimer;
    public int damage;
    private Lvl3_ObjTracker tracker;

    [System.Obsolete]
    private void Start()
    {
        //skill speed
        speed = 0f;
        damage = -200;
        tracker = FindObjectOfType<Lvl3_ObjTracker>();

        opponentTag = "Player";

        //skill persists for indication. Triggers hit on timer expiration
        hitTimer = 10f;
    }

    void Update()
    {//orientation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Destory this skillshot when caster is dead
        if (unit.currentHealth <= 0) Destroy(gameObject);

        //update timer
        hitTimer -= Time.deltaTime;

        //collision check and destroy skillshot
        //might need sprite change for "shooting" the skill?
        if (hitTimer < 0f)
        {
            GameObject boss = GameObject.Find("boss_3");
            UnitTemplate bossUnit = boss.GetComponent<UnitTemplate>();
            SkillEffect(bossUnit);
            Destroy(gameObject);
        }
    }

    protected override void SkillEffect(UnitTemplate enemy)
    {
        CombatParser.CombatParsing(unit, unit.GetModifiedStats(), 0, enemy, enemy.GetModifiedStats(), damage);
        tracker.isHealBoss = true;
    }

    //override to avoid unintended behaviour
    void OnTriggerEnter2D(Collider2D obj)
    { }

}