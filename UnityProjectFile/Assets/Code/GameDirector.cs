using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private GameObject MenuCanvas; //gameobject that contains canvas of main menu
    private GameObject InGameManager; //gameobject that contains aspects related to in-game
    private GameObject InGameUI;

    void Awake()
    {
        MenuCanvas = GameObject.FindGameObjectWithTag("MenuCanvas");
        InGameManager = GameObject.FindGameObjectWithTag("InGameManager");
        InGameUI = InGameManager.transform.Find("UICanvas").gameObject;

        if (MenuCanvas == null) Debug.Log("MenuCanvas not found");
        if (InGameManager == null) Debug.Log("InGameManager not found");
        if (InGameUI == null) Debug.Log("InGameUI not found");

        InGameManager.SetActive(false);
    }

    //this function will be called by MenuUI's sendMessage
    public void StartGame()
    {
        MenuCanvas.SetActive(false);
        InGameManager.SetActive(true);
    }

    //this function will be called by MenuUI's sendMessage
    public void HowToPlay()
    {
        MenuCanvas.SetActive(false);
        //TODO
    }

    //this function will be called if player returns to menu
    public void BackToMenu()
    {
        MenuCanvas.SetActive(true);
        InGameManager.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
