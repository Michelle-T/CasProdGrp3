﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool isMute;

    public GameObject Mutet;
    public GameObject Unmute;

    bool isPaused = false;

    public GameObject[] pauseObjectsActiveiness;

    // Start is called before the first frame update
    void Start()
    {
        pauseObjectsActiveiness = GameObject.FindGameObjectsWithTag("Pause");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1 && Input.GetKeyDown("space"))
        {
            isPaused = true;
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0 && Input.GetKeyDown("space"))
        {
            isPaused = false;
            Time.timeScale = 1; //Resume Game..
            showPaused();
        }
    }

    public void NewGame()
    {
        Debug.Log("SceneName to load: Level 1");
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("has quit game");
        Application.Quit();
    }

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }

    public void Level1()
    {
        Debug.Log("SceneName to load: Level 1");
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        Debug.Log("SceneName to load: Level 2");
        SceneManager.LoadScene("Level2");
    }

    public void MainMenu()
    {
        Debug.Log("SceneName to load: MainMenu");
        SceneManager.LoadScene("MainMenu");
    }

    void OnGUI()
    {
        if (isPaused)
            GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
    }

    /*void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
    }

    public void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }*/

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            isPaused = true;
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            isPaused = false;
            Time.timeScale = 1; //Resume Game..
            showPaused();
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
    }

    public void showPaused()
    {
        if (isPaused == true)
        {
            foreach (GameObject g in pauseObjectsActiveiness)
            {
                g.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject g in pauseObjectsActiveiness)
            {
                g.SetActive(false);
            }
        }
    }

    public void MuteText()
    {
        if (isMute == true)
        {
            Mutet.SetActive(false);
            Unmute.SetActive(true);
        }
        else
        {
            Mutet.SetActive(true);
            Unmute.SetActive(false);
        }
    }
}