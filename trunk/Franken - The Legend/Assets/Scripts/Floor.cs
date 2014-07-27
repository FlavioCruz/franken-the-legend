using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
    public GameObject floor;
	public GameObject bg1;
	public GameObject bg2;
	public GameObject player;
	public float floorValue;
    float posFloor;
	float posBG1;
	float posBG2;
    public int count;
	GameObject goFloor;
	GameObject goBG1;
	GameObject goBG2;
	public float bossArea;

	void Start () {
		count = 0;
        posFloor = floor.transform.position.x;
		posBG1 = bg1.transform.position.x;
		posBG2 = bg2.transform.position.x;
	}
	
	void Update () {
        count++;
        posFloor += floor.GetComponent<BoxCollider2D>().size.x;
		posBG1 += bg1.GetComponent<BoxCollider2D>().size.x;
		posBG2 += bg2.GetComponent<BoxCollider2D>().size.x;
        //Debug.Log(count);
		if(count < floorValue){
            goFloor = GameObject.Instantiate(floor) as GameObject;
            goFloor.transform.position = new Vector3( posFloor, floor.transform.position.y, floor.transform.position.z);

			goBG1 = GameObject.Instantiate(bg1) as GameObject;
			goBG1.transform.position = new Vector3( posBG1, bg1.transform.position.y, bg1.transform.position.z);

			goBG2 = GameObject.Instantiate(bg2) as GameObject;
			goBG2.transform.position = new Vector3( posBG2, bg2.transform.position.y, bg2.transform.position.z);
        }
		if(floorValue - count < bossArea)
		{
			goFloor.GetComponent<SpriteRenderer>().color = Color.grey;
		}
	}
}
