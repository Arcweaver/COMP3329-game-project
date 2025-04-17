using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Level3_Boss : BossTemplate
{
    //additional stats
    public int defaultMaxHealth = 300;
    public int defaultMovespeed = 70;

    //skills
    private Skill skill_Smite, skill_BlindingLight, skill_CallGuard, skill_HolyNova, skill_CallBishop, skill_AshenHollow;

    //custom timer & controller variable
    public float skill_interval = 3.0f;
    public float healthPercent;
    public GameObject guardSpwaner;
    public bool isEnterP3;
    public float melee_distance;


    private void Start()
    {
        maxHealth = defaultMaxHealth;
        currentHealth = maxHealth;
        moveSpeed = defaultMovespeed;
        isEnterP3 = false;
        melee_distance = 60f;

        //set the skills
        skill_Smite = new Lvl3_Skill_Smite();
        skill_BlindingLight = new Lvl3_Skill_BlindingLight();
        skill_CallGuard = new Lvl3_Skill_CallGuard();
        skill_HolyNova = new Lvl3_Skill_HolyNova();
        skill_CallBishop = new Lvl3_Skill_CallBishop();
        skill_AshenHollow = new Lvl3_Skill_AshenHollow();

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
        skill_BlindingLight.UpdateCooldown();
        skill_CallGuard.UpdateCooldown();
        skill_HolyNova.UpdateCooldown();
        skill_CallBishop.UpdateCooldown();
        skill_AshenHollow.UpdateCooldown();
    }
   
    //boss actions
    public override void HandleSkills()
    {
        //action timer
        skill_interval -= Time.deltaTime;
        healthPercent = (float)currentHealth / (float)maxHealth;

        if (skill_interval <= 0)
        {
            OnEnterP3();
            UseAshenHollow();
        }
        if (isEnterP3) MoveTowardsPlayer(melee_distance, 180f);

        //ability sequence
        // if (skill_interval <= 0 && healthPercent > 0.7)
        // {
        //     UseSmite();
        //     UseBlindingLight();
        //     UseCallBishop();
        //     return;
        // }
        // else if (skill_interval <= 0 && healthPercent > 0.3)
        // {
        //     UseSmite();
        //     UseCallGuard();
        //     UseHolyNova();
        //     UseCallBishop();
        //     return;
        // }
        // else if (skill_interval <= 0)
        // {
        //     OnEnterP3();
        //     UseAshenHollow();
        // }
    }

    private void UseSmite()
    {
        if (skill_Smite.cooldownTimer <= 0 && CanUseOtherSkill())
        {
            skill_Smite.UseSkill(player.position, (player.position - transform.position).normalized, this);
            Debug.Log("Smite");
            skill_interval = 2.0f;
            UseCastAnimation();
        }
    }

    private void UseCallGuard()
    {
        
        if (skill_CallGuard.cooldownTimer <= 0 && CanUseOtherSkill())
        {
            skill_CallGuard.UseSkill(GetSpwanPosition(), (player.position - transform.position).normalized, this);
            Debug.Log("Call Guard");
            skill_interval = 5.0f;
            UseCastAnimation();
        }
    }

    private void UseHolyNova()
    {
        if (skill_HolyNova.cooldownTimer <= 0 && CanUseOtherSkill())
        {
            skill_HolyNova.UseSkill(transform.position, (player.position - transform.position).normalized, this);
            Debug.Log("Holy Nova");
            skill_interval = 2.0f;
            UseCastAnimation();
        }
    }

    private void UseCallBishop()
    {
        if (skill_CallBishop.cooldownTimer <= 0 && CanUseOtherSkill())
        {
            skill_CallBishop.UseSkill(GetSpwanPosition(), (player.position - transform.position).normalized, this);
            Debug.Log("Call Bishop");
            skill_interval = 5.0f;
            UseCastAnimation();
        }
    }

    private void UseBlindingLight()
    {
        if (skill_BlindingLight.cooldownTimer <= 0 && CanUseOtherSkill())
        {
            skill_BlindingLight.UseSkill(transform.position, (player.position - transform.position).normalized, this);
            Debug.Log("Blinding Light");
            skill_interval = 3.0f;
            UseCastAnimation();
        }
    }

    private void UseAshenHollow()
    {
        if (skill_AshenHollow.cooldownTimer <= 0 && CanUseOtherSkill())
        {
            skill_AshenHollow.UseSkill(transform.position, (player.position - transform.position).normalized, this);
            Debug.Log("Ashen Hollow");
            skill_interval = 3.0f;
            UseCastAnimation();
        }
    }

    // Get spwan point for guards
    private Vector2 GetSpwanPosition()
    {
        Collider2D spwanCollider = guardSpwaner.GetComponent<Collider2D>();
        float s = spwanCollider.bounds.size.x / 2;
        float x1 = guardSpwaner.transform.position.x - s;
        float x2 = guardSpwaner.transform.position.x + s;
        float y1 = guardSpwaner.transform.position.y - s;
        float y2 = guardSpwaner.transform.position.y + s;
        Vector2 spawnPoint = new (Random.Range(x1, x2), Random.Range(y1, y2));
        return spawnPoint;
    }

    // Start the cast animation
    private void UseCastAnimation()
    {
        animator.SetBool("isCast", true);
    }

    // Clear other enemy when enter p3
    private void OnEnterP3()
    {
        if (!isEnterP3)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (enemy.name != "boss_3") Destroy(enemy);
            }
            animator.SetBool("isRun", true);
            isEnterP3 = true;
        }
    }

    //put all the global cooldown check here
    private bool CanUseOtherSkill()
    {
        return skill_AshenHollow.globalCooldownTimer <= 0 && skill_Smite.globalCooldownTimer <= 0 && skill_BlindingLight.globalCooldownTimer <= 0 && skill_CallGuard.globalCooldownTimer <= 0 && skill_HolyNova.globalCooldownTimer <= 0;
    }

}