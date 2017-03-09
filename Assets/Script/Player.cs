using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player.
/// </summary>
public class Player
{
	//Fields
	private string name;
	private int money;

	/// <summary>
	/// Initializes a new instance of the <see cref="Player"/> class.
	/// </summary>
	/// <param name="name">Name (unused)</param>
	public Player (string name)
	{
		this.name = name;
		this.money = 0;
	}

	/// <summary>
	/// Raises the collision enter2d event for logging purposes.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnCollisionEnter2d (Collision2D collision)
	{
		Debug.Log (collision);
		// transform.Translate (54f, 1f, 0);
	}

	/// <summary>
	/// Sets the money.
	/// </summary>
	/// <param name="value">Value.</param>
	public void setMoney (int value)
	{
		this.money = value;
	}

	/// <summary>
	/// Gets the money.
	/// </summary>
	/// <returns>The money.</returns>
	public int getMoney ()
	{
		return this.money;
	}
}
