using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject[] winObjectsActiveness;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Trash").Length <= 0)
        {
            foreach (GameObject g in winObjectsActiveness)
            {
                g.SetActive(true);
            }
        }
    }
}
