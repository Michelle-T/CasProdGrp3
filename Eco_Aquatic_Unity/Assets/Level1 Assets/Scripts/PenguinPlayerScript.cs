using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PenguinPlayerScript : MonoBehaviour
{
    public Text scoreText;
    public int score;

    public Text endScoreText;
    public Text scoreTextEnd;
    bool scoring = true;
    public int endScore;

    public Text timerText;

    public float timeLeft;
    public float countdownTimer;

    public GameObject[] endObjectsActiveness;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (scoring == true)
        {
            scoreText.text = "Score: " + score;
        }

        //Timer
        //var timeOut = false;
        timeLeft -= Time.deltaTime;
        int seconds = (int)(timeLeft % 60);
        if (timeLeft <= 0)
        {
            scoring = false;
            foreach (GameObject g in endObjectsActiveness)
            {
                g.SetActive(true);
            }
            //This is to make the score text to stop adding
            scoreText.gameObject.SetActive(false);
            scoreTextEnd.gameObject.SetActive(true);

            if (scoring == false)
            {
                scoreTextEnd.text = "Score: " + endScore;
                endScoreText.text = "Your Final Score is: " + endScore;
            }

            countdownTimer -= Time.deltaTime;

            if (countdownTimer < 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
            timerText.text = "Time: " + seconds;
        }
        timerText.text = "Time: " + seconds;
    }

    public void AddScore()
    {
        if (scoring == true)
        {
            score += 1;
            GlobalScore.globalScore += 1;
        }
        if (scoring == false)
        {
            endScore = score;
        }
    }
}
