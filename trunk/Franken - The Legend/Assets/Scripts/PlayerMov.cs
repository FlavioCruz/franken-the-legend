using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {
	public float distToGround;
	public GameObject floor;
	// Use this for initialization
	void Start () 
	{
		rigidbody2D.fixedAngle = true;
	}
	
	// Update is called once per frame
	void Update () 
	{

		distToGround = collider2D.GetComponent<BoxCollider2D>().size.y;

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate( 0.1f, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-0.1f, 0, 0);

        if (Input.GetKeyDown (KeyCode.Space) && IsGrounded())
		{
			rigidbody2D.AddForce (new Vector2 (0, 300));
		}
		if (Input.GetKeyDown (KeyCode.A)){}
			IsGrounded ();
	}

	public bool IsGrounded()
	{
		return Physics.Raycast(transform.position, floor.transform.position, distToGround + 0.1f);
	}

	public void OnTrigger2DEnter()
	{

	}
}
