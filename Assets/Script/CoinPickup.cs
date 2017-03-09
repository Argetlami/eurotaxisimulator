using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Determinates what happens when a coin is picked up.
/// </summary>
public class CoinPickup : MonoBehaviour
{
	//Fields
	public double profit;

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">What collides with the coin</param>
	void OnTriggerEnter2D (Collider2D other)
	{
		ScoreManager.addMoney (profit);

		Destroy (gameObject);
	}
}
