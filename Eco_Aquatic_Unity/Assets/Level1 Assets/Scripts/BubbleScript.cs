using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour
{
    Rigidbody2D rb;

    public float force;

    private AudioSource audioSource;
    private SpriteRenderer rend;
    private PolygonCollider2D poly;
    private CircleCollider2D poly2;

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
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            rend = GetComponent<SpriteRenderer>(); // gets sprite renderer

            rend.enabled = false; // sets to false if hit.

            poly2 = GetComponent<CircleCollider2D>();

            poly2.enabled = false;
            Destroy(gameObject, 3f);
        }

        if (other.gameObject.tag == "Fish")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            rend = GetComponent<SpriteRenderer>(); // gets sprite renderer

            rend.enabled = false; // sets to false if hit.

            poly = GetComponent<PolygonCollider2D>();

            poly.enabled = false;

            Destroy(gameObject, 3f);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}