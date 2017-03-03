using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
	
	private string name;
	private int money;

	public Player (string name)
	{
		this.name = name;
		this.money = 0;
	}

	void OnCollisionEnter2d(Collision2D collision){
		Debug.Log (collision);
		// transform.Translate (54f, 1f, 0);
	}

	public void setMoney (int value)
	{
		this.money = value;
	}

	public int getMoney ()
	{
		return this.money;
	}
}
