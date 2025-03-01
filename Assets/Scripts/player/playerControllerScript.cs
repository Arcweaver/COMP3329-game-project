using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 125f; 
    private Vector2 moveInput; 
    private SpriteRenderer spriteRenderer;
    public int maxHealth = 100;
    private int currentHealth;
    public int CurrentHealth => currentHealth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Get movement input
        moveInput.x = Input.GetAxis("Horizontal"); // x dir movement
        moveInput.y = Input.GetAxis("Vertical");   // y dir movement

        // Move the character
        MoveCharacter(moveInput);

        // Check for skill casting
        CheckSkillCasting();

        // Check for basic attack
        CheckBasicAttack();
    }

    private void MoveCharacter(Vector2 direction)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Move without changing direction
            Vector2 newPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
        else
        {
            if (direction != Vector2.zero)
            {
                Vector2 newPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;
                transform.position = newPosition;

                // Calculate the angle based on the movement direction
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }

    private void CheckSkillCasting()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Casting Skill 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Casting Skill 2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Casting Skill 3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Casting Skill 4");
        }
    }

    private void CheckBasicAttack()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Debug.Log("Performing Basic Attack");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Current Health: {currentHealth}");
    }


    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Current Health: {currentHealth}");
    }
}