using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour {

    GameObject canvas;
    GameObject buttons;
    static Boolean isVisible;
    public static Boolean isMobile = true;

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Canvas");
        buttons = GameObject.Find("Buttons");
    }
	
	// Update is called once per frame
	void Update () {
        canvas.SetActive(isVisible);
        if (!isMobile)
        {
            buttons.SetActive(false);
        }
        else
        {
            buttons.SetActive(true);
        }
	}

    public static void setVisibility(Boolean value)
    {
        isVisible = value;
    }
}
