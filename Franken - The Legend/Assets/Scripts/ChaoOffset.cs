using UnityEngine;
using System.Collections;

public class ChaoOffset : MonoBehaviour 
{
	private Material currentMaterial;
	private float offset;
	public float speed;

	void Start () 
	{
		currentMaterial = renderer.material;
	}
	
	// Update is called once per frame
	void Update () 
	{
		offset += 0.001f;

		currentMaterial.SetTextureOffset("_MainTex", new Vector2( offset*speed, 0));
	}
}
