using UnityEngine;
using System.Collections;
public class pulo : MonoBehaviour {

    //Movement Variables 
    public float speedForce=20f;
    public Vector2 jumpVector;

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

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(jumpVector, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-jumpVector, ForceMode2D.Force);
        }
    }
}﻿