using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private GameObject MenuCanvas; //gameobject that contains canvas of main menu
    private GameObject InGameManager; //gameobject that contains aspects related to in-game
    private GameObject InGameUI;
    private gameMode currentMode;
    private GameObject PlayingField;

    public enum gameMode { MainMenu, InGame, PauseMenu, HowToPlay };

    void Awake()
    {
        MenuCanvas = GameObject.FindGameObjectWithTag("MenuCanvas");
        InGameManager = GameObject.FindGameObjectWithTag("InGameManager");
        InGameUI = InGameManager.transform.Find("UICanvas").gameObject;
        PlayingField = InGameManager.transform.Find("PlayingField").gameObject;

        if (MenuCanvas == null) Debug.Log("MenuCanvas not found");
        if (InGameManager == null) Debug.Log("InGameManager not found");
        if (InGameUI == null) Debug.Log("InGameUI not found");
        if (PlayingField == null) Debug.Log("playingField not found");

        InGameManager.SetActive(false);
        currentMode = gameMode.MainMenu;
    }

    //this function will be called by MenuUI's sendMessage
    public void StartGame()
    {
        MenuCanvas.SetActive(false);
        InGameManager.SetActive(true);
        currentMode = gameMode.InGame;
        InGameManager.GetComponent<InGameManager>().gameStart();
    }

    //this function will be called by MenuUI's sendMessage
    public void HowToPlay()
    {
        MenuCanvas.SetActive(false);
        currentMode = gameMode.HowToPlay;
        //TODO
    }

    //called when game is paused
    public void PauseGame()
    {
        currentMode = gameMode.PauseMenu;
        Time.timeScale = 0;
        InGameUI.transform.Find("PauseMenu").gameObject.SetActive(true);
    }

    //called when game is continued
    public void unPauseGame()
    {
        currentMode = gameMode.InGame;
        Time.timeScale = 1;
        InGameUI.transform.Find("PauseMenu").gameObject.SetActive(false);
    }

    //this function will be called if player returns to menu
    public void BackToMenu()
    {
        MenuCanvas.SetActive(true);
        InGameManager.SetActive(false);
        currentMode = gameMode.MainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
