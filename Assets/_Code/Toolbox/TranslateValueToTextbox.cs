using System;
using System.Collections;
using System.Collections.Generic;
using _Code.Toolbox;
using _Code.Toolbox.SimpleValues;
using UnityEngine;
using UnityEngine.UI;

public class TranslateValueToTextbox<T> : MonoBehaviour
{
    [SerializeField] protected Text _textbox;
    [SerializeField] protected SimpleValue<T> _simpleValue;

    public void TranslateValueToString(T value)
    {
        var text = _simpleValue.Value.ToString();
        _textbox.text = text;
    }
}