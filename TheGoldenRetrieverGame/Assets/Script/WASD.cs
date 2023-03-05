using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public float forceAmount = 5;
    Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     //get doggo's rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))    //when W is pressed, move up
        {
            rb2d.AddForce(Vector2.up * forceAmount);
        }

        if (Input.GetKey(KeyCode.S))    //when S is pressed, move down
        {
            rb2d.AddForce(Vector2.down * forceAmount);
        }

        if (Input.GetKey(KeyCode.A))    //when A is pressed, move left
        {
            rb2d.AddForce(Vector2.left * forceAmount);
        }

        if (Input.GetKey(KeyCode.D))    //when D is pressed, move right
        {
            rb2d.AddForce(Vector2.right * forceAmount);
        }

        rb2d.velocity *= 0.99f;     //doggo slows down
    }
}
