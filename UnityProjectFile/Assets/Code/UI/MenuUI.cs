using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{

    //sends message upwards to start game
    public void clickStartGame()
    {
        SendMessageUpwards("StartGame");
    }

    //exits application
    public void clickExitGame()
    {
        Application.Quit();
    }

    public void clickHowToPlay()
    {
        SendMessageUpwards("HowToPlay");
    }

    public void clickReturnToMenu()
    {
        SendMessageUpwards("BackToMenu");
    }

    public void continueGame()
    {
        SendMessageUpwards("unPauseGame");
    }

}
