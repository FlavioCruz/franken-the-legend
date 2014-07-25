using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (tag == "Zoombie")
			ZoombieBehavior();
	}

	void ZoombieBehavior()
	{
		transform.Translate( new Vector3( -0.1f, 0, 0));
		OnCollision2D(player);
	}

	void OnCollision2D(GameObject other)
	{
		if(other.tag == "Player")
		{
			if(tag == "Zoombie")
			{
				DestroyImmediate(this);
			}
		}
	}
}
