using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtlePlayerScript : MonoBehaviour
{
    public GameObject Player;
    private bool facingRight = true;

    void FixedUpdate()
    {
        if (facingRight == false && Player.transform.position.x > 175)
        {
            Flip();
        }
        else if (facingRight == true && Player.transform.position.x < 175)
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
    }
}
