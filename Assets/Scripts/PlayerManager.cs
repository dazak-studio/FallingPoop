using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject gameManager;

    public float moveSpeed = 4.5f;
    
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public AudioSource dyingAudio;

    public float rollingSpeed = 10f;
    private bool isRolling = false;
    private float rollingStartTime = 0f;
    private float rollingEndTime = 0f;
    private float rollingLength;
    Vector3 currentPosition;
    Vector3 afterPosition;

    Vector3 lookDirection;
    private bool moveStart = false;

    Rigidbody playerRigidbody;

    public Renderer playerRenderer;
    public Material playerMaterial;
    public Material shitMaterial;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
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
            gameManager.GetComponent<GameManager>().GetIsPlaying()
        )
        {
            float h = 0;
            float v = 0;

            // Moving
            if (Input.GetKey(KeyCode.UpArrow) ||
                Input.GetKey(KeyCode.LeftArrow) ||
                Input.GetKey(KeyCode.DownArrow) ||
                Input.GetKey(KeyCode.RightArrow))
            {
                h = Input.GetAxisRaw("Horizontal");
                v = Input.GetAxisRaw("Vertical");
                                
                SetLookDirection(h, v);
                
                moveStart = true;
            }
            
            if (moveStart)
            {
                Move();

                // Rolling
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if(isRolling) return;
                    isRolling = true;

                    currentPosition = transform.position;
                    afterPosition = currentPosition + transform.forward * 1.2f;
                    
                    rollingStartTime = Time.time;
                    rollingLength = Vector3.Distance(currentPosition, afterPosition);
                }

                Rolling(this.currentPosition, this.afterPosition, this.rollingLength, this.rollingStartTime);
            }

            

            if (!gameManager.GetComponent<GameManager>().GetIsPlaying())
            {
                LumberjackAnimationScript.instance.SetAnimState(3);
            }
            else if (isRolling)
            {
                LumberjackAnimationScript.instance.SetAnimState(2);
            }
            else if (moveStart)
            {
                LumberjackAnimationScript.instance.SetAnimState(1);
            }
            else
            {
                LumberjackAnimationScript.instance.SetAnimState(0);
            }

        }
        else
        {
            LumberjackAnimationScript.instance.SetAnimState(3);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                playerRenderer.material = playerMaterial;
                gameManager.GetComponent<GameManager>().StartGame();
            }
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

    void SetLookDirection(float h, float v)
    {
        if (isRolling || Time.time - rollingEndTime < 0.4f) return;
        
        lookDirection = h * Vector3.right + v * Vector3.forward;
        this.transform.rotation = Quaternion.LookRotation(lookDirection);
    }

    void Move()
    {
        float moveSpeed = this.moveSpeed;

        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void Rolling(Vector3 currentPosition, Vector3 afterPosition, float rollingLength, float rollingStartTime)
    {
        if(!isRolling) return;

        float distCovered = (Time.time - rollingStartTime) * rollingSpeed;

        float fracRolling = distCovered / rollingLength;

        transform.position = Vector3.Lerp(currentPosition, afterPosition, fracRolling);

        if(fracRolling > 0.99)
        {
            rollingStartTime = 0f;
            rollingEndTime = Time.time;
            rollingLength = 0f;
            isRolling = false;
        }
    }

    void FallOut()
    {
        if ((int)this.transform.position.y == -3)
        {
            dyingAudio.Play();
            gameManager.GetComponent<GameManager>().GameOver();
            moveStart = false;
        }
    }

    void TouchPoop()
    {
        dyingAudio.Play();
        gameManager.GetComponent<GameManager>().GameOver();
        moveStart = false;
        playerRenderer.material = shitMaterial;
    }
}
