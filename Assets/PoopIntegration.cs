﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
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

	public void setDone(bool _bool)
	{
		done = _bool;
	}

	public bool getDone()
	{
		return done;
	}
	
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "poop")
		{
			Transform thisObject = this.gameObject.transform;
			Transform colObject = col.gameObject.transform;
			if (this.gameObject.transform.position.y < col.gameObject.transform.position.y)
			{
				Destroy(col.gameObject);
				float size = Mathf.Sqrt(thisObject.localScale.x * thisObject.localScale.x +
				                        colObject.localScale.z * colObject.localScale.z);
				this.transform.localScale = new Vector3(size, 0.3f, size);
			}
			if (this.gameObject.transform.position.y == col.gameObject.transform.position.y &&this.gameObject.transform.position.magnitude > col.gameObject.transform.position.magnitude)
			{
				Debug.Log("test");
				Destroy(col.gameObject);
				float size = Mathf.Sqrt(thisObject.localScale.x * thisObject.localScale.x +
				                        colObject.localScale.z * colObject.localScale.z);
				this.transform.localScale = new Vector3(size, 0.3f, size);
			}
		}

	}
}