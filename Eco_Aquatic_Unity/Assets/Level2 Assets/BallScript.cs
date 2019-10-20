using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float ballInitialVelocity = 1f;
    public float maxSpeed = 2f;

    private Rigidbody2D rb;
    private bool ballInPlay;

    private const float doubleClickTime = .2f;
    private float lastClickTime;

    void Awake()
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

        if (GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
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
}