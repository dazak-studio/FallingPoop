using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreText;
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
        scoreText.text = "Press Z To Start";
        mainText.text = "DDONG PI HA GI";
    }

    // call when you want to start game
    public void DoGameStart()
    {
        leftTime = 0.0f;
        isPlaying = true;
        mainText.text = "";
    }

    // call when you want to do gameover
    public void DoGameOver()
    {
        isPlaying = false;
        mainText.text = "GAME OVER";
        scoreText.text = "Your Score : " + (int)leftTime + ", Press R to restart";
    }

    private void CheckLeftTime()
    {
        if (isPlaying)
        {
            leftTime += Time.deltaTime;
            scoreText.text = "You Survived for " + (int)leftTime + " seconds!";
        }
    }
}
