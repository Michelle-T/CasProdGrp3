using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatesTest : MonoBehaviour
{
    public int count;
    public float CountdownFrom;
    public Text testText;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //testText.text = (count + 1);
        float time = CountdownFrom - Time.timeSinceLevelLoad;
        testText.text = "Time left: " + time.ToString("0.00") + "s";

        if (time <= 0f)
        {
            TimeUp();
        }
    }
    
    void TimeUp()
    {

    }

}
