using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerMove : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    public float moveSpeed = 500f;

    public GameObject Player;
    private bool facingRight = true;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * 0);

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
        }
    }

    /*void FixedUpdate()
    {
        if (facingRight == false && Input.touchCount < 0)
        {
            Flip();
        }
        else if (facingRight == true && Input.touchCount < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }*/

}

