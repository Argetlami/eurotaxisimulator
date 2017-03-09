using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Passenger.
/// </summary>
public class Passenger
{
	//Fields
	private float frustration;

	/// <summary>
	/// Initializes a new instance of the <see cref="Passenger"/> class.
	/// </summary>
	/// <param name="frustration">Frustration at the start.</param>
	public Passenger (float frustration)
	{
		this.frustration = frustration;
	}

	/// <summary>
	/// Gets the frustration.
	/// </summary>
	/// <returns>The frustration.</returns>
	public float getFrustration ()
	{
		return this.frustration;
	}

	/// <summary>
	/// Sets the frustration.
	/// </summary>
	/// <param name="value">Value.</param>
	public void setFrustration (float value)
	{
		this.frustration = value;
	}

	/// <summary>
	/// Adjusts the frustration.
	/// </summary>
	/// <param name="amount">Amount.</param>
	public void adjustFrustration (float amount)
	{
		this.frustration += amount;
	}
}
