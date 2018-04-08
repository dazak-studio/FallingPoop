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

    public float rollingSpeed = 6f;
    public bool isRolling = false;
    private float rollingStartTime;
    private float rollingLength;
    Vector3 currentPosition;
    Vector3 afterPosition;

    Vector3 lookDirection;

    Rigidbody playerRigidbody;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRolling = true;

            currentPosition = transform.position;
            afterPosition = currentPosition + transform.forward * 2;
            
            rollingStartTime = Time.time;
            rollingLength = Vector3.Distance(currentPosition, afterPosition);
        }

        Rolling(this.currentPosition, this.afterPosition, this.rollingLength, this.rollingStartTime);
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

    void Rolling(Vector3 currentPosition, Vector3 afterPosition, float rollingLength, float rollingStartTime)
    {
        if(!isRolling) return;

        float distCovered = (Time.time - rollingStartTime) * rollingSpeed;

        float fracRolling = distCovered / rollingLength;

        transform.position = Vector3.Lerp(currentPosition, afterPosition, fracRolling);

        if(fracRolling > 1)
        {
            rollingStartTime = 0f;
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
            
        }
    }

    void TouchPoop()
    {
        dyingAudio.Play();
        gameManager.GetComponent<GameManager>().GameOver();
    }
}
