using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaShell : MonoBehaviour
{
    public bool open;
    public float countdownTimer;

    public GameObject openshell;
    public GameObject closeshell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdownTimer -= Time.deltaTime;
        if (countdownTimer < 0 && open == true)
        {
            open = false;
            closeshell.SetActive(true);
            openshell.SetActive(false);
            countdownTimer = 3;
        }
        else if (countdownTimer < 0 && open == false)
        {
            open = true;
            closeshell.SetActive(false);
            openshell.SetActive(true);
            countdownTimer = 3;
        }
    }
}
