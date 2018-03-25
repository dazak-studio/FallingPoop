using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markDestoryer : MonoBehaviour
{
	private float time;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > 0.8)
		{
			//Destroy(this.gameObject);
		}
	}
}
