using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	GameObject player;
	public float moveSpeed;
	public float accelerationSpeed;
	public float jumpHeight;
	public float rotationSpeed;
	public float currentSpeed;

    public Transform groundCheckWheel;
    public float groundCheckRadiusWheel;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private Boolean groundedWheel;
    private Boolean grounded;
    private static Boolean speedChecker;
    public static float speed;

    public PlayerController() {}

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("taxi");
	}

    // FixedUpdate is called multiple times in a second; unlike Update(), it's based on time, not frames
    private void FixedUpdate()
    {
        groundedWheel = Physics2D.OverlapCircle(groundCheckWheel.position, groundCheckRadiusWheel, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.A)) {
			player.transform.Rotate (0, 0, rotationSpeed);
		}
		if (Input.GetKey (KeyCode.D)) {
			player.transform.Rotate (0, 0, -rotationSpeed);
		}
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
		}
		if (groundedWheel && GetComponent<Rigidbody2D>().velocity.x < moveSpeed) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x + accelerationSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (groundedWheel && Input.GetKey(KeyCode.S)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x + (-accelerationSpeed), GetComponent<Rigidbody2D> ().velocity.y);
		}
        speed = GetComponent<Rigidbody2D>().velocity.x;
		currentSpeed = speed;

    }
    public static Boolean speedCheck()
    {
        if (speed < 6)
        {
            speedChecker = false;
            return false;
        }
        else
        {
            speedChecker = true;
            return true;
        }
    }
}
