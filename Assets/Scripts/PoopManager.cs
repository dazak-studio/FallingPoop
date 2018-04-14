using UnityEngine;
using System.Collections;


public class PoopManager : MonoBehaviour
{
	public GameObject Shadow;
	public GameObject Poop;
	private int XRange = 10;
	private int YRange = 10;
	public KeyCode DropPoop;
	public float GoalPoopPercent= 0.33f;
	private float PoopPercent;
	public float interval = 1;
	private float timeShooted;
	
	//#TODO Maybe the time should be synced
	private float startTime = 0f;
	private float onGoingTime = 0f;
	

	public GameObject gameManager;

	// Use this for initialization
	void Start ()
	{
	}
	
	//#TODO Initialization is needed
	
	// Update is called once per frame
	void Update () {

		//Update
		if (gameManager.GetComponent<GameManager>().GetIsPlaying())
		{
			PoopInterface();
			onGoingTime = Time.time - startTime;
			float firstTime = 60f;
			if (onGoingTime < firstTime)
			{
				PoopPercent = GoalPoopPercent * onGoingTime / firstTime;
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
		float randInit = 0.5f;
		float randFinal = 1.5f;
		
		
		for (int j = 0; j < XRange; j++)
		{
			for (int k = 0; k < YRange; k++)
			{
				if (Random.Range(0f, 1f) < PoopPercent)
				{
					float interval = Random.RandomRange(2f, 2.5f);
					float xVal = interval - (float) XRange + Random.RandomRange(0.0f, 1f);
					float yVal = 10f + Random.RandomRange(0f, 10f);
					float zVal = interval- (float) YRange + Random.RandomRange(0f, 1f);
					Vector3 poopPos = new Vector3(j * interval + xVal, yVal, k * interval + zVal);
					GameObject instGameObject = Instantiate(Poop,poopPos, Quaternion.identity);
					float Scale = Random.RandomRange(randInit, randFinal);
					instGameObject.transform.localScale = new Vector3(Scale,Scale,Scale);
				}

			}
		}
	}
	//When Meet ==> Delete both and make a new object
	//Poop.transform.localScale += new Vector3(1f,0,0);	
	
}
