using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour 
{

	public enum EnemyType
	{
		ZOMBIE,
		BAT
	}


	public GameObject player;

	public float enemySpeed = 0.1f;
    private Animator myAnimation;
	public EnemyType myType;
	public float myHP;
	public float myAttackDamage;


	private bool isCollinding = false;   
	public bool isAttacking = false;
    public bool receivingDamage = false;
    bool isLookingLeft = true;


    void Awake() 
    {
        myAnimation = GetComponent<Animator>();
    }

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update ()
	{
		if (myHP <= 0) 
		{
			StartCoroutine("Die");
		}
		else
		{
			if (myType == EnemyType.ZOMBIE)
			{
				ZombieMovement();
			}
			if (myType == EnemyType.BAT)
			{
				BatMovement();
			}
		}
	}

	void ZombieMovement()
	{
        if(!receivingDamage)
        {
            if (isCollinding == false)
            {
                myAnimation.Play("ZoombieWalking");
                
                if (player.transform.position.x <= this.transform.position.x)
                {
                    transform.Translate(new Vector3(-(float)enemySpeed, 0, 0));
                    if (!isLookingLeft)
                        transform.Rotate(new Vector3( 0, 180, 0));
                    isLookingLeft = true;
                }
                else
                {
                    
                    transform.Translate(new Vector3(-(float)enemySpeed, 0, 0));
                    if (isLookingLeft)
					{
                        transform.Rotate(new Vector3(0, 180, 0));
					}
                    isLookingLeft = false;
                }
            }
        }
	}

	void BatMovement()
	{
		transform.Translate(
			player.transform.position.x - (transform.position.x - 0.05f),
    		player.transform.position.y - (transform.position.y - 0.05f),
		    0);
	}

	public void ApplyDamage(float damageReceived)
	{
		if (!receivingDamage) 
		{
			receivingDamage = true;

		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
        isCollinding = true;
		if(other.gameObject == player)
		{
			if(myType == EnemyType.ZOMBIE)
			{
				enemySpeed = 0;
                myAnimation.Play("ZombieAttack");
				PlayerMov.instance.ApplyDamage(myAttackDamage);
	
                if(PlayerMov.instance.isAttacking)
                {
                    receivingDamage = true;
					PlayerMov.instance.takingDamage = false;
                    Destroy(gameObject);
                }
			}
		}
	}

    void OnTriggerExit2D(Collider2D other) 
    {
        isCollinding = false;
        enemySpeed = 0.01f;
		PlayerMov.instance.takingDamage = false;
    }

	public void StrikeOver()
	{
		isAttacking = false;
	}

	public void StrikeStart()
	{
		isAttacking = true;
	}

	public IEnumerator Die()
	{
		myAnimation.SetTrigger ("Dying");
		PlayerMov.instance.takingDamage = false;
		yield return new WaitForSeconds(2);
		Destroy (this);
	}
}
