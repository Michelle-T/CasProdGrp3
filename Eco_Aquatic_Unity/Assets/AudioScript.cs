using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    public AudioClip MusicClip;
    public AudioClip SfxClip;

    public AudioSource MusicSource;
    public AudioSource SfxSource;



    void Start()
    {
        MusicSource.clip = MusicClip;
        SfxSource.clip = SfxClip;
    }


    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            SfxSource.Play();
        }
    }
}
