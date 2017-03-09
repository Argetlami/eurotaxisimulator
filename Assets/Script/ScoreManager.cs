using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Score manager.
/// </summary>
public class ScoreManager : MonoBehaviour
{

	//Fields
	public static double money;

	Text moneyfield;

	/// <summary>
	/// At the start of this instance.
	/// </summary>
	void Start ()
	{
		moneyfield = GameObject.Find ("MoneyAmount").GetComponent<Text> ();
		money = 0;
	}

	/// <summary>
	/// An update is called once per frame.
	/// </summary>
	void Update ()
	{
		if (money < 0)
			money = 0;
		moneyfield.text = "" + money;
	}

	/// <summary>
	/// Adds money to the counter if player is not frozen (as in in cutscene).
	/// </summary>
	/// <param name="profit">Profit.</param>
	public static void addMoney (double profit)
	{
		if (!PlayerController.frozen) {
			money += profit;
		}
	}

	/// <summary>
	/// Reset money to 0.
	/// </summary>
	public static void reset ()
	{
		money = 0;
	}
}
