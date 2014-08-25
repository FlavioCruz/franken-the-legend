using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {
	//public float distToGround;
	//public GameObject floor;

	//public GameObject bg1;
	//public GameObject bg2;
    private bool isLookingBack;

	public static bool takingDamage = false;

    public static bool isAttacking = false;

	public static bool canMove = true;
	// Use this for initialization
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

	void Start () 
	{
        
		rigidbody2D.fixedAngle = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
        //Debug.Log(isLookingBack);
		//distToGround = collider2D.GetComponent<BoxCollider2D>().size.y;


	    if (Input.GetKey(KeyCode.RightArrow))
	    {
	        isLookingBack = false;
	        this.animator.Play("MoveFoward");
	        transform.Translate(0.1f, 0, 0);
	        
	    }
	    else
	    {
	         if (Input.GetKey(KeyCode.LeftArrow) && canMove)
	         {
	             isLookingBack = true;
	             this.animator.Play("MoveBackward");
	             transform.Translate(-0.1f, 0, 0);
	             
	        
	         }
	         else
	         {
	             
	             if (isLookingBack == true)
	             {
	                 this.animator.Play("Idle2");
	             }
	             else
	             {
	                 this.animator.Play("Idle1");
	             }
	            
	         }
	    }

		if(transform.position.x < 0)
			canMove = false;
		else if(transform.position.x > 0.5f)
			canMove = true;

		if(takingDamage)
		{
			Debug.Log("Player is taking damage");
		}

        if (Input.GetKeyDown(KeyCode.A))
        {
            isAttacking = true;
        }
        else
            isAttacking = false;
      }
       

	//public bool IsGrounded()
	//{
		//return Physics.Raycast(transform.position, floor.transform.position, distToGround + 0.1f);
	//}

	public void OnTrigger2DEnter()
	{

	}  
      
		
 
}
