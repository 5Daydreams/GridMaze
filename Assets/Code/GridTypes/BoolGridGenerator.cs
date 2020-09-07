using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class BoolGridGenerator : MonoBehaviour
{
    [SerializeField] private int _gridWidth;
    [SerializeField] private int _gridHeight;
    [SerializeField] private float _cellSize;
    [SerializeField] private BoolCell _cellPrefab;
    private BoolGrid _boolGrid;
    private List<BoolCell> _stack;

    private void Start()
    {
        RecenterThis();
        _boolGrid = new BoolGrid(_gridWidth, _gridHeight, _cellSize);
        CreateInScene();
        _boolGrid.RandomizeAll();
    }

    private void RecenterThis()
    {
        var screenCenterPos = new Vector3(0.5f, 0.5f, 0.0f);
        var offsetPosition = new Vector3(-_gridWidth / 2.0f, -_gridHeight / 2.0f, 0.0f);
        this.transform.position = (screenCenterPos + offsetPosition) * _cellSize;
    }

    private void CreateInScene()
    {
        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {
                var basePos = new Vector3(i * _cellSize, j * _cellSize, 0);
                var cellPos = basePos + this.transform.position;
                _boolGrid.GridArray[i, j] = Instantiate(_cellPrefab, cellPos, quaternion.identity);
                _boolGrid.GridArray[i, j].transform.SetParent(this.transform);
                _boolGrid.GridArray[i, j].gameObject.name = "( " + i + ", " + j + " )";
            }
        }
    }

    public void EditorCallRandomizeAll()
    {
        _boolGrid.RandomizeAll();
    }

    private void SetAll(bool value)
    {
        for (int i = 0; i < _boolGrid.GridArray.GetLength(0); i++)
        {
            for (int j = 0; j < _boolGrid.GridArray.GetLength(1); j++)
            {
                _boolGrid.GridArray[i, j].SetCellValue(value);
            }
        }
    }
}