using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackAnimationScript : MonoBehaviour {

    public static LumberjackAnimationScript instance = null;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    Animator anim;
    //private int animState;
    private int beforeAnimState;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        //animState = -1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (animState != -1)
        //{
        //    anim.SetBool("NeedsChanging", false);
        //    animState = -1;
        //}
    }

    public void SetAnimState(int newAnimState)
    {
        if(beforeAnimState != newAnimState)
        {
            //animState = newAnimState;
            anim.SetInteger("StateValue", newAnimState);
            anim.SetTrigger("TriggerChangeAnim");
            beforeAnimState = newAnimState;
        }
    }


}
