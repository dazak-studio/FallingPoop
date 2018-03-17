using UnityEngine;
using System.Collections;


public class PoopManager : MonoBehaviour
{
	public GameObject Poop;
	public int XRange = 8;
	public int YRange = 8;
	public KeyCode DropPoop;
	public float PoopPercent= 0.01f;
	public float interval = 1;
	private float timeShooted;

	// Use this for initialization
	void Start ()
	{
		PoopPercent = 1 - PoopPercent;
	}
	
	//#TODO Initialization is needed
	
	// Update is called once per frame
	void Update () {

		//Update
		if (true)
		{
			PoopInterface();
		}
	}

	void PoopInterface()
	{
		if (Time.time > timeShooted + interval)
		{
			PoopMaker();	
			timeShooted = Time.time;
		}
		if (Input.GetKeyDown(DropPoop))
		{
			PoopMaker();	
		}
	}

	void PoopMaker()
	{
		for (int j = 0; j < XRange; j++)
		{
			for (int k = 0; k < YRange; k++)
			{
				if(Random.Range(0f,1f)>PoopPercent)
					Instantiate(Poop, new Vector3(j*2-8f, 10f, k*2 -8f), Quaternion.identity);
					
			}
		}
	}
	//When Meet ==> Delete both and make a new object
	//Poop.transform.localScale += new Vector3(1f,0,0);	
	
}
