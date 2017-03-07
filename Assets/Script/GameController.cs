using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	Player testPlayer = new Player ("testPlayer");
    public static Passenger testPassenger = new Passenger (0);
	Boolean died = false;

	// Use this for initialization
	void Start ()
	{
		GameObject PlayerObject = GameObject.Find ("taxi");
	}

    void FixedUpdate()
    {
        FrustrationManager.manageFrustration(testPassenger);
    }

    // Update is called once per frame
    void Update ()
	{
		if (testPassenger.getFrustration () >= 100) {
			died = true;
		}
        if (died)
        {
            PlayerController.Freeze(true);
            SceneManager.LoadScene("title");
        }
	}
}