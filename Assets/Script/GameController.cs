using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

/// <summary>
/// Game controller.
/// </summary>
public class GameController : MonoBehaviour
{
	//Fields
	Player testPlayer = new Player ("testPlayer");
	public static Passenger testPassenger = new Passenger (0);
	Boolean died = false;


	/// <summary>
	/// At the start of this instance.
	/// </summary>
	void Start ()
	{
		GameObject PlayerObject = GameObject.Find ("taxi");
		died = false;
		testPassenger.setFrustration (0);
	}

	/// <summary>
	/// // FixedUpdate is called multiple times in a second; unlike Update(), it's based on time, not frames
	/// </summary>
	void FixedUpdate ()
	{
		FrustrationManager.manageFrustration (testPassenger);
	}

	/// <summary>
	/// An update is called once per frame.
	/// </summary>
	void Update ()
	{
		if (testPassenger.getFrustration () >= 100) {
			died = true;
		}
		if (died) {
			HudManager.GameOver ();
			PlayerController.Freeze (true);
            
			SceneManager.LoadScene ("title");
		}
	}
}