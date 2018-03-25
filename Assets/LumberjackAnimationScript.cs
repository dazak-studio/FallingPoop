using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackAnimationScript : MonoBehaviour {

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetInteger("StateValue", 0);
            anim.SetBool("NeedsChanging", true);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetInteger("StateValue", 1);
            anim.SetBool("NeedsChanging", true);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            anim.SetInteger("StateValue", 2);
            anim.SetBool("NeedsChanging", true);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            anim.SetInteger("StateValue", 3);
            anim.SetBool("NeedsChanging", true);
        }
        else
        {
            anim.SetBool("NeedsChanging", false);
        }

    }
}
