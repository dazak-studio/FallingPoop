using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public GameObject gameManager;
	
  public float moveSpeed = 12f;
	// 일반 : 12f, 삽 들었을 때 : 10f, 삽 들고 똥 밀 때 : 5f
  public bool isEquipedShovel = false;
  private Vector3 initialPosition;
  private Quaternion initialRotation;

  Vector3 lookDirection;

  Vector3 movement;
  Rigidbody playerRigidbody;
  MeshRenderer playerMeshRenderer;

  void Awake ()
  {
    playerRigidbody = GetComponent<Rigidbody> ();
    playerMeshRenderer = GetComponent<MeshRenderer> ();
  }

  void Start ()
  {
		gameManager = GameObject.FindWithTag("GameManager");
    initialPosition = this.transform.position;
    initialRotation = this.transform.rotation;
  }

  void Update ()
  {
    if (Input.GetKey (KeyCode.W) ||
        Input.GetKey (KeyCode.A) ||
        Input.GetKey (KeyCode.S) ||
        Input.GetKey (KeyCode.D))
    {
      float h = Input.GetAxisRaw ("Horizontal");
      float v = Input.GetAxisRaw ("Vertical");
      
      Move (h, v);
    }

    if (Input.GetKeyDown (KeyCode.Return))
    {
      ToggleShovel (isEquipedShovel);
    }

    if (Input.GetKeyDown (KeyCode.I))
    {
      InitPosition ();
    }
  }

	void FixedUpdate ()
	{
		FallOut ();
	}

	void OnCollisionEnter (Collision other) {
		if (other.transform.tag == "poop")
		{
			if (isEquipedShovel)
			{
				PushPoop ();
			}
			else
			{
				TouchPoop ();
			}
		}
	}

  public void InitPosition ()
  {
    this.transform.position = initialPosition;
    this.transform.rotation = initialRotation;

		if (isEquipedShovel)
		{
			ToggleShovel (isEquipedShovel);
		}
  }

  void Move (float h, float v)
  {
    float moveSpeed = this.moveSpeed;

    if (isEquipedShovel) {
      moveSpeed = 5f;
    }

    // Set player look direction
    lookDirection = h * Vector3.right + v * Vector3.forward;
    this.transform.rotation = Quaternion.LookRotation (lookDirection);

    this.transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
  }

	void FallOut ()
	{
		if (this.transform.position.y < -16)
		{
			gameManager.GetComponent<GameManager>().GameOver();
		}
	}

  void ToggleShovel (bool isEquipedShovel)
  {
    this.isEquipedShovel = !this.isEquipedShovel;

    if (isEquipedShovel)
    {
      playerMeshRenderer.material.color = Color.white;
    }
    else
    {
			playerMeshRenderer.material.color = Color.red;
    }
  }

	void PushPoop ()
	{
		// 삽 들고 똥 밀 때에 대한 함수. 만들어 놓기만 함.
	}

	void TouchPoop ()
	{
		gameManager.GetComponent<GameManager>().GameOver();
	}
}
