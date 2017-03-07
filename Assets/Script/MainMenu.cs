using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour {

    Button newgame;
    Button story;
    Button back;
    Button quit;
    Toggle mobile;
    GameObject mainMenu;
    GameObject storyCanvas;
    Boolean mainMenuVisible = true;
    Boolean storyCanvasVisible = false;

    void Start()
    {
        mainMenu = GameObject.Find("Main Menu");
        storyCanvas = GameObject.Find("Canvas");
        newgame = GameObject.Find("Newgame").GetComponent<Button>();
        story = GameObject.Find("Story").GetComponent<Button>();
        back = GameObject.Find("Back").GetComponent<Button>();
        quit = GameObject.Find("Quit").GetComponent<Button>();
        mobile = GameObject.Find("Mobile").GetComponent<Toggle>();
        storyCanvas.SetActive(false);

        newgame.onClick.AddListener(() => NewGame());
        story.onClick.AddListener(() => Story());
        back.onClick.AddListener(() => Back());
        quit.onClick.AddListener(() => Quit());
    }
    void Update()
    {

    }
    public void NewGame()
    {
        SceneManager.LoadScene("eurotaxi");
        HudManager.isMobile = mobile.isOn;
        Debug.Log(mobile.isOn);
    }
    public void Story()
    {
        storyCanvas.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void Back()
    {
        storyCanvas.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
