using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	GameObject mainCamera;
	GameObject player;

	// Use this for initialization
	void Start ()
	{
		mainCamera = GameObject.Find ("Main Camera");
		player = GameObject.Find ("taxi");
	}
	
	// Update is called once per frame
	void Update ()
	{
		mainCamera.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
	}
}
