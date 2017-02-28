using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	GameObject player;
	public float moveSpeed;
	public float jumpHeight;
	public float rotationSpeed;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("taxi");
	}

	// Update is called once per frame
	void Update ()
	{
		// mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
		// mainCamera.transform.Rotate(player.transform.rotation.x, player.transform.rotation.y, -player.transform.rotation.z);
		if (Input.GetKey (KeyCode.A)) {
			player.transform.Rotate (0, 0, rotationSpeed);
		}
		if (Input.GetKey (KeyCode.D)) {
			player.transform.Rotate (0, 0, -rotationSpeed);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
		}
		if (Input.GetKey (KeyCode.W)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}


	}
}
