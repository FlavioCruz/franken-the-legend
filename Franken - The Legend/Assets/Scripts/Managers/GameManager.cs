using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{

	public GameObject zombiePrefab;
	GameObject enemy;

	public Transform spawningPosition;

	public int enemyCount;


	void Start()
	{
		for (int i = 0; i < enemyCount; i++)
		{
			enemy = GameObject.Instantiate(zombiePrefab) as GameObject;
			enemy.transform.position = new Vector3(spawningPosition.position.x + (5 * i),
			                                       spawningPosition.position.y,
			                                       spawningPosition.position.z);
		}
	}
}
