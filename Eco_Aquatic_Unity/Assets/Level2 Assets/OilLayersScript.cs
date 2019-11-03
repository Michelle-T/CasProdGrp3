using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilLayersScript : MonoBehaviour
{
    public GameObject oilLayer1;
    public GameObject oilLayer2;
    public GameObject oilLayer3;
    public GameObject oilLayer4;

    AudioSource audioData;
    public AudioClip impact;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Trash").Length == 30)
        {
            Destroy(oilLayer1);
            playSound();
        }

        if (GameObject.FindGameObjectsWithTag("Trash").Length == 20)
        {
            Destroy(oilLayer2);
            playSound();
        }

        if (GameObject.FindGameObjectsWithTag("Trash").Length == 10)
        {
            Destroy(oilLayer3);
            playSound();
        }

        if (GameObject.FindGameObjectsWithTag("Trash").Length == 0)
        {
            Destroy(oilLayer4);
            playSound();
        }
    }

    void playSound()
    {
        audioData.PlayOneShot(impact, 0.7F);
    }
}
