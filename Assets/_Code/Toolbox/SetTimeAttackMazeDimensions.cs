using System;
using System.Collections;
using System.Collections.Generic;
using _Code.GridTypes;
using _Code.MazeGenerator;
using _Code.Toolbox.SimpleValues;
using UnityEngine;

public class SetTimeAttackMazeDimensions : MonoBehaviour
{
    [SerializeField] private MazeGenerator _generator;
    [SerializeField] private IntValue _width;
    [SerializeField] private IntValue _height;
    
    private void Start()
    {
        _generator.SetGridHeight(_width.Value);
        _generator.SetGridHeight(_height.Value);
    }
}
