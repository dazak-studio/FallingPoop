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

        // Test Code by Key Z, X, C
        /*
        if(Input.GetKeyDown(KeyCode.Z))
        {
            DoGameReady();
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            DoGameStart();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            DoGameOver();
        }
        */
	}

    // call when you want to ready game
    public void DoGameReady()
    {
        isPlaying = false;
        leftTime = 0.0f;
        scoreText.text = "Ready";
    }

    // call when you want to start game
    public void DoGameStart()
    {
        isPlaying = true;
    }

    // call when you want to do gameover
    public void DoGameOver()
    {
        isPlaying = false;
        scoreText.text = "Game Over";
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
