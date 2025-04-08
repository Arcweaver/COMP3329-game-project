using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class Level1_Boss : BossTemplate
{
    //additional stats
    public int defaultMaxHealth = 4000;
    public int defaultMovespeed = 70;


    //skills
    private Skill skill_RockBeam, skill_Bullet;

    //custom timer
    float biteTimer = 0f;


    private void Start()
    {
        maxHealth = defaultMaxHealth;
        currentHealth = maxHealth;
        moveSpeed = defaultMovespeed;

        //set the skills
        skill_RockBeam = new Lvl1_Boss_Skill1();
        skill_Bullet = new Lvl1_Boss_Skill2();

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
        skill_RockBeam.UpdateCooldown();
        skill_Bullet.UpdateCooldown();
    }
   
    //boss actions
    public override void HandleSkills()
    {
        // Use Skill 1 if cooldown is over
        if (skill_RockBeam.cooldownTimer <= 0 && CanUseOtherSkill())
        {
            animator.SetBool("isSpellAttack", true);
            skill_RockBeam.UseSkill(transform.position, (player.position - transform.position).normalized, this);
        }

        // Use Skill 2 if cooldown is over
        else if (skill_Bullet.cooldownTimer <= 0 && CanUseOtherSkill())
        {
            animator.SetBool("isBiteAttack", true);
            biteTimer = 1f;
            skill_Bullet.UseSkill(transform.position, (player.position - transform.position).normalized, this);
        }

        //move towards player if no skill to use
        MoveTowardsPlayer(60);

        biteTimer -= Time.deltaTime;
        if (biteTimer <= 0)
        {

            animator.SetBool("isBiteAttack", false);

        }

    }



    //put all the global cooldown check here
    private Boolean CanUseOtherSkill()
    {
        return skill_RockBeam.globalCooldownTimer <= 0 && skill_Bullet.globalCooldownTimer <= 0;
    }


    public override void MoveTowardsPlayer(float min_distance)
    {
        if (modifiedStats.moveSpeed != 0)
        {
            if (player != null)
            {
                float distance = Vector3.Distance(player.position, transform.position);
                if (distance < min_distance) { return; }

                Vector3 direction = (player.position - transform.position).normalized;
                //Debug.Log($"Moving towards player at position: {player.position}");
                transform.position += modifiedStats.moveSpeed * Time.deltaTime * direction;

                //update sprite
                if (direction.x > 0)
                {
                    spriteRenderer.transform.localScale = new Vector2(1f, 1f);
                }
                else if (direction.x < 0)
                {
                    spriteRenderer.transform.localScale = new Vector2(-1f, 1f);
                }
            }
            else
            {
                Debug.LogWarning("Player reference is null!");
            }
        }
    }

}