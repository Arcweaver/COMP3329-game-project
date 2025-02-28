using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipScript : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody2D rb;
    private Vector2 v;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        v= rb.linearVelocity;
        v.x = Input.GetAxis("Horizontal") * 10;
        v.y = Input.GetAxis("Vertical") * 10; ;
        rb.linearVelocity = v;
        if (Input.GetKeyDown("space"))
        {
            // Create a new bullet at “transform.position” which is the current position of the ship
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}