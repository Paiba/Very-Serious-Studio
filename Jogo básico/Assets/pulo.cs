using UnityEngine;
using System.Collections;
public class pulo : MonoBehaviour {

    //Movement Variables 
    public float speedForce=20f;
    public Vector2 jumpVector;
    public bool isGrounded;
    public Transform grounder;
    public float raio;
    public LayerMask ground;

    Rigidbody2D rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        //Moving Left/Right 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speedForce, rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speedForce, rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else rb.velocity = new Vector2(0, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(grounder.transform.position, raio, ground);

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(jumpVector, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-jumpVector, ForceMode2D.Force);
        }
    }
}﻿