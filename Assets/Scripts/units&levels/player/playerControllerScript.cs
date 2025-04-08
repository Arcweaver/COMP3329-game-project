using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : UnitTemplate
{
    private Vector2 moveInput; 
    public Skill skill1, skill2, skill3, skill4;
    private Skill weaponAttack;
    public Rigidbody2D rb;
    

    void Start()
    {
        //default stat modification here

        currentHealth = maxHealth;

        //assign the selected skills and weapons (need manager to replace this)
        skill1 = StaticData.selectedSkills[0];
        skill2 = StaticData.selectedSkills[1];
        skill3 = StaticData.selectedSkills[2];
        skill4 = StaticData.selectedSkills[3];
        weaponAttack = new WeaponSkill();

        rb = GetComponent<Rigidbody2D>();

        //sprite
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        // Get animator
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Get movement input
        moveInput.x = Input.GetAxis("Horizontal"); // x dir movement
        moveInput.y = Input.GetAxis("Vertical");   // y dir movement

        //modifier update
        CallOnUpdate();

        // Move the character
        MoveCharacter(moveInput);

        // Check for skill casting
        CheckSkillCasting();

        // Check for basic attack
        CheckBasicAttack();

        // Update skills
        skill1.UpdateCooldown();
        skill2.UpdateCooldown();
        skill3.UpdateCooldown();
        skill4.UpdateCooldown();
        weaponAttack.UpdateCooldown();
    }

    //private void MoveCharacter(Vector2 direction)
    //{
    //    if (modifiedStats.moveSpeed != 0){
    //        if (Input.GetKey(KeyCode.Space))
    //        {
    //            // Move without changing direction
    //            Vector2 newPosition = (Vector2)transform.position + direction * modifiedStats.moveSpeed * Time.deltaTime;
    //            transform.position = newPosition;
    //        }
    //        else
    //        {
    //            if (direction != Vector2.zero)
    //            {
    //                Vector2 newPosition = (Vector2)transform.position + direction * modifiedStats.moveSpeed * Time.deltaTime;
    //                transform.position = newPosition;
    
    //                // Calculate the angle based on the movement direction
    //                //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
    //                //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    
    //                // Walk animation
    //                animator.SetBool("isWalking", true);
    //                animator.SetFloat("InputX", direction.x);
    //                animator.SetFloat("InputY", direction.y);
    //                animator.SetFloat("LastInputX", direction.x);
    //                animator.SetFloat("LastInputY", direction.y);
    //                if(direction.x > 0)
    //                {
    //                    spriteRenderer.transform.localScale = new Vector2(150f, 150f);
    //                } else if(direction.x < 0)
    //                {
    //                    spriteRenderer.transform.localScale = new Vector2(-150f, 150f);
    //                }
    //            }
    //            else animator.SetBool("isWalking", false);
    //        }
    //    }
    //}



    private void MoveCharacter(Vector2 direction)
    {
        if (modifiedStats.moveSpeed != 0)
        {
            Vector2 movement = direction.normalized * modifiedStats.moveSpeed; // Calculate movement vector
            rb.linearVelocity = movement; // Use Rigidbody2D to move the player

            // Handle animations and sprite flipping as before
            if (direction != Vector2.zero)
            {
                animator.SetBool("isWalking", true);
                animator.SetFloat("InputX", direction.x);
                animator.SetFloat("InputY", direction.y);
                animator.SetFloat("LastInputX", direction.x);
                animator.SetFloat("LastInputY", direction.y);

                // Flip sprite based on direction
                if (direction.x > 0)
                {
                    spriteRenderer.transform.localScale = new Vector2(150f, 150f);
                }
                else if (direction.x < 0)
                {
                    spriteRenderer.transform.localScale = new Vector2(-150f, 150f);
                }
            }
            else
            {
                animator.SetBool("isWalking", false);
                rb.linearVelocity = Vector2.zero; // Stop movement when no input
            }
        }
    }


    private void CheckSkillCasting()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            skill1.UseSkill(transform.position, GetDirectionToMouse(), this);
            TriggerSkillGCD();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            skill2.UseSkill(transform.position, GetDirectionToMouse(), this);
            TriggerSkillGCD();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            skill3.UseSkill(transform.position, GetDirectionToMouse(), this);
            TriggerSkillGCD();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            skill4.UseSkill(transform.position, GetDirectionToMouse(), this);
            TriggerSkillGCD();
        }
    }

    private void CheckBasicAttack()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            weaponAttack.UseSkill(transform.position, GetDirectionToMouse(), this);
        }
    }

    public void TriggerSkillGCD()
    {
        skill1.TriggerGCD();
        skill2.TriggerGCD();
        skill3.TriggerGCD();
        skill4.TriggerGCD();
    }
}
