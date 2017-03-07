using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{

    private bool playerInZone;
    GameObject PlayerObject;
    public static Level levelToLoad;
    float x;
    float y;

    PlayerController playercontroller;
    public static Level cutscene = new Level(0, -30, true);
    public static Level level1 = new Level(-16, 0, false);
    public static Level level2 = new Level(205, 1, false);
    public static Level level3 = new Level(420, 0, false);

    // Use this for initialization
    void Start()
    {
        playerInZone = false;
        GameObject PlayerObject = GameObject.Find("taxi");
        LoadLevel(cutscene);
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
            HudManager.setVisibility(false);
            PlayerController.Freeze(true);
        }
        else
        {
            GameController.testPassenger.setFrustration(0);
            HudManager.setVisibility(true);
            PlayerController.Freeze(false);
        }
    }
}
