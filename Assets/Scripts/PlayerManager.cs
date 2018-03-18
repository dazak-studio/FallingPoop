using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
  public float moveSpeed = 12f;
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
      ToggleShovel(isEquipedShovel);
    }

    if (Input.GetKeyDown (KeyCode.I))
    {
      InitPosition();
    }
  }

  public void InitPosition ()
  {
    this.transform.position = initialPosition;
    this.transform.rotation = initialRotation;
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
}
