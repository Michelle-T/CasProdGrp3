using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    bool isMute;
    public GameObject Mutet;
    public GameObject Unmute;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
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
