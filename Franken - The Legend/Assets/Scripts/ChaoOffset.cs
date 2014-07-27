using UnityEngine;
using System.Collections;

public class ChaoOffset : MonoBehaviour 
{
	private Material currentMaterial;
	private float offset;
	public float speed;

	public static ChaoOffset current;

	void Start () 
	{
		//currentMaterial = renderer.material;
		current = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		offset += 0.005f;

		if(offset > 1.0f)
			offset -= 1.0f;

		//currentMaterial.SetTextureOffset("_MainTex", new Vector2( offset, 0));

		renderer.material.mainTextureOffset = new Vector2(offset, 0);
	}
}