using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour 
{

	public static PlayerMov instance;

    private bool isLookingBack;

	public bool takingDamage = false;
    public bool isAttacking = false;
	public bool canMove = true;

	public float myHP;

    private Animator myAnimation;


    void Awake()
    {
		if (PlayerMov.instance == null)
			instance = this;

		if (instance != this)
			Destroy (this);


        myAnimation = GetComponent<Animator>();
    }

	void Start () 
	{
		rigidbody2D.fixedAngle = true;
	}

	void Update () 
	{

	    if (Input.GetKey(KeyCode.RightArrow))
	    {
	        isLookingBack = false;
	        this.myAnimation.Play("MoveFoward");
	        transform.Translate(0.1f, 0, 0);
	        
	    }
	    else
	    {
	         if (Input.GetKey(KeyCode.LeftArrow) && canMove)
	         {
	             isLookingBack = true;
	             this.myAnimation.Play("MoveBackward");
	             transform.Translate(-0.1f, 0, 0);
	         }
	         else
	         {
	             
	             if (isLookingBack == true)
	             {
	                 this.myAnimation.Play("Idle2");
	             }
	             else
	             {
	                 this.myAnimation.Play("Idle1");
	             }
	            
	         }
	    }

		if(transform.position.x < 0)
			canMove = false;
		else if(transform.position.x > 0.5f)
			canMove = true;

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

	public void ApplyDamage(float damageReceived)
	{
		if (takingDamage)
			return;
		
		takingDamage = true;
		Debug.Log ("Player got hit");
		myHP -= damageReceived;
	}
      
		
 
}
