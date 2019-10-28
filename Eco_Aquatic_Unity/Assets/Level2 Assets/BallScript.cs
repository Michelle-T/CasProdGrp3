using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float ballInitialVelocity = 1f;
    public float maxSpeed = 2f;

    private Rigidbody2D rb;
    private bool ballInPlay;

    //DoubleClickVariables
    private const float doubleClickTime = .2f;
    private float lastClickTime;

    public Transform Ball;
    public Transform Player;

    Vector3 originalPos;
    Vector3 originalPosPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballInPlay = false;

        originalPos = gameObject.transform.position;
        originalPosPlayer = GameObject.Find("Player").transform.position;
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

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    //Trash Breaking
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            Destroy(collision.gameObject);
        }
    }

    //Reset Ball
    void OnBecameInvisible()
    {
        gameObject.transform.position = originalPos;
        GameObject.Find("Player").transform.position = originalPosPlayer;
        Ball.transform.parent = Player.transform;
        rb.isKinematic = true;
        ballInPlay = false;
        rb.velocity = rb.velocity - rb.velocity;
    }
}