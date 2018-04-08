using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Networking;

public class PoopIntegration : MonoBehaviour
{

	private bool done = false;
	private int EatenPoop = 1;
	private GameObject gamemanager;
	public GameObject Shadow;
	private GameObject uimanager;
	private GameObject landmanager;
	private bool isLanded = false;
	private float landedTime;
	private GameObject poopShadow;

	void Start ()
	{
		gamemanager = GameObject.FindWithTag("GameManager");
		uimanager = GameObject.FindWithTag("UIManager");
		landmanager = GameObject.FindWithTag("Land");
		//Shadow = GameObject.FindWithTag("Shadow");
		Quaternion shadowQuaternion = Quaternion.identity;
		Vector3 poopPos = this.transform.position;
		poopPos.y = -0.45f;
		shadowQuaternion.eulerAngles = new Vector3(90, 0, 0);
		poopShadow = Instantiate(Shadow,poopPos,shadowQuaternion);
	}
	// Update is called once per frame
	void Update () {
		FallingPoopDestroy();
		LandedPoopDestory();
        FallingPoopStop();
        StoppedPoopDestroy();
	}

	void LandedPoopDestory()
	{
		if (this.transform.position.y < 0.1f)
		{
			if (isLanded == false)
			{
				isLanded = true;
				landedTime = Time.time;
			}else if (Time.time > 0.3f+landedTime
                && gamemanager != null 
                && gamemanager.GetComponent<GameManager>().GetIsPlaying())
			{
				Destroy(poopShadow);
				Destroy(this.gameObject);
			}
		}
		
		
	}
	void FallingPoopDestroy()
	{
		//if (gamemanager!=null&&!gamemanager.GetComponent<GameManager>().GetIsPlaying())
		//{
		//	Destroy(poopShadow);
		//	Destroy(this.gameObject);
		//}
		if (this.transform.position.y < -4f)
		{
			//uimanager.GetComponent<UIManager>().poopScore += EatenPoop;
			Destroy(poopShadow);
			Destroy(this.gameObject);
		}
	}

    private void FallingPoopStop()
    {
        if (gamemanager != null && !gamemanager.GetComponent<GameManager>().GetIsPlaying())
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    private void StoppedPoopDestroy()
    {
        if(!this.gameObject.GetComponent<Rigidbody>().useGravity
            && gamemanager != null
            && gamemanager.GetComponent<GameManager>().GetIsPlaying())
        {
            Destroy(this.gameObject);
            Destroy(poopShadow);
        }
    }

	private void setEP(int ep)
	{
		EatenPoop = ep;
	}

	private int getEP()
	{
		return EatenPoop;
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
		if (col.gameObject.tag == "Player")
		{
			if(this.transform.position.y>0)
				gamemanager.GetComponent<GameManager>().GameOver();
		}else if (col.gameObject.tag == "poop")
		{
			Transform thisObject = this.gameObject.transform;
			Transform colObject = col.gameObject.transform;
			if (this.EatenPoop >= col.gameObject.GetComponent<PoopIntegration>().getEP())
			{
				int colEP = col.gameObject.GetComponent<PoopIntegration>().getEP();
				col.gameObject.GetComponent<PoopIntegration>().setEP(0);
				//Destroy(col.gameObject.GetComponent<PoopIntegration>().Shadow);
				//Destroy(col.gameObject);
				EatenPoop = EatenPoop + colEP;
				float size = (float)Math.Sqrt(Math.Sqrt(EatenPoop));
				this.transform.localScale = new Vector3(size, size, size);
				this.transform.position += new Vector3(0,-0.5f,0);
				landmanager.GetComponent<LandManager>().val++;
			}
			/*
			Transform thisObject = this.gameObject.transform;
			Transform colObject = col.gameObject.transform;
			if (this.gameObject.transform.position.y < col.gameObject.transform.position.y)
			{
				Destroy(col.gameObject);
				float size = Mathf.Sqrt(thisObject.localScale.x * thisObject.localScale.x +
				                        colObject.localScale.z * colObject.localScale.z);
				this.transform.localScale = new Vector3(size, 0.3f*size, size);
			}
			if (this.gameObject.transform.position.y == col.gameObject.transform.position.y &&this.gameObject.transform.position.magnitude > col.gameObject.transform.position.magnitude)
			{
				Debug.Log("test");
				Destroy(col.gameObject);
				float size = Mathf.Sqrt(thisObject.localScale.x * thisObject.localScale.x +
				                        colObject.localScale.z * colObject.localScale.z);
				this.transform.localScale = new Vector3(size, 0.3f*size, size);
			}
		*/
		}
	}
}
