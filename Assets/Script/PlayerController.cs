using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// Player controller.
/// </summary>
public class PlayerController : MonoBehaviour
{
	//Fields
	static GameObject player;
	Button buttonLeft;
	Button buttonRight;
	Button buttonBrake;
	Button buttonJump;

	public float moveSpeed;
	public float accelerationSpeed;
	public float jumpHeight;
	public float rotationSpeed;
	public float currentSpeed;
	public float REMOVEME;

	public Transform groundCheckWheel;
	public float groundCheckRadiusWheel;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public LayerMask whatIsBottom;
	private Boolean groundedWheel;
	private Boolean grounded;
	private Boolean bottomed;
	private static Boolean speedChecker;
	public static float speed;
	public Boolean isLeftPressed = false;
	public Boolean isRightPressed = false;
	public Boolean isBrakePressed = false;
	public Boolean isJumpPressed = false;
	public Boolean jumped = false;
	public static Boolean frozen;
	public static Boolean movementCancelled;
	public static Boolean playLevelAudio;
	public static Boolean playCutsceneAudio;
	static Boolean playingCutsceneAudio;
	static Boolean playingLevelAudio;

	public AudioSource cutsceneAudio;
	public AudioSource levelAudio;

	/// <summary>
	/// Initializes a new instance of the <see cref="PlayerController"/> class if in need of non-static methods.
	/// </summary>
	public PlayerController ()
	{
	}

	/// <summary>
	/// At the start of this instance.
	/// </summary>
	void Start ()
	{
		player = GameObject.Find ("taxi");
		buttonLeft = GameObject.Find ("ButtonLeft").GetComponent<Button> ();
		buttonRight = GameObject.Find ("ButtonRight").GetComponent<Button> ();
		buttonBrake = GameObject.Find ("ButtonBrake").GetComponent<Button> ();
		buttonJump = GameObject.Find ("ButtonJump").GetComponent<Button> ();
		// creating listeners to buttons
		cutsceneAudio.Play ();
		levelAudio.Stop ();
	}

	/// <summary>
	/// // FixedUpdate is called multiple times in a second; unlike Update(), it's based on time, not frames
	/// </summary>
	private void FixedUpdate ()
	{
		groundedWheel = Physics2D.OverlapCircle (groundCheckWheel.position, groundCheckRadiusWheel, whatIsGround);
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		bottomed = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsBottom);
		if (bottomed) {
			GameController.testPassenger.setFrustration (101);
		}
		// Automatic acceleration
		if (!frozen) {
			if (groundedWheel && GetComponent<Rigidbody2D> ().velocity.x < moveSpeed) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x + accelerationSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			}
			//
			if (Input.GetKey (KeyCode.A) || isLeftPressed) {
				rotateLeft ();
			}
			if (Input.GetKey (KeyCode.D) || isRightPressed) {
				rotateRight ();
			}

			if (Input.GetKey (KeyCode.S) || isBrakePressed) {
				brake ();
			}
		}
		speed = GetComponent<Rigidbody2D> ().velocity.x;
		currentSpeed = speed;
	}

	/// <summary>
	/// An update is called once per frame.
	/// </summary>
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space) || (isJumpPressed && !jumped)) {
			jump ();
		}
		if (frozen && !movementCancelled) {
			cancelMovement ();
		}
		if (playCutsceneAudio && !playingCutsceneAudio) {
			cutsceneAudio.Play ();
			playingCutsceneAudio = true;
		} else if (!playCutsceneAudio) {
			cutsceneAudio.Stop ();
		}
		if (playLevelAudio && !playingLevelAudio) {
			levelAudio.Play ();
			playingLevelAudio = true;
		} else if (!playLevelAudio) {
			levelAudio.Stop ();
		}
	}

	/// <summary>
	/// Checks the speed
	/// </summary>
	/// <returns><c>true</c>, if over 6, <c>false</c> otherwise.</returns>
	public static Boolean speedCheck ()
	{
		if (speed < 6) {
			speedChecker = false;
			return false;
		} else {
			speedChecker = true;
			return true;
		}
	}

	/// <summary>
	/// If left button is pressed.
	/// </summary>
	public void onPointerDownButtonLeft ()
	{
		isLeftPressed = true;
	}

	/// <summary>
	/// If left button is released.
	/// </summary>
	public void onPointerUpButtonLeft ()
	{
		isLeftPressed = false;
	}

	/// <summary>
	/// If the right button is pressed.
	/// </summary>
	public void onPointerDownButtonRight ()
	{
		isRightPressed = true;
	}

	/// <summary>
	/// If the right button is released
	/// </summary>
	public void onPointerUpButtonRight ()
	{
		isRightPressed = false;
	}

	/// <summary>
	/// If the jump button is pressed.
	/// </summary>
	public void onPointerDownButtonJump ()
	{
		isJumpPressed = true;
	}

	/// <summary>
	/// If the jump button is released
	/// </summary>
	public void onPointerUpButtonJump ()
	{
		jumped = false;
		isJumpPressed = false;
	}

	/// <summary>
	/// If the brake button is pressed.
	/// </summary>
	public void onPointerDownButtonBrake ()
	{
		isBrakePressed = true;
	}

	/// <summary>
	/// If the brake button is released.
	/// </summary>
	public void onPointerUpButtonBrake ()
	{
		isBrakePressed = false;
	}

	/// <summary>
	/// Rotates to CCW.
	/// </summary>
	void rotateLeft ()
	{
		player.transform.Rotate (0, 0, rotationSpeed);
	}

	/// <summary>
	/// Rotates to CW.
	/// </summary>
	void rotateRight ()
	{
		player.transform.Rotate (0, 0, -rotationSpeed);
	}

	/// <summary>
	/// Jumps.
	/// </summary>
	void jump ()
	{
		if (grounded && !frozen) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			jumped = true;
		}
	}

	/// <summary>
	/// Slows down.
	/// </summary>
	void brake ()
	{
		if (groundedWheel) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x + (-accelerationSpeed), GetComponent<Rigidbody2D> ().velocity.y);
		}
	}

	/// <summary>
	/// Teleports player to coordinates.
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	public static void teleportTo (float x, float y)
	{
		player.transform.position = new Vector3 (x, y, 0);
	}

	/// <summary>
	/// Cancels the movement.
	/// </summary>
	void cancelMovement ()
	{
		if (!movementCancelled) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			GetComponent<Rigidbody2D> ().rotation = 0;
			movementCancelled = true;
		}
	}

	/// <summary>
	/// Freezes or unfreezes the player.
	/// </summary>
	/// <param name="a">If set to <c>true</c> a.</param>
	public static void Freeze (Boolean a)
	{
		if (a) {
			frozen = true;
			movementCancelled = false;
		} else {
			frozen = false;
			movementCancelled = true;
		}
	}

	/// <summary>
	/// Plaies the cutscene audio.
	/// </summary>
	public static void PlayCutsceneAudio ()
	{
		playCutsceneAudio = true;
		playLevelAudio = false;
        
		playingLevelAudio = false;
	}

	/// <summary>
	/// Plaies the level audio.
	/// </summary>
	public static void PlayLevelAudio ()
	{
		playLevelAudio = true;
		playCutsceneAudio = false;
        
		playingCutsceneAudio = false;
	}
}
