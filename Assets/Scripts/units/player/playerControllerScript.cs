using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : UnitTemplate
{
    private Vector2 moveInput; 
    private SpriteRenderer spriteRenderer;
    private Skill skill1, skill2, skill3, skill4;
    private Skill weaponAttack;

    void Start()
    {
        //default stat modification here

        //sprite
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;

        //assign the selected skills and weapons (need manager to replace this)
        GameObject skillObject = new GameObject("playerSkill");  //dummy object
        skill1 = skillObject.AddComponent<FrostfireLanceSkill>();
        skill2 = skillObject.AddComponent<QuicksilverSkill>();
        skill3 = skillObject.AddComponent<FrostfireLanceSkill>();
        skill4 = skillObject.AddComponent<QuicksilverSkill>();
        weaponAttack = skillObject.AddComponent<FrostfireLanceSkill>();
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
    }

    private void MoveCharacter(Vector2 direction)
    {
        if (modifiedStats.moveSpeed != 0){
            if (Input.GetKey(KeyCode.Space))
            {
                // Move without changing direction
                Vector2 newPosition = (Vector2)transform.position + direction * modifiedStats.moveSpeed * Time.deltaTime;
                transform.position = newPosition;
            }
            else
            {
                if (direction != Vector2.zero)
                {
                    Vector2 newPosition = (Vector2)transform.position + direction * modifiedStats.moveSpeed * Time.deltaTime;
                    transform.position = newPosition;
    
                    // Calculate the angle based on the movement direction
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    
                    //Debug.Log(modifiedStats.moveSpeed);
                }
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

    public Vector3 GetDirectionToMouse()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Set the z coordinate to match the player's z position (if needed)
        mousePosition.z = transform.position.z;

        // Calculate the direction from the player to the mouse
        Vector3 direction = (mousePosition - transform.position).normalized;

        //Debug.Log($"Mouse Position: {mousePosition}, Player Position: {transform.position}, Direction: {direction}");

        return direction; // Return the normalized direction vector
    }

    public void TriggerSkillGCD()
    {
        skill1.TriggerGCD();
        skill2.TriggerGCD();
        skill3.TriggerGCD();
        skill4.TriggerGCD();
    }
}
