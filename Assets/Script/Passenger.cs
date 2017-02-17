using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger
{
	
	private float frustration;

	public Passenger (float frustration)
	{
		this.frustration = frustration;
	}

	public float getFrustration ()
	{
		return this.frustration;
	}

	public void setFrustration (float value)
	{
		this.frustration = value;
	}
}
