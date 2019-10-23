using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public GameObject bubble;

    public Text scoreText;
    public int score;

    private const float doubleClickTime = .2f;
    private float lastClickTime;

    public float timeLeft = 10.0f;

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

        scoreText.text = "Score: " + score;

        //Timer
        var timeOut = false;
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if(timeOut == false)
            {
                SceneManager.UnloadScene("Level1");
                SceneManager.LoadScene("Level2", LoadSceneMode.Additive);
                timeOut = true;
            }          
        }
    }

    public void AddScore()
    {
        score = score += 1;
    }
}