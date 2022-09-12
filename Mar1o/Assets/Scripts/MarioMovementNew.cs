using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovementNew : MonoBehaviour
{
    private Rigidbody2D RB;
    public int  speed = 1;
    private bool facingRight = true;
    private float horizontalMove;
    public Animator animator;

    public int jumpPower = 1;
    private bool IsGrounded;
    public Transform FeetPos;
    public float CheckRadius;
    public LayerMask WhatIsGrounded;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        //Mathf.Abs() indica que el movimento sera absoluto en ambas direcciones
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        RB.velocity = new Vector2(horizontalMove * speed, RB.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(FeetPos.position, CheckRadius, WhatIsGrounded);
        
        animator.SetBool("IsGrounded", IsGrounded);

        if(horizontalMove < 0.0f && facingRight)
        {
            FlipPlayer();
        }
        if(horizontalMove > 0.0f && !facingRight)
        {
            FlipPlayer();
        }

        //aqui se asigna el boton para saltar GetKeyDown asigna el boton pulsado unicamente
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    //FlipPlayer hace que el player gire en la direccion marcada por playerScale
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 playerScale = gameObject.transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    void Jump()
    {
        RB.AddForce(Vector2.up * jumpPower);
    }
}
