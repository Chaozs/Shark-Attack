using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore;
    public TMP_Text score;
    public TMP_Text timer;
    private Stopwatch time = new Stopwatch();


    public void setupScoreManager()
    {
        score.text = 0.ToString();
        timer.text = 300.ToString();
        time.Restart();
        time.Start();
        InvokeRepeating("updateTime", 0f, 1f);
    }

    // Update is called once per frame
    public void incScore(int inc)
    {
        currentScore = currentScore + inc;
        score.text = currentScore.ToString();
    }

    private void updateTime()
    {
        float elapsedTime = 300 - (time.ElapsedMilliseconds / 1000);
        timer.text = elapsedTime.ToString();
    }
}
