using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class UIMove : MonoBehaviour
{
    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 1;
    float directionY;
    Rigidbody2D rb;

    public int lives = 3;

    public GameObject Player;
    private bool facingRight = true;

    //Win Objects
    public GameObject[] winObjectsActiveness;
    public GameObject[] loseObjectsActiveness;

    public GameObject soundfish;
    public GameObject soundtrash;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        directionY = CrossPlatformInputManager.GetAxis("Vertical");
        rb.velocity = new Vector2(0, directionY * 10);

        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
                Flip();
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

        //Lose
        if (lives == 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            foreach (GameObject g in loseObjectsActiveness)
            {
                g.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            Instantiate(soundfish);
            Destroy(other.gameObject);
            GameObject player = GameObject.Find("Penguin");
            PenguinPlayerScript playerScript = player.GetComponent<PenguinPlayerScript>();
            playerScript.AddScore();
        }

        //lose life
        if (other.gameObject.CompareTag("Trash"))
        {
            Instantiate(soundtrash);
            Destroy(other.gameObject);
            lives--;
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
