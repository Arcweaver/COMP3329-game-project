using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class spaceshipScript : MonoBehaviour
//{
//    public GameObject bullet;
//    private Rigidbody2D rb;
//    private Vector2 v;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        v= rb.linearVelocity;
//        v.x = Input.GetAxis("Horizontal") * 10;
//        v.y = Input.GetAxis("Vertical") * 10; ;
//        rb.linearVelocity = v;
//        if (Input.GetKeyDown("space"))
//        {
//            // Create a new bullet at “transform.position” which is the current position of the ship
//            Instantiate(bullet, transform.position, Quaternion.identity);
//        }
//    }
//}




public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 125f; 
    private Vector2 moveInput; 
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
}