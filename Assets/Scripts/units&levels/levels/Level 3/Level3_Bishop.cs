using UnityEngine;

public class Level3_Bishop : Level3_Guard
{
    //skills
    private Skill skill_Bishop_HolyLight;
    private Transform boss;

    private void Start()
    {
        maxHealth = defaultMaxHealth;
        currentHealth = maxHealth;
        moveSpeed = defaultMovespeed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.Find("boss_3").transform;

        //set the skills
        skill_Bishop_HolyLight = new Lvl3_Skill_Bishop_HolyLight();

        //sprite and animator
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        if (currentHealth <= 0 && deathCount >= 1) Destroy(gameObject);
        if (currentHealth <= 0) return;
        CallOnUpdate();
        HandleSkills();

        // Update cooldown
        skill_Bishop_HolyLight.UpdateCooldown();
    }
   
    //boss actions
    public override void HandleSkills()
    {
        if (Vector3.Distance(player.position, transform.position) <= melee_distance && skill_Bishop_HolyLight.cooldownTimer <= 0 && CanUseOtherSkill())
        {
            skill_Bishop_HolyLight.UseSkill(transform.position, (boss.position - transform.position).normalized, this);
            Debug.Log("Bishop Holy Light");
        }
        //move towards player if no skill to use
        MoveTowards(melee_distance, 50f, boss);
    }

    //put all the global cooldown check here
    private bool CanUseOtherSkill()
    {
        return skill_Bishop_HolyLight.globalCooldownTimer <= 0;
    }

}