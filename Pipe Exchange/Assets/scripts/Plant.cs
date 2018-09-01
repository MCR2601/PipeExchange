using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetState(PlantState state)
    {
        switch (state)
        {
            case PlantState.Grow:
                anim.SetTrigger("Grow");
                break;
            case PlantState.Reset:
                anim.SetTrigger("Reset");
                break;
            default:
                break;
        }
    }


    public enum PlantState
    {
        Grow,
        Reset
    }

}
