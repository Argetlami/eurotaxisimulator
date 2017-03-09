using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// Main menu.
/// </summary>
public class MainMenu : MonoBehaviour
{

	Button newgame;
	Button story;
	Button back;
	Button quit;
	Toggle mobile;
	GameObject mainMenu;
	GameObject storyCanvas;
	Boolean mainMenuVisible = true;
	Boolean storyCanvasVisible = false;

	/// <summary>
	/// At the start of this instance.
	/// </summary>
	void Start ()
	{
		mainMenu = GameObject.Find ("Main Menu");
		storyCanvas = GameObject.Find ("Canvas");
		newgame = GameObject.Find ("Newgame").GetComponent<Button> ();
		story = GameObject.Find ("Story").GetComponent<Button> ();
		back = GameObject.Find ("Back").GetComponent<Button> ();
		quit = GameObject.Find ("Quit").GetComponent<Button> ();
		mobile = GameObject.Find ("Mobile").GetComponent<Toggle> ();
		storyCanvas.SetActive (false);

		newgame.onClick.AddListener (() => NewGame ());
		story.onClick.AddListener (() => Story ());
		back.onClick.AddListener (() => Back ());
		quit.onClick.AddListener (() => Quit ());
	}

	/// <summary>
	/// Starts a new game.
	/// </summary>
	public void NewGame ()
	{
		SceneManager.LoadScene ("eurotaxi");
		HudManager.isMobile = mobile.isOn;
		Debug.Log (mobile.isOn);
	}

	/// <summary>
	/// Shows the story canvas.
	/// </summary>
	public void Story ()
	{
		storyCanvas.SetActive (true);
		mainMenu.SetActive (false);
	}

	/// <summary>
	/// Hides the story canvas.
	/// </summary>
	public void Back ()
	{
		storyCanvas.SetActive (false);
		mainMenu.SetActive (true);
	}

	/// <summary>
	/// Halts the application.
	/// </summary>
	public void Quit ()
	{
		Application.Quit ();
	}
}
