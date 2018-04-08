using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject playerManager;
    public GameObject poopManager;
    public GameObject uiManager;

    public AudioSource bgSound;

    private bool IsPlaying;

	// Use this for initialization
	void Start () {
        Init();
    }
	
	// Update is called once per frame
	void Update () {
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
	    bgSound.Play();
        SetIsPlaying(false);
        uiManager.GetComponent<UIManager>().Init();
    }

    public void StartGame()
    {
        SetIsPlaying(true);
        playerManager.GetComponent<PlayerManager>().InitPosition();
        uiManager.GetComponent<UIManager>().DoGameStart();

        LumberjackAnimationScript.instance.SetAnimState(0);
        bgSound.Play();
    }

    public void GameOver()
    {
        SetIsPlaying(false);
        uiManager.GetComponent<UIManager>().DoGameOver();
        bgSound.Stop();

        LumberjackAnimationScript.instance.SetAnimState(3);
    }
}
