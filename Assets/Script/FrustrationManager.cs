using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Frustration manager.
/// </summary>
public class FrustrationManager : MonoBehaviour
{
	//Fields
	public PlayerController playercontroller;
	static Slider frustrationMeter;
	static private float frustration;
	private float frust;
	private Boolean speedcheck;

	/// <summary>
	/// At the start of this instance.
	/// </summary>
	void Start ()
	{
		frustrationMeter = GetComponent<Slider> ();
	}

	/// <summary>
	/// Manages the frustration based on the playerspeed.
	/// </summary>
	/// <param name="passenger">Passenger.</param>
	public static void manageFrustration (Passenger passenger)
	{
		if (!PlayerController.frozen) {
			if (!PlayerController.speedCheck () && frustrationMeter.value < 100) {
				passenger.adjustFrustration (0.1F);
			} else if (PlayerController.speedCheck () && frustrationMeter.value >= 0) {
				passenger.adjustFrustration (-0.1F);
			}
			if (frustration < 0) {
				passenger.setFrustration (0);
			}
		}
		frustrationMeter.value = passenger.getFrustration ();
		frustration = passenger.getFrustration ();
	}

	/// <summary>
	/// An update is called once per frame.
	/// </summary>
	void Update ()
	{
		speedcheck = PlayerController.speedCheck ();
		frust = frustration;
	}
}
