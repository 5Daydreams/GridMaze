using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeStatsTracker : MonoBehaviour
{
    private float _timeElapsed = 0;
    private float _storedTime = 0;
    private int _stepsTaken = 0;
    [SerializeField] private bool _isRunning = false;

    private void FixedUpdate()
    {
        if (!_isRunning)
            return;
        _timeElapsed += Time.deltaTime;
    }

    public void ResetRunStatistics()
    {
        _stepsTaken = 0;
        _storedTime = 0;
        _timeElapsed = 0;
    }

    public void RegisterStep()
    {
        _stepsTaken++;
    }

    public void StopTimer()
    {
        _isRunning = false;
    }
    
    public void ResumeTimer()
    {
        _isRunning = true;
    }
    
}
