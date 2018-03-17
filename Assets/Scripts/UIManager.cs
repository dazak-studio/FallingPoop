using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreText;
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
        scoreText.text = "Press Enter To Start";
    }

    // call when you want to start game
    public void DoGameStart()
    {
        leftTime = 0.0f;
        isPlaying = true;
    }

    // call when you want to do gameover
    public void DoGameOver()
    {
        isPlaying = false;
        scoreText.text = "Game Over, Your Score : " + (int)leftTime;
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
