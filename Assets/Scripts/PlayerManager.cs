using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

	public float speed = 6f;
	// public bool isEquipedShovel = false;


	Vector3 movement;
	Rigidbody playerRigidbody;

	void Awake ()
	{
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
	}

	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
	}

	/*
	void EquipShovel (bool isEquipedS)
	{
		Input.GetButtonDown ("Equip");
	}
	*/
}
