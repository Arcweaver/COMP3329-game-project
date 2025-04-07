using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class Level2_Boss : BossTemplate
{
    //additional stats
    public int defaultMaxHealth = 4000;
    public int defaultMovespeed = 70;

    //skills
    private Skill skill_SpawnFungus, skill_InfectedSmash, skill_BasicAttack;

    //custom timer & controller variable
    public float melee_distance = 60f;
    public float skill_interval = 8.0f;


    private void Start()
    {
        maxHealth = defaultMaxHealth;
        currentHealth = maxHealth;
        moveSpeed = defaultMovespeed;

        //set the skills
        skill_SpawnFungus = new Lvl2_Skill_SpawnFungus();
        skill_InfectedSmash = new Lvl2_Skill_InfectedSmash();
        skill_BasicAttack =  new Lvl2_Skill_BasicAttack();

        //if you want to disable movement on game start, make a stat modifier and perform modifier appending here
        //AddModifier(yourModifier);

    }

    void Update()
    {
        CallOnUpdate();
        HandleSkills();

        // Update cooldown
        skill_SpawnFungus.UpdateCooldown();
        skill_InfectedSmash.UpdateCooldown();
        skill_BasicAttack.UpdateCooldown();
    }
   
    //boss actions
    public override void HandleSkills()
    {
        //action timer
        skill_interval -= Time.deltaTime;

        //ability sequence
        if (skill_interval <= 0)
        {
            // spawn fungus
            if (skill_SpawnFungus.cooldownTimer <= 0 && CanUseOtherSkill())
            {
                skill_SpawnFungus.UseSkill(transform.position, (player.position - transform.position).normalized, this);
                Debug.Log("Spawn Fungus");
                skill_interval = 5.0f;
            }

            // big smash
            else if (skill_InfectedSmash.cooldownTimer <= 0 && CanUseOtherSkill())
            {
                skill_InfectedSmash.UseSkill(transform.position, (player.position - transform.position).normalized, this);
                Debug.Log("Infected Smash");
                skill_interval = 10.0f;
            }

            return;
        }

        
        if (Vector3.Distance(player.position, transform.position) <= melee_distance && CanUseOtherSkill())
        {
            skill_BasicAttack.UseSkill(transform.position, (player.position - transform.position).normalized, this);
            Debug.Log("Boss basic attack");
        }
        //move towards player if no skill to use
        MoveTowardsPlayer(melee_distance);
        
    }



    //put all the global cooldown check here
    private Boolean CanUseOtherSkill()
    {
        return skill_SpawnFungus.globalCooldownTimer <= 0 && skill_InfectedSmash.globalCooldownTimer <= 0 && skill_BasicAttack.globalCooldownTimer <= 0;
    }

}