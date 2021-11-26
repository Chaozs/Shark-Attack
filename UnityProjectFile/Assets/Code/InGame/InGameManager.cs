using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    private bool gameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //check for escape key pressed for pausing game
    void Update()
    {
        checkEscapeKey();

    }

    void checkEscapeKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                SendMessage("PauseGame");
                gameIsPaused = !gameIsPaused;
            }
            else
            {
                SendMessage("unPauseGame");
                gameIsPaused = !gameIsPaused;
            }
        }
    }
}
