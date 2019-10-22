using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public GameObject bubble;

    public Text scoreText;
    public int score;

    private const float doubleClickTime = .2f;
    private float lastClickTime;

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
    }

    public void AddScore ()
    {
        score = score += 1;
    }
}