using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {
	public float distToGround;
	public GameObject floor;

	public GameObject bg1;
	public GameObject bg2;
    private bool isMoving = false;
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
       
		distToGround = collider2D.GetComponent<BoxCollider2D>().size.y;

        
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.animator.Play("RunFoward");
                transform.Translate(0.1f, 0, 0);
                bg1.transform.Translate(-0.02f, 0, 0);
                bg2.transform.Translate(-0.01f, 0, 0);
            }
            else
            {
                 if (Input.GetKey(KeyCode.LeftArrow))
                 {

                     this.animator.Play("RunBackward");
                     transform.Translate(-0.1f, 0, 0);
                     bg1.transform.Translate(0.02f, 0, 0);
                     bg2.transform.Translate(0.01f, 0, 0);
                
                 }
                 else
                 {
                     this.animator.Play("Idle1");
                 }
            }
      }
       

	public bool IsGrounded()
	{
		return Physics.Raycast(transform.position, floor.transform.position, distToGround + 0.1f);
	}

	public void OnTrigger2DEnter()
	{

	}  
      
		
 
}
