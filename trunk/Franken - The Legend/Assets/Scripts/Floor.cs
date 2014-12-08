using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour
{
    #region variables
    public GameObject floor;
	public GameObject bg1;
	public GameObject bg2;
	public GameObject player;
	public GameObject parentBG1, parentBG2;
    
	public float floorValue;
    float posFloor;
	float posBG1;
	float posBG2;
    int count;
	public GameObject goFloor;
	public GameObject goBG1;
	public GameObject goBG2;
	public float bossArea;
    //public GameObject[] arrayBG1, arrayBG2;

    
    #endregion


    void Start () 
	{
		count = 0;
        posFloor = floor.transform.position.x;
		posBG1 = bg1.transform.position.x;
		posBG2 = bg2.transform.position.x;
		//arrayBG1 = new GameObject[(int)floorValue];
		//arrayBG2 = new GameObject[(int)floorValue];
		//arrayBG1[0] = bg1;
		//arrayBG2[0] = bg2;
		bg1.transform.parent = parentBG1.transform;
		bg2.transform.parent = parentBG2.transform;
	}
	
	void Update () 
	{
        count++;
		posFloor += floor.transform.localScale.x * (floor.GetComponent<BoxCollider2D>().size.x);
		posBG1 += floor.transform.localScale.x * (bg1.GetComponent<BoxCollider2D>().size.x);
		posBG2 += floor.transform.localScale.x * (bg2.GetComponent<BoxCollider2D>().size.x);
        //Debug.Log(count);
		if(count < floorValue){
            goFloor = GameObject.Instantiate(floor) as GameObject;
            goFloor.transform.position = new Vector3( posFloor, floor.transform.position.y, floor.transform.position.z);
			//Debug.Log("PosFloor " + posFloor + " , PosBG1 " + posBG1 + " , PosBG2 " + posBG2);
			goBG1 = GameObject.Instantiate(bg1) as GameObject;
			goBG1.transform.position = new Vector3( posBG1, bg1.transform.position.y, bg1.transform.position.z);

			goBG2 = GameObject.Instantiate(bg2) as GameObject;
			goBG2.transform.position = new Vector3( posBG2, bg2.transform.position.y, bg2.transform.position.z);
			//arrayBG1[count] = goBG1;
			//arrayBG2[count] = goBG2;
			goBG1.transform.parent = parentBG1.transform;
			goBG2.transform.parent = parentBG2.transform;

        }
		//bool canMoveRight = player.GetComponent<PlayerMov>().canMoveRight;
		//Debug.Log(canMoveRight);

		if(floorValue - count < bossArea)
		{
			goFloor.GetComponent<SpriteRenderer>().color = Color.grey;
		}

		Move ();
	}

	void Move()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			
			parentBG1.transform.Translate(0.005f, 0, 0);
			parentBG2.transform.Translate(0.01f, 0, 0);
		}
		
		if (Input.GetKey(KeyCode.LeftArrow) && PlayerMov.instance.canMove)
		{
			parentBG1.transform.Translate(-0.005f, 0, 0);
			parentBG2.transform.Translate(-0.01f, 0, 0);
			
		}
	}
}