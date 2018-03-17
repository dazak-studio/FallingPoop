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
        SetIsPlaying(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Reset();
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

    public void Reset()
    {
        Debug.Log("Reset!!");
    }
}
