using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameStatus {Ready, Playing, GameOver };

    public GameObject playerManager;
    public GameObject poopManager;
    public GameObject uiManager;

    private GameStatus currentGameStatus;

	// Use this for initialization
	void Start () {
        //playerManager = GameObject.FindGameObjectWithTag("PlayerManager");
        //uiManager = GameObject.FindGameObjectWithTag("UIManager");

        SetGameStatus(GameStatus.Ready);
    }
	
	// Update is called once per frame
	void Update () {

        // Test Code by Key Z, X, C
        
        if(Input.GetKeyDown(KeyCode.Z))
        {
            SetGameStatus(GameStatus.Ready);
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            SetGameStatus(GameStatus.Playing);
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            SetGameStatus(GameStatus.GameOver);
        }
    }

    public void SetGameStatus(GameStatus status)
    {
        currentGameStatus = status;
    }

    public GameStatus GetGameStatus()
    {
        return currentGameStatus;
    }
}
