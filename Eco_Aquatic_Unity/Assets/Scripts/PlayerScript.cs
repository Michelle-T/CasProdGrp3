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

    void Start()
    {
        score = 0;
    }

    //shooting
    void Update()
    {
     
        if (canShoot && Input.GetMouseButton(1))
        {
            canShoot = false;
            Instantiate(bubble, transform.position, transform.rotation);
            StartCoroutine(NoFire());
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