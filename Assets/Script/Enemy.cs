using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
	
	private float plusFrustration;

	public Enemy (float plusFrustration)
	{
		this.plusFrustration = plusFrustration;
	}

	public float getPlausFrustration ()
	{
		return plusFrustration;
	}
}
