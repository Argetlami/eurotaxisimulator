using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

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

    public PlayerController() { }

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("taxi");
        buttonLeft = GameObject.Find("ButtonLeft").GetComponent<Button>();
        buttonRight = GameObject.Find("ButtonRight").GetComponent<Button>();
        buttonBrake = GameObject.Find("ButtonBrake").GetComponent<Button>();
        buttonJump = GameObject.Find("ButtonJump").GetComponent<Button>();
        // creating listeners to buttons
    }

    // FixedUpdate is called multiple times in a second; unlike Update(), it's based on time, not frames
    private void FixedUpdate()
    {
        groundedWheel = Physics2D.OverlapCircle(groundCheckWheel.position, groundCheckRadiusWheel, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        bottomed = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsBottom);
        if (bottomed)
        {
            GameController.testPassenger.setFrustration(101);
        }
        // Automatic acceleration
        if (!frozen)
        {
            if (groundedWheel && GetComponent<Rigidbody2D>().velocity.x < moveSpeed)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + accelerationSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            //
            if (Input.GetKey(KeyCode.A) || isLeftPressed)
            {
                rotateLeft();
            }
            if (Input.GetKey(KeyCode.D) || isRightPressed)
            {
                rotateRight();
            }

            if (Input.GetKey(KeyCode.S) || isBrakePressed)
            {
                brake();
            }
        }
        speed = GetComponent<Rigidbody2D>().velocity.x;
        currentSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (isJumpPressed && !jumped))
        {
            jump();
        }
        if (frozen && !movementCancelled)
        {
            cancelMovement();
        }
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
    public void onPointerDownButtonLeft()
    {
        isLeftPressed = true;
    }
    public void onPointerUpButtonLeft()
    {
        isLeftPressed = false;
    }
    public void onPointerDownButtonRight()
    {
        isRightPressed = true;
    }
    public void onPointerUpButtonRight()
    {
        isRightPressed = false;
    }
    public void onPointerDownButtonJump()
    {
        isJumpPressed = true;
    }
    public void onPointerUpButtonJump()
    {
        jumped = false;
        isJumpPressed = false;
    }
    public void onPointerDownButtonBrake()
    {
        isBrakePressed = true;
    }
    public void onPointerUpButtonBrake()
    {
        isBrakePressed = false;
    }
    void rotateLeft()
    {
        player.transform.Rotate(0, 0, rotationSpeed);
    }
    void rotateRight()
    {
        player.transform.Rotate(0, 0, -rotationSpeed);
    }
    void jump()
    {
        if (grounded && !frozen)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            jumped = true;
        }
    }
    void brake()
    {
        if (groundedWheel)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + (-accelerationSpeed), GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    public static void teleportTo(float x, float y)
    {
        player.transform.position = new Vector3(x, y, 0);
    }
    void cancelMovement()
    {
        if (!movementCancelled)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().rotation = 0;
            movementCancelled = true;
        }
    }
    public static void Freeze(Boolean a)
    {
        if (a)
        {
            frozen = true;
            movementCancelled = false;
        }
        else
        {
            frozen = false;
            movementCancelled = true;
        }
    }
}
