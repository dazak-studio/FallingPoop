﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreText;
    public Text helpText;
    public Text mainText;
    private float leftTime;
    private bool isPlaying;
    public float poopScore;
    
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
        mainText.text = "Falling Poops 3D";
        helpText.text = "Move : ← ↑ ↓ →\n\nChange Mode : Space";
    }

    // call when you want to start game
    public void DoGameStart()
    {
        leftTime = 0.0f;
        isPlaying = true;
        mainText.text = "";
        helpText.text = "";
        poopScore = 0;
    }

    // call when you want to do gameover
    public void DoGameOver()
    {
        isPlaying = false;
        mainText.text = "GAME OVER";
        scoreText.text = "Your Score : " + (int)leftTime + "\n\nFallen Poops : " + poopScore + " kg" + "\n\nPress Z to Restart";
    }

    private void CheckLeftTime()
    {
        if (isPlaying)
        {
            leftTime += Time.deltaTime;
            scoreText.text = "Time : " + (int)leftTime + " sec" + "\n\nFallen Poops : " + poopScore + " kg";
        }
    }
}
