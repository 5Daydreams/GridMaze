using System;
using System.Collections;
using System.Collections.Generic;
using _Code;
using _Code.Toolbox;
using _Code.Toolbox.SimpleValues;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private FloatValue _timeElapsed;
    private bool _isRunning = false;

    private void FixedUpdate()
    {
        if (!_isRunning)
            return;
        _timeElapsed.Value += Time.deltaTime;
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
