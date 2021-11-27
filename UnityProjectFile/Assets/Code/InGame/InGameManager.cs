using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    private bool gameIsPaused = false;
    private GameObject player;
    private GameObject PlayingField;
    private PlayerController playerController;
    private GameObject PauseMenu;
    private ScoreManager scoreManager;
    public TMPro.TMP_Text countDown;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayingField = transform.Find("PlayingField").gameObject;

        if (player == null) Debug.Log("Player not found");
        if (PlayingField == null) Debug.Log("playingField not found");
        playerController = player.transform.GetComponent<PlayerController>();
        scoreManager = transform.Find("ScoreManager").GetComponent<ScoreManager>();
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

    public void EndGame()
    {
        countDown.text = "Game over! Your score is: ";
        PauseMenu.SetActive(true);
    }

    public void resetGame()
    {
        PlayingField.GetComponent<MapController>().resetPosition();
    }

    IEnumerator countdownToStart()
    {
        for (int i = 2; i > 0; i-- )
        {
            countDown.text = "Starting in " + i;
            yield return new WaitForSeconds(1);
        }

        playerController.allowSharkMovement(true);
        scoreManager.setupScoreManager();
        PlayingField.GetComponent<MapController>().startMap();
        countDown.text = "Go! ";
        yield return new WaitForSeconds(1);
        countDown.text = "";
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
