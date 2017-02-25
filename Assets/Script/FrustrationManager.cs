using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrustrationManager : MonoBehaviour {

    public PlayerController playercontroller;
    static Slider frustrationMeter;
    static private float frustration;
    private float frust;
    private Boolean speedcheck;

	// Use this for initialization
	void Start () {
        frustrationMeter = GetComponent<Slider>();
    }
	
    public static void manageFrustration(Passenger passenger)
    {
        if (!PlayerController.speedCheck() && frustrationMeter.value < 100)
        {
            passenger.adjustFrustration(0.1F);
        }
        else if (PlayerController.speedCheck() && frustrationMeter.value >= 0)
        {
            passenger.adjustFrustration(-0.1F);
        }
        if (frustration < 0)
        {
            passenger.setFrustration(0);
        }
        frustrationMeter.value = passenger.getFrustration();
        frustration = passenger.getFrustration();
    }
	// Update is called once per frame
	void Update () {
        speedcheck = PlayerController.speedCheck();
        frust = frustration;
    }
}
