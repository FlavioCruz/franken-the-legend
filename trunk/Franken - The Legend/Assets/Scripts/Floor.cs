using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
    public GameObject floor;
	public float floorValue;
    float pos;
    int count;

	void Start () {
        pos = floor.transform.position.x;
	}
	
	void Update () {
        count++;
        pos += floor.GetComponent<BoxCollider2D>().size.x;
        Debug.Log(count);
		if(count < floorValue){
            GameObject go = GameObject.Instantiate(floor) as GameObject;
            go.transform.position = new Vector3( pos, floor.transform.position.y, floor.transform.position.z);
        }
	}
}
