using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public int speed = 1;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
