using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject gameManager;

    public float moveSpeed = 10f;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public AudioSource dyingAudio;

    Vector3 lookDirection;

    Vector3 movement;
    Rigidbody playerRigidbody;
    //MeshRenderer playerMeshRenderer;

    public Renderer playerRenderer;
    public Material playerMaterial;
    public Material shitMaterial;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        //playerMeshRenderer = GetComponent<MeshRenderer> ();
    }

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        initialPosition = this.transform.position;
        initialRotation = this.transform.rotation;
    }

    void Update()
    {
        if (
            (Input.GetKey(KeyCode.UpArrow) ||
             Input.GetKey(KeyCode.LeftArrow) ||
             Input.GetKey(KeyCode.DownArrow) ||
             Input.GetKey(KeyCode.RightArrow))
            &&
            gameManager.GetComponent<GameManager>().GetIsPlaying()
        )
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Move(h, v);
            if (!gameManager.GetComponent<GameManager>().GetIsPlaying())
            {
                LumberjackAnimationScript.instance.SetAnimState(3);
            }
            else
            {
                LumberjackAnimationScript.instance.SetAnimState(1);
            }
        }
        else
        {

            if (!gameManager.GetComponent<GameManager>().GetIsPlaying())
            {
                LumberjackAnimationScript.instance.SetAnimState(3);
            }
            else
            {
                LumberjackAnimationScript.instance.SetAnimState(0);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerRenderer.material = playerMaterial;
            gameManager.GetComponent<GameManager>().StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    void FixedUpdate()
    {
        FallOut();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "poop")
        {
            TouchPoop();
        }
    }

    public void InitPosition()
    {
        this.transform.position = initialPosition;
        this.transform.rotation = initialRotation;
    }

    void Move(float h, float v)
    {
        float moveSpeed = this.moveSpeed;

        // Set player look direction
        lookDirection = h * Vector3.right + v * Vector3.forward;
        this.transform.rotation = Quaternion.LookRotation(lookDirection);

        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }

    void FallOut()
    {
        if ((int)this.transform.position.y == -3)
        {
            dyingAudio.Play();
            Debug.Log("test");
            gameManager.GetComponent<GameManager>().GameOver();
            
        }
    }

    void TouchPoop()
    {
        dyingAudio.Play();
        gameManager.GetComponent<GameManager>().GameOver();
        playerRenderer.material = shitMaterial;
    }
}
