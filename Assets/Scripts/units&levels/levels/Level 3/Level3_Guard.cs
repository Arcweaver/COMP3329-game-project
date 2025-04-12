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

    // Revive the corpse
    public void Revive()
    {
        if (currentHealth > 0) return;
        currentHealth = maxHealth;
        deathCount++;
    }

    // Apply speed buff
    public void ApplySpeedBuff()
    {
        AddModifier(new Lvl3_Guard_Speed_Modifer(1));
    }

    //put all the global cooldown check here
    private Boolean CanUseOtherSkill()
    {
        return skill_Guard_BasicAttack.globalCooldownTimer <= 0;
    }

}