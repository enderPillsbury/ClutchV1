using UnityEngine;
using TMPro;
using System;


public class Timer : MonoBehaviour
{
    private bool _timerActive;
    private float _currentTime;
    [SerializeField] private TMP_Text _text;

    void Start()
    {
        _currentTime = 0;
        startTimer();

    }
    void Update()
    {
        if (_timerActive)
        {
            _currentTime = _currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _text.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();

    }
    public void startTimer()
    {
        _timerActive = true;
    }
}
//Code from Eric Veciana on Medium article "Creating a Stopwatch/Timer in Unity"