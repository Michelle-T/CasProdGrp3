using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float ballInitialVelocity = 1f;
    public float maxSpeed = 2f;
    public float minSpeed = 2f;

    private Rigidbody2D rb;
    private bool ballInPlay;

    //DoubleClickVariables
    private const float doubleClickTime = .2f;
    private float lastClickTime;

    //Position variables
    public Transform Ball;
    public Transform Player;

    Vector3 originalPos;
    Vector3 originalPosPlayer;

    public int lives = 3;

    //Win Objects
    public GameObject[] winObjectsActiveness;
    public GameObject[] loseObjectsActiveness;

    AudioSource audioData;
    public AudioClip impact;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballInPlay = false;

        originalPos = gameObject.transform.position;
        originalPosPlayer = GameObject.Find("Player").transform.position;

        audioData = GetComponent<AudioSource>();
    }

    //Start Ball
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ballInPlay == false)
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickTime)
            {
                transform.parent = null; // release ball from turtle
                ballInPlay = true;
                rb.isKinematic = false; // change body type
                rb.AddForce(new Vector3(0, ballInitialVelocity, 0)); //launch ball
            }

            lastClickTime = Time.time;
        }

        //Control Top Speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        //Control Bottom Speed
        if (rb.velocity.magnitude < minSpeed)
        {
            rb.velocity = rb.velocity.normalized * minSpeed;
        }

        //Lose
        if (lives == 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            foreach (GameObject g in loseObjectsActiveness)
            {
                g.SetActive(true);
            }
        }

        //Win
        if (GameObject.FindGameObjectsWithTag("Trash").Length <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            foreach (GameObject g in winObjectsActiveness)
            {
                g.SetActive(true);
            }
        }
    }

    //Oil Breaking
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trash") //Oil is tagged trash ¯\_(ツ)_/¯
        {
            Destroy(collision.gameObject);
            audioData.PlayOneShot(impact, 0.7F);
            GlobalScore.globalScore += 1;
        }

        if (collision.gameObject.tag == "Fish") //Pelican is tagged fish ¯\_(ツ)_/¯
        {
            audioData.PlayOneShot(impact, 0.7F);
        }

        Debug.Log("Global go up");
    }

    //Reset Ball and Lose Life
    void OnBecameInvisible()
    {
        gameObject.transform.position = originalPos;
        GameObject.Find("Player").transform.position = originalPosPlayer;
        Ball.transform.parent = Player.transform;
        rb.isKinematic = true;
        ballInPlay = false;
        rb.velocity = rb.velocity - rb.velocity;
        lives--;
    }
}