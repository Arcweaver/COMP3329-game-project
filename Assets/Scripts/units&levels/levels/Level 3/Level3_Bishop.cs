using UnityEngine;

public class Level3_Bishop : Level3_Guard
{
    //skills
    private Skill skill_Bishop_HolyLight, skill_Bishop_Explode;
    private Transform boss;
    private float explode_distance;
    private float explodeTimer;

    [System.Obsolete]
    private void Start()
    {
        maxHealth = defaultMaxHealth;
        currentHealth = maxHealth;
        moveSpeed = defaultMovespeed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.Find("boss_3").transform;
        tracker = FindObjectOfType<Lvl3_ObjTracker>();
        melee_distance = 100f;
        explode_distance = 80f;
        explodeTimer = 15f;
        killTimer = 10f;

        //set the skills
        skill_Bishop_HolyLight = new Lvl3_Skill_Bishop_HolyLight();
        skill_Bishop_Explode = new Lvl3_Skill_Bishop_Explode();

        //sprite and animator
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();

    }

    // Update cooldown
    public override void UpdateCooldown()
    {
        skill_Bishop_HolyLight.UpdateCooldown();
    }
   
    //boss actions
    public override void HandleSkills()
    {
        // Explode when revive
        if (deathCount == 1)
        {
            explodeTimer -= Time.deltaTime;
            if (explodeTimer <= 0)
            {
                skill_Bishop_Explode.UseSkill(transform.position, (boss.position - transform.position).normalized, this);
                tracker.isBishopExplode = true;
                Destroy(gameObject);
            }
            MoveTowards(explode_distance, 160f, player);
        }
        // Heal boss
        else
        {
            if (Vector3.Distance(boss.position, transform.position) <= melee_distance && skill_Bishop_HolyLight.cooldownTimer <= 0 && CanUseOtherSkill())
            {
                skill_Bishop_HolyLight.UseSkill(transform.position, (boss.position - transform.position).normalized, this);
                Debug.Log("Bishop Holy Light");
                animator.SetBool("isAttack", true);
            }
            //move towards boss to heal
            MoveTowards(melee_distance, 160f, boss);
        }

        
    }

    // Kill the unit
    public override void Kill()
    {
        if (deathCount >= 1) Destroy(gameObject, 2f);
    }

    //put all the global cooldown check here
    private bool CanUseOtherSkill()
    {
        return skill_Bishop_HolyLight.globalCooldownTimer <= 0;
    }

}