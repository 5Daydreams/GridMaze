using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CustomScriptables/DebugMessager")]
public class EventLog : ScriptableObject
{
    public void ConsoleLog(string message)
    {
        Debug.Log(message);
    }
}
