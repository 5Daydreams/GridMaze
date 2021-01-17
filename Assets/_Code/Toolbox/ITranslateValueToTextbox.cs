using System;
using System.Collections;
using System.Collections.Generic;
using _Code.Toolbox;
using _Code.Toolbox.SimpleValues;
using UnityEngine;
using UnityEngine.UI;

public interface ITranslateValueToTextbox<T>
{
    Text Textbox { get; }
    SimpleValue<T> SimpleValue { get; }
    void TranslateValueToString();
}