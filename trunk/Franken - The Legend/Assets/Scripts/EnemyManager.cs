using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public GameObject player;
	public float zoombieVelocity = 0.1f;
	float x, y;

	// Use this for initialization
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
			transform.Translate( player.transform.position.x - (transform.position.x - 0.05f), player.transform.position.y - (transform.position.y - 0.05f), 0);
			//BatBehavior ();
		}
	}

	void ZoombieBehavior()
	{
		transform.Translate( new Vector3( -(float)zoombieVelocity, 0, 0));
		//OnCollision2D(player.collider2D);
	}

	void BatBehavior()
	{
		transform.Translate( player.transform.position.x - (transform.position.x - 0.05f), player.transform.position.y - (transform.position.y - 0.05f), 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(gameObject.tag == "Zoombie")
			{
				//Debug.Log(other.gameObject.tag + " : " + gameObject.tag);
				//Debug.Log("Colidiu");
				zoombieVelocity = 0;
				PlayerMov.takingDamage = true;	
			}
		}
	}
}
