using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

	public float speed = 6f;
	public bool isEquipedShovel = false;

	Vector3 movement;
	Rigidbody playerRigidbody;
	MeshRenderer playerMeshRenderer;

	void Awake ()
	{
		playerRigidbody = GetComponent<Rigidbody> ();
		playerMeshRenderer = GetComponent<MeshRenderer> ();
	}

	void Update ()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);

		if (Input.GetKeyDown (KeyCode.Return))
		{
			ToggleShovel(isEquipedShovel);
		}
	}

	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
	}

	void ToggleShovel (bool isEquipedShovel)
	{
		this.isEquipedShovel = !this.isEquipedShovel;

		if (isEquipedShovel)
		{
			playerMeshRenderer.material.color = Color.red;
		}
		else
		{
			playerMeshRenderer.material.color = Color.white;
		}
	}

}