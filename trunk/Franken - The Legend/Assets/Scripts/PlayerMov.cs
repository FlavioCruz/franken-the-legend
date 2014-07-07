using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate( 0.1f, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-0.1f, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            rigidbody2D.AddForce(new Vector2( 0, 300));
	}
}
