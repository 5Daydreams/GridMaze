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
    [SerializeField] private DifficultyHolder _difficultyHolder;
    
    public void SetMazeDimensions()
    {
        var difficulty = _difficultyHolder.GetDifficulty();
        
        _generator.SetGridHeight(difficulty.MazeWidth);
        _generator.SetGridHeight(difficulty.MazeHeight);
    }
}
