using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public float speed;
    private float xValue;
    private float yValue;

	// Use this for initialization
	void Start () {
        speed = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
        xValue = Input.GetAxis("Horizontal");
        yValue = Input.GetAxis("Vertical");
        Vector3 newPos = player.transform.position + new Vector3(xValue * speed * Time.deltaTime, 0.0f, yValue * speed * Time.deltaTime);
        player.transform.position = newPos;
	}
}
