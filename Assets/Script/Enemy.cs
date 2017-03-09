using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An unused Enemy-class.
/// </summary>
public class Enemy
{
	//Fields
	private float plusFrustration;

	/// <summary>
	/// Initializes a new instance of the <see cref="Enemy"/> class.
	/// </summary>
	/// <param name="plusFrustration">How much colliding with this enemy rises passengers frustration</param>
	public Enemy (float plusFrustration)
	{
		this.plusFrustration = plusFrustration;
	}

	/// <summary>
	/// Gets the amount of frustration this enemy adds
	/// </summary>
	/// <returns>the amount of frustration this enemy adds</returns>
	public float getPlusFrustration ()
	{
		return plusFrustration;
	}
}
