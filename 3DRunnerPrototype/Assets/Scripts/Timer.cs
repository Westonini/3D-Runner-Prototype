using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [HideInInspector] public float timeElapsed;
    private TextMeshProUGUI timerText;

    private bool timerActive = true;

    void OnEnable()
    {
        PlayerEvents.OnPlayerKilled += PauseTimer;
    }

    void OnDisable()
    {
        PlayerEvents.OnPlayerKilled -= PauseTimer;
    }

    private void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    public void PauseTimer()
    {
        timerActive = false;
    }

    public void UnpauseTimer()
    {
        timerActive = true;
    }

    void Update()
    {
        if (timerActive)
        {
            timeElapsed += Time.deltaTime;
            DisplayText();
        }
    }

    void DisplayText()
    {
        float minutes = Mathf.FloorToInt(timeElapsed / 60);
        float seconds = Mathf.FloorToInt(timeElapsed % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
