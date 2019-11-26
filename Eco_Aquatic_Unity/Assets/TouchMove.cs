using UnityEngine;

public class TouchMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;

    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 1;


    public int lives = 3;

    public GameObject Player;
    private bool facingRight = true;

    //Win Objects
    public GameObject[] winObjectsActiveness;
    public GameObject[] loseObjectsActiveness;

    public GameObject soundfish;
    public GameObject soundtrash;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 10f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x < Screen.width / 2)
                        rb.velocity = new Vector2(0f, -moveSpeed);

                    if (touch.position.x > Screen.width / 2)
                        rb.velocity = new Vector2(0f, moveSpeed);
                    break;

                case TouchPhase.Ended:
                    rb.velocity = new Vector2(0f, 0f);
                    break;
            }
        }
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