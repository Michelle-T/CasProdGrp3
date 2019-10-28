using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour
{
    Rigidbody2D rb;

    public float force;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 directon = new Vector3(0, force, 0);
        rb.AddForce(directon, ForceMode2D.Impulse);
    }
       void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trash")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Fish")
        {
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}