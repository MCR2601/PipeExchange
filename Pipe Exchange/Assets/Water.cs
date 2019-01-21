using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour {

    Image img;

	// Use this for initialization
	void Start () {
        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    bool state = false;

    public void Toggle()
    {
        state = !state;
        if (state)
        {
            img.color = Color.blue;
        }
        else
        {
            img.color = Color.white;
        }
    }
}
