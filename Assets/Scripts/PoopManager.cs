using UnityEngine;
using System.Collections;


public class PoopManager : MonoBehaviour
{
	public GameObject Poop;
	public int XRange = 10;
	public int YRange = 10;
	public KeyCode DropPoop;
	public float PoopPercent= 1;
	public float interval = 1;
	private float timeShooted;
	
	//#TODO Maybe the time should be synced
	private float startTime = 0f;
	private float onGoingTime = 0f;
	

	public GameObject gameManager;

	// Use this for initialization
	void Start ()
	{
		PoopPercent = 0 ;
	}
	
	//#TODO Initialization is needed
	
	// Update is called once per frame
	void Update () {

		//Update
		if (gameManager.GetComponent<GameManager>().GetIsPlaying())
		{
			PoopInterface();
			onGoingTime = Time.time - startTime;
			if (onGoingTime < 10)
			{
				PoopPercent = onGoingTime / 100;
			}
		}
		else
		{
			startTime = Time.time;
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
				if(Random.Range(0f,1f)<PoopPercent)
					Instantiate(Poop, new Vector3(j*2-(float)XRange+Random.RandomRange(0.0f,1f), 10f+Random.RandomRange(0f,15f), k*2 -(float)YRange+Random.RandomRange(0f,1f)), Quaternion.identity);
					
			}
		}
	}
	//When Meet ==> Delete both and make a new object
	//Poop.transform.localScale += new Vector3(1f,0,0);	
	
}
