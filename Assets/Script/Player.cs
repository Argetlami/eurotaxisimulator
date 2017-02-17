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

	public void setMoney (int value)
	{
		this.money = value;
	}

	public int getMoney ()
	{
		return this.money;
	}
}
