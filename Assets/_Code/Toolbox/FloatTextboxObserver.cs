using System;
using _Code.Toolbox.SimpleValues;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Toolbox
{
    public class FloatTextboxObserver : TranslateValueToTextbox<float>
    {
        public void TranslateValueToTime()
        {
            Debug.Log(_simpleValue.Value.ToString());
            Convert.ToDateTime(_simpleValue.Value.ToString());
            TimeSpan.FromSeconds((double) new decimal(_simpleValue.Value));
            var time = Convert.ToDateTime(_simpleValue.Value);

            // _textbox.text = time.ToString();

            Debug.Log(time.Hour.ToString() + ":" + time.Minute.ToString() + ":" + time.Second.ToString() + ":" +
                      time.Millisecond.ToString());
        }

        #if false
        public string ConvertToTimer(float value)
        {
            int minutes = 0;
            int hours = 0;
            int seconds = 0;
            int miliseconds = 0;
        
            while (value / 3600.0f >= 1) // if there`s more than 60 seconds within the timer
            {
                value -= 3600.0f;
                hours += 1;
            }
        
            while (value / 60.0f >= 1) // if there`s more than 60 seconds within the timer
            {
                value -= 60.0f;
                minutes += 1;
            }
        
            seconds = Convert.ToInt32(value);
            miliseconds = Convert.ToInt32((value - seconds)* 1000);
        
            if (seconds < 10)
                _timeDisplayed.SetValue(minutes + ":0" + Convert.ToInt32(value));
            else
                _timeDisplayed.SetValue(minutes + ":" + Convert.ToInt32(value));
            string timerDisplay = hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString() + ":" + ;
        }
        #endif
    }
}