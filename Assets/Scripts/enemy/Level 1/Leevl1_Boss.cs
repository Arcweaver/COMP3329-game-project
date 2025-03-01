using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Level1_Boss : BossTemplate
{
    //additional stats
    public float standstillTimer = 0;

    //temp skill
    public float skill1Cooldown = 5f; // Cooldown for Skill 1
    public float skill2Cooldown = 3f; // Cooldown for Skill 2
    private float skill1Timer;
    private float skill2Timer;

    private void Start()
    {
        skill1Timer = skill1Cooldown;
        skill2Timer = skill2Cooldown;
        bossMaxHp = 4000;
        bossCurrentHp = 4000;
    }
   

    public override void HandleSkills()
    {
        // Update cooldown timers
        skill1Timer -= Time.deltaTime;
        skill2Timer -= Time.deltaTime;
        standstillTimer -= Time.deltaTime;

        // Use Skill 1 if cooldown is over
        if (skill1Timer <= 0)
        {
            UseSkill1();
            skill1Timer = skill1Cooldown;
            return;
        }

        // Use Skill 2 if cooldown is over
        else if (skill2Timer <= 0)
        {
            UseSkill2();
            skill2Timer = skill2Cooldown;
        }

        //move if standstill is over
        if (standstillTimer <= 0)
        {
            MoveTowardsPlayer();
        }
        
    }




    //temp skills
    private void UseSkill1()
    {
        // Stop moving and perform Skill 1
        Debug.Log("Using Skill 1!");
        // Implement skill effect here
        standstillTimer = 2;
    }

    private void UseSkill2()
    {
        // Perform Skill 2 while moving
        Debug.Log("Using Skill 2!");

        //do nothing
    }
}