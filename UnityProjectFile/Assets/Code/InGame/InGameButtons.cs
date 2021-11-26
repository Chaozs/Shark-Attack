using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButtons : MonoBehaviour
{
    void pauseClick()
    {
        SendMessage("PauseGame");
    }
}
