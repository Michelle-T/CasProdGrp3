using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bubble")
        {
            GameObject player = GameObject.Find("Player");
            PlayerScript playerScript = player.GetComponent<PlayerScript>();
            playerScript.AddScore();

            Destroy(gameObject);
        }
    }
}
