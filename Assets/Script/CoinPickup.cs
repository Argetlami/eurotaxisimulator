using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

	public double profit;

	void OnTriggerEnter2D (Collider2D other)
	{
		ScoreManager.addMoney (profit);

		Destroy (gameObject);
	}
}
