using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump : MonoBehaviour {

    Animator anim;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetState(PumpState state)
    {
        switch (state)
        {
            case PumpState.Work:
                anim.SetTrigger("Work");
                break;
            case PumpState.Reset:
                anim.SetTrigger("Reset");
                break;
            default:
                break;
        }
    }
    public enum PumpState
    {
        Work,
        Reset
    }
}
