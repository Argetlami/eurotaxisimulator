using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
	
	Player testPlayer = new Player ("testPlayer");
	Level testLevel = new Level (0, 0);
	Passenger testPassenger = new Passenger (0);
	Boolean died = false;

	// Use this for initialization
	void Start ()
	{
		GameObject PlayerObject = GameObject.Find ("taxi");
		PlayerObject.transform.position = new Vector3 (testLevel.getLevelx(), testLevel.getLevely(), 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (testPassenger.getFrustration() == 100) {
			died = true;
		}
	}
}
