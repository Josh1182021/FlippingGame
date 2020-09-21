using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] UpdateText timerText;
    float startTime;
    [SerializeField] float startingTimeLimit = 10;
    float currentTimeLimit;

    bool timerActive = true;

    void Start()
    {
        startTime = Time.time;
        currentTimeLimit = startingTimeLimit;
    }

    void Update()
    {
        //float t = Time.time - startTime;

        if (timerActive)
            {
            currentTimeLimit -= Time.deltaTime;

            string minutes = ((int)currentTimeLimit / 60).ToString();
            string seconds = (currentTimeLimit % 60).ToString("f2");

            timerText.UpdateTextAs(minutes + ":" + seconds);
        }
    }

    public void PauseTimer()
    {
        timerActive = false;
    }
    public void ResumeTimer()
    {
        timerActive = true;
    }

    public void AddTime(float time)
    {
        currentTimeLimit += time;
    }
}
