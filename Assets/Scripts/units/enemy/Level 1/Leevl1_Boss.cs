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


    private void Start()
    {
        maxHealth = defaultMaxHealth;
        currentHealth = maxHealth;
        moveSpeed = defaultMovespeed;

        //set the skills
        GameObject skill1Object = new GameObject("_skill");
        skill_RockBeam = skill1Object.AddComponent<Lvl1_Boss_Skill1>();
        skill_Bullet = skill1Object.AddComponent<Lvl1_Boss_Skill2>();

        
        //if you want to disable movement on game start, make a stat modifier and perform modifier appending here
        //AddModifier(yourModifier);

    }
   
    //boss actions
    public override void HandleSkills()
    {
        // Use Skill 1 if cooldown is over
        if (skill_RockBeam.cooldownTimer <= 0 && CanUseOtherSkill())
        {
            skill_RockBeam.UseSkill(transform.position, (player.position - transform.position).normalized, this);
        }

        // Use Skill 2 if cooldown is over
        else if (skill_Bullet.cooldownTimer <= 0 && CanUseOtherSkill())
        {
            skill_Bullet.UseSkill(transform.position, (player.position - transform.position).normalized, this);
        }

        //move towards player if no skill to use
        MoveTowardsPlayer();
        
    }



    //put all the global cooldown check here
    private Boolean CanUseOtherSkill()
    {
        return skill_RockBeam.globalCooldownTimer <= 0 && skill_Bullet.globalCooldownTimer <= 0;
    }

}