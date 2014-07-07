using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
    public GameObject floor;
    float pos;
    int count;

	// Use this for initialization
	void Start () {
        pos = floor.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        count++;
        pos += floor.GetComponent<BoxCollider2D>().size.x;
        //for (int i = 0; i < 10; i++ )
        //{
        Debug.Log(count);
        if(count/6 < 40){
            GameObject go = GameObject.Instantiate(floor) as GameObject;
            go.transform.position = new Vector3( pos, floor.transform.position.y, floor.transform.position.z);
        }
	}
}
