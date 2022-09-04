using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
	public float Acceleration = 15.0f;
	public float Speed = 1.0f;
	public float JumpForce = 185.0f;

	private Rigidbody2D Rigidbody2D;
	private float Horizontal;
	private float TimeBetweenJumps = 0.1f;
	private float LastJump;
	private float Velocity;
	//private bool Grounded;

	void Start()
	{
		Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		Horizontal = Input.GetAxisRaw("Horizontal");

		//Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red)
		//if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        //{
			//Grounded = true;
       //}

		if (Horizontal != 0.0f)
			Velocity = Mathf.Clamp(Velocity + Horizontal * Acceleration * Time.deltaTime, -1.0f, 1.0f);
		else
			Velocity -= Velocity * Acceleration * Time.deltaTime;
		
		if (Input.GetKey(KeyCode.Space) && LastJump < Time.time - TimeBetweenJumps)
		{
			Rigidbody2D.AddForce(Vector2.up * JumpForce);
			LastJump = Time.time;
		}
	}

	private void FixedUpdate()
	{
		Rigidbody2D.velocity = new Vector2((Mathf.Abs(Velocity) < 0.01f ? 0.0f : Velocity) * Speed, Rigidbody2D.velocity.y);
	}
}
