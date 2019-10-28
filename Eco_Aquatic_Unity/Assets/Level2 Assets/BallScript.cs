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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballInPlay = false;
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
        Instantiate(Ball, transform.position, transform.rotation);
        Ball.transform.parent = Player.transform;
        ballInPlay = false;
    }
}