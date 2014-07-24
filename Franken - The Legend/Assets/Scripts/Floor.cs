using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
    public GameObject floor;
	public GameObject player;
	public float floorValue;
    float pos;
    public int count;
	GameObject go;
	public float bossArea;

	void Start () {
		count = 0;
        pos = floor.transform.position.x;
	}
	
	void Update () {
        count++;
        pos += floor.GetComponent<BoxCollider2D>().size.x;
        Debug.Log(count);
		if(count < floorValue){
            go = GameObject.Instantiate(floor) as GameObject;
            go.transform.position = new Vector3( pos, floor.transform.position.y, floor.transform.position.z);
        }
		if(floorValue - count < bossArea)
		{
			go.GetComponent<SpriteRenderer>().color = Color.grey;
		}
	}
}
