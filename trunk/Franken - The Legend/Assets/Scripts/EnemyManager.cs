using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public GameObject player;
	float zoombieVelocity = 0.1f;
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
			transform.position = new Vector3(x, y, this.transform.position.z);
			BatBehavior ();
		}
	}

	void ZoombieBehavior()
	{
		transform.Translate( new Vector3( -(float)zoombieVelocity, 0, 0));
		//OnCollision2D(player.collider2D);
	}

	void BatBehavior()
	{
		x = Input.mousePosition.x;
		y = Input.mousePosition.y;

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(gameObject.tag == "Zoombie")
			{
				Debug.Log(other.gameObject.tag + " : " + gameObject.tag);
				Debug.Log("Colidiu");
				zoombieVelocity = 0;
			}
		}
	}
}
