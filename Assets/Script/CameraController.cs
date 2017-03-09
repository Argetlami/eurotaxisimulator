using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera controller.
/// </summary>
public class CameraController : MonoBehaviour
{
	//Fields
	static GameObject mainCamera;
	GameObject player;
	public static Boolean externallyControlled = false;

	/// <summary>
	/// At the start of this instance.
	/// </summary>
	void Start ()
	{
		mainCamera = GameObject.Find ("Main Camera");
		player = GameObject.Find ("taxi");
	}

	/// <summary>
	/// An update is called once per frame.
	/// </summary>
	void Update ()
	{
		if (!externallyControlled)
			mainCamera.transform.position = new Vector3 (player.transform.position.x + 8, player.transform.position.y, -10);
	}

	/// <summary>
	/// Controls the camera manually.
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	/// <param name="size">Ortographic size of the camera range (area to cover)</param>
	public static void ControlCamera (float x, float y, float size)
	{
		mainCamera.transform.position = new Vector3 (x, y, -10);
		mainCamera.GetComponent<Camera> ().orthographicSize = size;
	}
}
