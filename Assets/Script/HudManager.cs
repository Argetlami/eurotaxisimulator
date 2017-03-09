using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hud manager.
/// </summary>
public class HudManager : MonoBehaviour
{

	//Fields
	GameObject canvas;
	GameObject buttons;
	static GameObject gameover;
	static Boolean isVisible;
	public static Boolean isMobile = true;

	/// <summary>
	/// At the start of this instance.
	/// </summary>
	void Start ()
	{
		canvas = GameObject.Find ("Canvas");
		buttons = GameObject.Find ("Buttons");
		gameover = GameObject.Find ("GameOver");
	}

	/// <summary>
	/// An update is called once per frame.
	/// </summary>
	void Update ()
	{
		canvas.SetActive (isVisible);
		if (!isMobile) {
			buttons.SetActive (false);
		} else {
			buttons.SetActive (true);
		}
	}

	/// <summary>
	/// Sets the visibility of the HUD based on the infromation given on the titlescreen about the platform being an mobile device without a physical keyboard.
	/// </summary>
	/// <param name="value">If set to <c>true</c> value.</param>
	public static void setVisibility (Boolean value)
	{
		isVisible = value;
	}

	/// <summary>
	/// Moves the GameOver-text to the canvas
	/// </summary>
	public static void GameOver ()
	{
		gameover.transform.localPosition = new Vector3 (0, 50, 0);
	}
}
