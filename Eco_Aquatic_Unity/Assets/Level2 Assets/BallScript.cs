using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float ballInitialVelocity = 600f;


    private Rigidbody2D rb;
    private bool ballInPlay;

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        ballInPlay = false;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            Destroy(collision.gameObject);
        }
    }
}