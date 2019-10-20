using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public GameObject bubble;
    public float delayTime;
    bool canShoot = true;

    public Text scoreText;
    public int score;

    private const float doubleClickTime = .2f;
    private float lastClickTime;

    void Start()
    {
        score = 0;
    }

    //shooting
    void Update()
    {
     
        if (Input.GetMouseButton(0) && canShoot)
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickTime)
            {
                canShoot = false;
                Instantiate(bubble, transform.position, transform.rotation);
                StartCoroutine(NoFire());
            }

            lastClickTime = Time.time;
        }

        scoreText.text = "Score: " + score;
    }

    IEnumerator NoFire()
    {
        yield return new WaitForSeconds(delayTime);
        canShoot = true;
    }

    public void AddScore ()
    {
        score = score += 1;
    }
}