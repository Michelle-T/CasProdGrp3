using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public GameObject bubble;

    public Text scoreText;
    public int score;

    public Text endScoreText;
    public Text scoreTextEnd;
    bool scoring = true;
    public int endScore;

    public Text timerText;

    private const float doubleClickTime = .2f;
    private float lastClickTime;

    public float timeLeft;
    public float countdownTimer;

    public GameObject[] endObjectsActiveness;

    void Start()
    {
        score = 0;
    }

    //shooting
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickTime)
            {
                Instantiate(bubble, transform.position, transform.rotation);
            }

            lastClickTime = Time.time;
        }

        if (scoring == true)
        {
            scoreText.text = "Score: " + score;
        }

        //Timer
        //var timeOut = false;
        timeLeft -= Time.deltaTime;
        int seconds = (int)(timeLeft % 60);
        if (timeLeft < 0)
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
        }
        if (scoring == false)
        {
            endScore = score;
        }
    }
}