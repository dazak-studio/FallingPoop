using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.Networking;

public class PoopIntegration : MonoBehaviour
{

	private bool done = false;
	public GameObject Poop;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag =="poop"&&done ==false)
		{
			done = true;
			//#I need to Fix this problem
			Transform thisObject = this.gameObject.transform;
			Transform colObject = col.gameObject.transform;
			Destroy(this);
			Destroy(col.gameObject);

			float size = Mathf.Sqrt(thisObject.localScale.x * thisObject.localScale.x +
			                        colObject.localScale.x * colObject.localScale.x);
			
			
			if (this.gameObject.transform.position.magnitude > col.gameObject.transform.position.magnitude)
			{
				GameObject newObject;
				newObject = Instantiate(Poop, (colObject.position+thisObject.position)/2, Quaternion.identity);
				newObject.transform.localScale = new Vector3(size,0.3f,size);
			}
			
		}
	}
}
