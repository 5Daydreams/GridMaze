using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using _Code.MainCode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LargeInputBox : MonoBehaviour
{
    [SerializeField] private List<InputField> _inputFields; // Change this to the sliders
    [SerializeField] private Button _closeWindowButton;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private MazeGenerator _maze;
    // [SerializeField] private List<UnityEvent<int>> _eventList = new List<UnityEvent<int>>();


    private void OnEnable()
    {
        if (!gameObject.activeInHierarchy)
            return;
        _closeWindowButton.onClick.AddListener(() => CloseThisWindow());
        _confirmButton.onClick.AddListener(() =>
        {
            _maze.NewMaze();
            _maze.GenerateMaze();
            CloseThisWindow();
        });
    }
    
    public void CloseThisWindow()
    {
        this.gameObject.SetActive(false);
    }

    public void OpenThisWindow()
    {
        this.gameObject.SetActive(true);
    }
}