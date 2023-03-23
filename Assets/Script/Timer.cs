using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public float timeValue = 90f;
    [SerializeField] TextMeshProUGUI timeText;



    private void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        DisplayTime(timeValue);
    }

    void DisplayTime (float timetoDisplay)
    {
        if (timetoDisplay <= 0)
        {
            timetoDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timetoDisplay / 60);
        float seconds = Mathf.FloorToInt(timetoDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void decreaseTime()
    {
        timeValue -= 5;
    }
}
