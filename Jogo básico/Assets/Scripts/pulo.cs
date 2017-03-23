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
    float speed;

    Animator anim;

    Rigidbody2D rb;

    void Start ()
    {
        anim = GetComponent<Animator> ();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        //Moving Left/Right 
        if(!isGrounded)
            anim.SetInteger("estado", 2);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed = isGrounded ? speedForce : speedForce * 0.8f; // Diminui a velocidade no ar do personagem quando não está no chão
                rb.velocity = new Vector2(speed, rb.velocity.y);
                transform.localScale = new Vector3(1, 1, 1);
                anim.SetInteger("estado", 1);
            if (Input.GetKey(KeyCode.UpArrow) || !isGrounded)
                anim.SetInteger("estado", 2);
            else
                anim.SetInteger("estado", 1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed = isGrounded ? speedForce : speedForce * 0.8f; // Diminui a velocidade no ar do personagem quando não está no chão
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                transform.localScale = new Vector3(-1, 1, 1);
                anim.SetInteger("estado", 1);
            if (Input.GetKey(KeyCode.UpArrow)|| !isGrounded)
                anim.SetInteger("estado", 2);
            else
                anim.SetInteger("estado", 1);
        }
        else
        {
            if(isGrounded)
                anim.SetInteger("estado", 0);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        isGrounded = Physics2D.OverlapCircle(grounder.transform.position, raio, ground);

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(jumpVector, ForceMode2D.Force);
            anim.SetInteger("estado", 2);
        }

    }
}﻿