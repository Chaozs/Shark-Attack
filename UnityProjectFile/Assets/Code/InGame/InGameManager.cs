using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    private bool gameIsPaused = false;
    private GameObject player;
    private PlayerController playerController;
    private GameObject PauseMenu;
    public TMPro.TMP_Text countDown;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) Debug.Log("Player not found");
        playerController = player.transform.GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    public void gameStart()
    {
        StartCoroutine(countdownToStart());
    }

    //check for escape key pressed for pausing game
    void Update()
    {
        checkEscapeKey();

    }

    IEnumerator countdownToStart()
    {
        for (int i = 2; i > 0; i-- )
        {
            countDown.text = "Starting in " + i;
            yield return new WaitForSeconds(1);
        }

        playerController.allowSharkMovement(true);
        countDown.text = "Go! ";
        yield return new WaitForSeconds(1);
        countDown.text = "r";
    }

    void checkEscapeKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                SendMessageUpwards("PauseGame");
                gameIsPaused = !gameIsPaused;
            }
            else
            {
                SendMessageUpwards("unPauseGame");
                gameIsPaused = !gameIsPaused;
            }
        }
    }
}
