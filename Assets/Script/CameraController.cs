using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	static GameObject mainCamera;
	GameObject player;
    public static Boolean externallyControlled = false;

	// Use this for initialization
	void Start ()
	{
		mainCamera = GameObject.Find ("Main Camera");
		player = GameObject.Find ("taxi");
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (!externallyControlled)
		mainCamera.transform.position = new Vector3 (player.transform.position.x + 8, player.transform.position.y, -10);
	}
    public static void ControlCamera(float x, float y, float size)
    {
        mainCamera.transform.position = new Vector3(x, y, -10);
        mainCamera.GetComponent<Camera>().orthographicSize = size;
            }
}
