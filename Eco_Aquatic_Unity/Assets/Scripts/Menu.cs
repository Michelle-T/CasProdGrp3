using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool isMute;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
}
