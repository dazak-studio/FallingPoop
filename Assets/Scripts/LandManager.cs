using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandManager : MonoBehaviour
{
	public AudioSource fallenPoop;
	public int val = 0;
	public int prevval = 0;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if (prevval != val)
		{
			fallenPoop.Play();		
			prevval = val;
		}
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "poop")
		{
			fallenPoop.Play();
		}
	}
}
