using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Taxi meter.
/// </summary>
public class TaxiMeter : MonoBehaviour
{
	//Fields
	public float targetTime;
	private float timer;

	/// <summary>
	/// At the start of this instance.
	/// </summary>
	private void Start ()
	{
		ScoreManager.addMoney (6.00);
	}

	/// <summary>
	/// An update is called once per frame.
	/// </summary>
	void Update ()
	{

		timer -= Time.deltaTime;

		if (timer <= 0.0f) {
			timerEnded ();
		}

	}

	/// <summary>
	/// When timer hits 0, add 1.57 to the players money earned.
	/// </summary>
	void timerEnded ()
	{
		ScoreManager.addMoney (1.57);
		timer = targetTime;
	}
}
