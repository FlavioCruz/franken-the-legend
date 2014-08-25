using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public GameObject player;
	public float zoombieVelocity = 0.1f;
	float x, y;
    private Animator animator;
    private bool isCollinding = false;

    public GameObject target;   

    public bool takingDamageEnemy = false;

    bool isLookingLeft = true;

	// Use this for initialization
    void Awake() 
    {
        animator = GetComponent<Animator>();
    }

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (tag == "Zoombie")
			ZoombieBehavior();
		if (tag == "Bat")
		{
			//transform.position = new Vector3(x, y, this.transform.position.z);
			transform.Translate( player.transform.position.x - (transform.position.x - 0.05f), 
                player.transform.position.y - (transform.position.y - 0.05f), 0);
			//BatBehavior ();
		}
	}

	void ZoombieBehavior()
	{
        if(!takingDamageEnemy)
        {
            if (isCollinding == false)
            {
                animator.Play("ZoombieWalking");
                
                if (target.transform.position.x <= this.transform.position.x)
                {
                    transform.Translate(new Vector3(-(float)zoombieVelocity, 0, 0));
                    if (!isLookingLeft)
                        transform.Rotate(new Vector3( 0, 180, 0));
                    isLookingLeft = true;
                }
                else
                {
                    
                    transform.Translate(new Vector3(-(float)zoombieVelocity, 0, 0));
                    if (isLookingLeft)
                        transform.Rotate(new Vector3(0, 180, 0));
                    isLookingLeft = false;
                }
            }
        }
		//OnCollision2D(player.collider2D);
	}

	void BatBehavior()
	{
		transform.Translate( player.transform.position.x - (transform.position.x - 0.05f),
            player.transform.position.y - (transform.position.y - 0.05f), 0);
	}

	void OnTriggerStay2D(Collider2D other)
	{
        isCollinding = true;
		if(other.gameObject.tag == "Player")
		{
			if(gameObject.tag == "Zoombie")
			{
				//Debug.Log(other.gameObject.tag + " : " + gameObject.tag);
				//Debug.Log("Colidiu");
				zoombieVelocity = 0;
                animator.Play("ZombieAttack");
				PlayerMov.takingDamage = true;
	
                if(PlayerMov.isAttacking)
                {
                    takingDamageEnemy = true;
                    //animator.Play("ZoombieWalking");
                    Destroy(gameObject);
                }
			}
		}
	}

    void OnTriggerExit2D(Collider2D other) 
    {
        isCollinding = false;
        zoombieVelocity = 0.01f;
    }
}
