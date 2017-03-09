using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Level.
/// </summary>
public class Level
{
	//Fields
	private float x;
	private float y;
	private Passenger passenger;
	private Boolean isCutscene;

    
	/// <summary>
	/// Initializes a new instance of the <see cref="Level"/> class.
	/// </summary>
	/// <param name="x">The starting x coordinate of the level.</param>
	/// <param name="y">The starting y coordinate of the level.</param>
	/// <param name="isCutScene">If set to <c>true</c> is cutscene.</param>
	public Level (float x, float y, Boolean isCutScene)
	{
		this.x = x;
		this.y = y;
		this.isCutscene = isCutScene;
	}

	/// <summary>
	/// Gets the level x coordinate.
	/// </summary>
	/// <returns>The levelx.</returns>
	public float getLevelx ()
	{
		return this.x;
	}

	/// <summary>
	/// Gets the level y coordinate.
	/// </summary>
	/// <returns>The levely.</returns>
	public float getLevely ()
	{
		return this.y;
	}

	/// <summary>
	/// Is this a cutscene?.
	/// </summary>
	/// <returns><c>true</c> if cutscene, <c>false</c> otherwise.</returns>
	public Boolean isCutScene ()
	{
		return this.isCutscene;
	}
}