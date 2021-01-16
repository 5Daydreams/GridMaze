using System;
using UnityEngine;

namespace _Code.Toolbox.SimpleValues
{
    public abstract class SimpleValue<T> : ScriptableObject
    {
        public T Value;
    }
}