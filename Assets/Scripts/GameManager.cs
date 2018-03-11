using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    enum GameStatus {Ready, Playing, GameOver };

    public GameObject playerManager;
    public GameObject poopManager;
    public GameObject uiManager;

    private GameStatus currentGameStatus;

	// Use this for initialization
	void Start () {
        //playerManager = GameObject.FindGameObjectWithTag("PlayerManager");
        //uiManager = GameObject.FindGameObjectWithTag("UIManager");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetGameStatus(GameStatus status)
    {
        switch(status)
        {
            case GameStatus.Ready:
                uiManager.GetComponent<UIManager>().DoGameReady();
                break;
            case GameStatus.Playing:
                uiManager.GetComponent<UIManager>().DoGameStart();
                break;
            case GameStatus.GameOver:
                uiManager.GetComponent<UIManager>().DoGameOver();
                break;
            default:
                break;
        }
    }
}
