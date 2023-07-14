using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;

    [SerializeField] private Text TimeText;

    [SerializeField] private bool timerActive;

    //keeps track of time and displays it in min sec 

    // Start is called before the first frame update
    void Start()
    {

        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            time += Time.deltaTime;
            FormatText();
        }
    }

    private void FormatText()
    {
        int minutes = (int)(time / 60) % 60;
        float seconds = time % 60;

        string secondsS = seconds.ToString("F2");

        TimeText.text = "Time " + minutes + ":" + secondsS;
    }

    public void ReturnToNormalTime()
    {
        Time.timeScale = 1f;
        FormatText();
        Debug.Log("time returned to normal");
    }

    public void SlowTime(float seconds)
    {
        Time.timeScale = 0.45f;
        
        FormatText();
        
        Invoke("ReturnToNormalTime", seconds);
        
    }
}