using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerValueText;

    private float elapsedTime;


    void Update()
    {
        TimeHandler();
    }


    private void TimeHandler()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerValueText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

}
