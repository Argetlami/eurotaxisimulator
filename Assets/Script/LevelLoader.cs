using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Level loader.
/// </summary>
public class LevelLoader : MonoBehaviour
{
	//Fields
	private bool playerInZone;
	GameObject PlayerObject;
	public static Level levelToLoad;
	float x;
	float y;

	PlayerController playercontroller;
	public static Level cutscene = new Level (0, -30, true);
	public static Level level1 = new Level (-16, 0, false);
	public static Level level2 = new Level (205, 1, false);
	public static Level level3 = new Level (420, 0, false);

	/// <summary>
	/// At the start of this instance.
	/// </summary>
	void Start ()
	{
		playerInZone = false;
		GameObject PlayerObject = GameObject.Find ("taxi");
		LoadLevel (cutscene);
	}

	/// <summary>
	/// An update is called once per frame.
	/// </summary>
	void Update ()
	{
		if (playerInZone) {

			LoadLevel (levelToLoad);
		}
	}

	/// <summary>
	/// Raises the trigger enter2d event if player is on the zone.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "taxi") {
			playerInZone = true;
		}
	}

	/// <summary>
	/// Raises the trigger exit2 d event if player leaves the zone.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == "taxi") {
			playerInZone = false;
		}
	}

	/// <summary>
	/// Loads the level by its starting coordinates and freezes the player if its a cutscene, unfreezes otherwise.
	/// </summary>
	/// <param name="level">Level.</param>
	public static void LoadLevel (Level level)
	{
		PlayerController.teleportTo (level.getLevelx (), level.getLevely ());
		if (level.isCutScene ()) {
			HudManager.setVisibility (false);
			PlayerController.Freeze (true);
		} else {
			GameController.testPassenger.setFrustration (0);
			HudManager.setVisibility (true);
			PlayerController.Freeze (false);
		}
	}
}
