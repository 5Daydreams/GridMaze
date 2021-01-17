using UnityEngine;

namespace _Code.Toolbox.Extensions
{
    public static class FloatExtension
    {
        public static string ConvertSecondsToTimer(this float self)
        {
            int hours = 0;
            string zeroShiftMinutes = "";
            int minutes = 0;
            string zeroShiftSeconds = "";
            int seconds = 0;
            int miliseconds = 0;
        
            while (self / 3600.0f >= 1) // if there`s more than 3600 seconds within the timer
            {
                self -= 3600.0f;
                hours += 1;
            }
        
            while (self / 60.0f >= 1) // if there`s more than 60 seconds within the timer
            {
                self -= 60.0f;
                minutes += 1;
            }
        
            if (minutes < 10)
                zeroShiftMinutes = "0";
        
            seconds = Mathf.FloorToInt(self);
            
            if (seconds < 10)
                zeroShiftSeconds = "0";
        
            miliseconds = Mathf.FloorToInt((self - seconds)* 1000);
            var miliString = miliseconds.ToString();

            while (miliString.Length < 3)
            {
                miliString = "0" + miliString;
            }

            string timerDisplay = hours.ToString() + ":" + zeroShiftMinutes + minutes.ToString() + ":" + zeroShiftSeconds + seconds.ToString() + "." + miliString;
            Debug.Log(timerDisplay);
            return timerDisplay;
        }
    }
}