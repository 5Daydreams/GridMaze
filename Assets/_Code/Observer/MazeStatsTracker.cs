using System;
using System.Collections;
using System.Collections.Generic;
using _Code;
using _Code.Toolbox;
using UnityEngine;

public class MazeStatsTracker : MonoBehaviour
{
    [SerializeField] private FloatValue _timeElapsed;
    [SerializeField] private IntValue _stepsTaken;
    private bool _isRunning = false;

    private void FixedUpdate()
    {
        if (!_isRunning)
            return;
        _timeElapsed.Value += Time.deltaTime;
    }

    public void ResetRunStatistics()
    {
        _stepsTaken.Value = 0;
        _timeElapsed.Value = 0;
    }

    public void RegisterStep()
    {
        _stepsTaken.Value++;
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
