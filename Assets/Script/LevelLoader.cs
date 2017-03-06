using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{

    private bool playerInZone;
    GameObject PlayerObject;
    Level levelToLoad;
    float x;
    float y;

    PlayerController playercontroller;
    Level level1precs = new Level(0, -30, true);
    Level level1 = new Level(0, 0, false);
    Level level2 = new Level(0, 0, false);
    Level level3 = new Level(0, 0, false);

    // Use this for initialization
    void Start()
    {
        playerInZone = false;
        GameObject PlayerObject = GameObject.Find("taxi");
        LoadLevel(level1precs);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone)
        {

            LoadLevel(levelToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "taxi")
        {
            playerInZone = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "taxi")
        {
            playerInZone = false;
        }
    }
    public static void LoadLevel(Level level)
    {
        PlayerController.teleportTo(level.getLevelx(), level.getLevely());
        if (level.isCutScene())
        {
            PlayerController.Freeze(true);
        }
        else
        {
            PlayerController.Freeze(false);
        }
    }
}
