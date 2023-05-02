using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 450;
    public bool timerIsRunning = false;
    public DroneMovement drone;
    public TMP_Text timeText;

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {

            if (drone.isActivated && timeRemaining > 0)
            {
                DisplayTime(timeRemaining);
                timeRemaining -= Time.deltaTime;
            }
            else if (drone.isActivated && timeRemaining <= 0)
            {
                Debug.Log("Time has run out!");

                timeRemaining = 0;
                timerIsRunning = false;

                SceneManager.LoadScene("Fail");
            }
        }
    }

        void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}