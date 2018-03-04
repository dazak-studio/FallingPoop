using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PoopManager : MonoBehaviour
{
	public GameObject Poop;

	// Use this for initialization
	void Start () {
		Debug.Log(Poop.transform.localScale);
		for (int i = 0; i < 20; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					if(Random.value > 0.5)
						Instantiate(Poop, new Vector3(j*3, i * 20 + 10, k * 3), Quaternion.identity);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//When Meet ==> Delete both and make a new object
	//Poop.transform.localScale += new Vector3(1f,0,0);	
	
}
