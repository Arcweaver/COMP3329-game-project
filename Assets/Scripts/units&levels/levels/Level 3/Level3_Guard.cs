using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class Level3_Guard : BossTemplate
{
    //additional stats
    public int defaultMaxHealth = 40;
    public int defaultMovespeed = 70;

    //skills
    private Skill skill_Guard_BasicAttack;

    //custom timer & controller variable
     public float melee_distance = 60f;
     public float deathCount = 0;

    private void Start()
    {
        maxHealth = defaultMaxHealth;
        currentHealth = maxHealth;
        moveSpeed = defaultMovespeed;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //set the skills
        skill_Guard_BasicAttack = new Lvl3_Skill_Gurad_BasicAttack();

        //if you want to disable movement on game start, make a stat modifier and perform modifier appending here
        //AddModifier(yourModifier);

        //sprite and animator
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        if (deathCount == 1) return;
        CallOnUpdate();
        HandleSkills();
        CheckDeath();

        // Update cooldown
        skill_Guard_BasicAttack.UpdateCooldown();
    }
   
    //boss actions
    public override void HandleSkills()
    {
        if (Vector3.Distance(player.position, transform.position) <= melee_distance && skill_Guard_BasicAttack.cooldownTimer <= 0 && CanUseOtherSkill())
        {
            skill_Guard_BasicAttack.UseSkill(transform.position, (player.position - transform.position).normalized, this);
            Debug.Log("Guard basic attack");
        }
        //move towards player if no skill to use
        MoveTowardsPlayer(melee_distance, 50f);
    }

    // Increacse death counter if no health
    private void CheckDeath()
    {
        if (currentHealth <= 0) deathCount++;
    }

    //put all the global cooldown check here
    private Boolean CanUseOtherSkill()
    {
        return skill_Guard_BasicAttack.globalCooldownTimer <= 0;
    }

}