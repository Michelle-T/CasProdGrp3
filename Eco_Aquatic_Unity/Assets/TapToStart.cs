using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            Debug.Log("SceneName to load: MainMenu");
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("SceneName to load: MainMenu");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
