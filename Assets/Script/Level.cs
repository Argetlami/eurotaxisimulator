using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level
{
	private float x;
	private float y;
	private Passenger passenger;
	private Boolean isCutscene;

    

	public Level (float x, float y, Boolean isCutScene)
	{
		this.x = x;
		this.y = y;
        this.isCutscene = isCutScene;
	}
	public float getLevelx ()
	{
		return this.x;
	}

	public float getLevely ()
	{
		return this.y;
	}
    public Boolean isCutScene()
    {
        return this.isCutscene;
    }
}