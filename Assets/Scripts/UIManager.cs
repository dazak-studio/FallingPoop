using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreText;
    public RawImage reStart;
    public Text helpText;
    public Text mainText;
    private float leftTime;
    private bool isPlaying;
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        CheckLeftTime();
	}

    // call when you want to ready game
    public void Init()
    {
        isPlaying = false;
        leftTime = 0.0f;
        scoreText.text = "Press          To Start";
        mainText.text = "Falling Poops 3D";
        helpText.text = "Move : \n\nRolling :       ";
    }

    // call when you want to start game
    public void DoGameStart()
    {
        leftTime = 0.0f;
        isPlaying = true;
        mainText.text = "";
        reStart.enabled = false;
    }

    // call when you want to do gameover
    public void DoGameOver()
    {
        isPlaying = false;
        mainText.text = "GAME OVER";
        scoreText.text = "Survival Time : " + string.Format("{0:0.000}", leftTime) + "\n\nPress          \nto Restart";
        reStart.rectTransform.anchoredPosition = new Vector3(30,148,0);
        reStart.enabled = true;
    }

    private void CheckLeftTime()
    {
        if (isPlaying)
        {
            leftTime += Mathf.Round(Time.deltaTime * 1000) * 0.001f;
            scoreText.text = "Time\n" + string.Format("{0:0.000}", leftTime) + " sec";
        }
    }
}
