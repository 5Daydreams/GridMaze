using System;
using _Code.Toolbox.Extensions;
using _Code.Toolbox.SimpleValues;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Toolbox
{
    public class FloatTextboxObserver : TranslateValueToTextbox<float>
    {
        public void TranslateValueToTime()
        {
            var timerText = _simpleValue.Value.ConvertSecondsToTimer();
            _textbox.text = timerText;
        }
    }
}