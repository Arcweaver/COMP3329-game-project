using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class Level3_Guard : BossTemplate
{
    //additional stats
    public int defaultMaxHealth = 100;
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
        CallOnUpdate();
        if (currentHealth <= 0) 
        {
            animator.SetBool("isDead", true);
            RemoveAllModifier();
            Kill();
        }
        else HandleSkills();
        
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
            animator.SetBool("isAttack", true);
        }
        //move towards player if no skill to use
        MoveTowardsPlayer(melee_distance, 160f);
    }

    // Revive the corpse
    public void Revive()
    {
        if (currentHealth > 0) return;
        currentHealth = maxHealth;
        deathCount++;
        RemoveAllModifier();
        animator.SetBool("isDead", false);
        animator.SetBool("isAttack", false);
    }

    // Apply speed buff
    public void ApplySpeedBuff()
    {
        AddModifier(new Lvl3_Guard_Speed_Modifer(1));
    }

    // Kill the unit
    public virtual void Kill()
    {
        if (deathCount >= 1) Destroy(gameObject, 1f);
    }

    //put all the global cooldown check here
    private Boolean CanUseOtherSkill()
    {
        return skill_Guard_BasicAttack.globalCooldownTimer <= 0;
    }
}