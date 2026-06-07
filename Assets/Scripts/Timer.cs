using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float time;
    public bool timerActive = false;
    public TMP_Text timerText;

    void Start()
    {
        time = 0f;
        //timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive){
            time += Time.deltaTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            int minutes = timeSpan.Minutes;
            int seconds = timeSpan.Seconds;
            timerText.text =  minutes.ToString() + ":" + seconds.ToString("D2");
        }
    }
}
