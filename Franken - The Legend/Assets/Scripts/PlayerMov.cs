﻿using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {
	public float distToGround;
	public GameObject floor;

	public GameObject bg1;
	public GameObject bg2;

	// Use this for initialization
	void Start () 
	{
		rigidbody2D.fixedAngle = true;
	}
	
	// Update is called once per frame
	void Update () 
	{

		distToGround = collider2D.GetComponent<BoxCollider2D>().size.y;

		Move ();
	}

	public bool IsGrounded()
	{
		return Physics.Raycast(transform.position, floor.transform.position, distToGround + 0.1f);
	}

	public void OnTrigger2DEnter()
	{

	}
	public void Move(){
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate( 0.1f, 0, 0);
			bg1.transform.Translate(-0.02f, 0, 0);
			bg2.transform.Translate(-0.01f, 0, 0);

		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-0.1f, 0, 0);
			bg1.transform.Translate(0.02f, 0, 0);
			bg2.transform.Translate(0.01f, 0, 0);
		}
		
		if (Input.GetKeyDown (KeyCode.Space) && IsGrounded())
		{
			rigidbody2D.AddForce (new Vector2 (0, 300));
		}
		if (Input.GetKeyDown (KeyCode.A)){}
		IsGrounded ();
	}
}
