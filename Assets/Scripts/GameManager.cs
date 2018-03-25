using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject playerManager;
    public GameObject poopManager;
    public GameObject uiManager;

    private bool IsPlaying;

	// Use this for initialization
	void Start () {
        Init();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartGame();
        }
    }

    public void SetIsPlaying(bool IsPlaying)
    {
        this.IsPlaying = IsPlaying;
    }

    public bool GetIsPlaying()
    {
        return IsPlaying;
    }

    public void Init()
    {
        SetIsPlaying(false);
        uiManager.GetComponent<UIManager>().Init();
    }

    public void StartGame()
    {
        SetIsPlaying(true);
        uiManager.GetComponent<UIManager>().DoGameStart();
    }

    public void GameOver()
    {
        SetIsPlaying(false);
        playerManager.GetComponent<PlayerManager>().InitPosition();
        uiManager.GetComponent<UIManager>().DoGameOver();
    }
}
