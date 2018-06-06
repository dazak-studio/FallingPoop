using UnityEngine;
using System.Collections;


public class PoopManager : MonoBehaviour
{
	public GameObject Shadow;
	public GameObject Poop;
	private int _xRange = 8;
	private int _yRange = 8;
	
	public float GoalPoopPercent = 0.8f;
	public float InitPoopPercent = 0.1f;
	public float ReachingTime = 30f;
	
	private float _poopPercent;
	
	
	private float IntervalPoopRemake = 1;
	private float _timeShooted;
	
	private float _startTime = 0f;
	private float _onGoingTime = 0f;
	

	public GameObject GameManager;

	
	void Update () {

		if (GameManager.GetComponent<GameManager>().GetIsPlaying())
		{
			
			_onGoingTime = Time.time - _startTime;
			if (_onGoingTime < ReachingTime)
			{
				_poopPercent = (GoalPoopPercent-InitPoopPercent) * _onGoingTime / ReachingTime + InitPoopPercent;
			}
			
			PoopInterface();
		}
		else
		{
			_startTime = Time.time;
		}
		
	}

	void PoopInterface()
	{
		if (Time.time > _timeShooted + IntervalPoopRemake)
		{
			PoopMaker();	
			_timeShooted = Time.time;
		}
	}

	void PoopMaker()
	{
		float randInit = 0.5f;
		float randFinal = 1.5f;
		
		
		for (int j = 0; j < _xRange; j++)
		{
			for (int k = 0; k < _yRange; k++)
			{
				if (Random.Range(0f, 1f) < _poopPercent)
				{
					float interval = Random.RandomRange(2f, 2.5f);
					float xVal = interval - (float) _xRange + Random.RandomRange(0.0f, 1f);
					float yVal = 10f + Random.RandomRange(0f, 10f);
					float zVal = interval- (float) _yRange + Random.RandomRange(0f, 1f);
					Vector3 poopPos = new Vector3(j * interval + xVal, yVal, k * interval + zVal);
					GameObject instGameObject = Instantiate(Poop,poopPos, Quaternion.identity);
					float Scale = Random.RandomRange(randInit, randFinal);
					instGameObject.transform.localScale = new Vector3(Scale,Scale,Scale);
				}

			}
		}
	}
}
