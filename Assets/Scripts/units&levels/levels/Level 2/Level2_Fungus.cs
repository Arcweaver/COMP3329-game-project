using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class Level2_Fungus : EnemyTemplate
{
    //additional stats
    public int defaultMaxHealth = 400;
    public int defaultMovespeed = 0;

    //skills
    private Skill skill_SporeBurst;

    //custom timer & controller variable
    public float detonate_timer = 20.0f;
    public bool inactive = false;

    //track
    private lvl2_ObjTracker tracker;

    //sprite tracker
    public Sprite livingSprite;
    public Sprite wiltedSprite;

    [Obsolete]
    private void Start()
    {
        maxHealth = defaultMaxHealth;
        currentHealth = maxHealth;
        moveSpeed = defaultMovespeed;
        player = null;

        //set the skills
        skill_SporeBurst = new Lvl2_Skill_SporeBurst();

        //locate tracker
        tracker = FindObjectOfType<lvl2_ObjTracker>();

        //spawn objective
        tracker.CheckFungiInQuadrant(transform.position);

        //sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = livingSprite;
    }

    void Update()
    {
        CallOnUpdate();
        HandleSkills();

        // Update cooldown
    }
   
    //boss actions
    public override void HandleSkills()
    {
        //action timer
        detonate_timer -= Time.deltaTime;

        if (currentHealth <= 0 && !inactive)
        {
            detonate_timer = 40f;
            inactive = true;
            spriteRenderer.sprite = wiltedSprite;
        }

        if (detonate_timer < 20 && inactive)
        {
            inactive = false;
            currentHealth = maxHealth;
            spriteRenderer.sprite = livingSprite;
        }
        else if (detonate_timer < 0)
        {
            DestroyFungus();
        }
        
    }

    public void DestroyFungus()
    {
        if (!inactive)
        {
            skill_SporeBurst.UseSkill(transform.position, transform.position, this);
            Destroy(gameObject);
            tracker.isNoSelfDetonateFungi = false;
        }
    }

    public void DestroyFungusByBoss()
    {
        Destroy(gameObject);
    }



    //put all the global cooldown check here
    private Boolean CanUseOtherSkill()
    {
        return skill_SporeBurst.globalCooldownTimer <= 0;
    }

}