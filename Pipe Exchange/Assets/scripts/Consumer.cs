using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour {

    Animator anim;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Reset");
        anim.ResetTrigger("Reset");
        anim.ResetTrigger("Watered");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void SetState(ConsumerState state)
    {
        switch (state)
        {
            case ConsumerState.Watered:
                anim.SetTrigger("Watered");
                break;
            case ConsumerState.Reset:
                anim.SetTrigger("Reset");
                break;
            default:
                break;
        }
    }

    public enum ConsumerState
    {
        Watered,
        Reset
    }

}
