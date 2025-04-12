using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class Level3_Boss : BossTemplate
{
    //additional stats
    public int defaultMaxHealth = 4000;
    public int defaultMovespeed = 70;

    //skills
    private Skill skill_Smite, skill_CallGuard;

    //custom timer & controller variable
    public float skill_interval = 3.0f;


    private void Start()
    {
        maxHealth = defaultMaxHealth;
        currentHealth = maxHealth;
        moveSpeed = defaultMovespeed;

        //set the skills
        skill_Smite = new Lvl3_Skill_Smite();
        skill_CallGuard = new Lvl3_Skill_CallGuard();

        //if you want to disable movement on game start, make a stat modifier and perform modifier appending here
        //AddModifier(yourModifier);

        //sprite and animator
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        CallOnUpdate();
        HandleSkills();

        // Update cooldown
        skill_Smite.UpdateCooldown();
        skill_CallGuard.UpdateCooldown();
    }
   
    //boss actions
    public override void HandleSkills()
    {
        //action timer
        skill_interval -= Time.deltaTime;

        //ability sequence
        if (skill_interval <= 0)
        {
            // Smite
            if (skill_Smite.cooldownTimer <= 0 && CanUseOtherSkill())
            {
                skill_Smite.UseSkill(player.position, (player.position - transform.position).normalized, this);
                Debug.Log("Smite");
                skill_interval = 2.0f;
            }

            // Call guard
            if (skill_CallGuard.cooldownTimer <= 0 && CanUseOtherSkill())
            {
                skill_CallGuard.UseSkill(transform.position, (player.position - transform.position).normalized, this);
                Debug.Log("Call guard");
                skill_interval = 5.0f;
            }

            return;
        }
    }



    //put all the global cooldown check here
    private Boolean CanUseOtherSkill()
    {
        return skill_Smite.globalCooldownTimer <= 0 && skill_CallGuard.globalCooldownTimer <= 0;
    }

}