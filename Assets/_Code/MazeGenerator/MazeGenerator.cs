using System.Collections;
using System.Collections.Generic;
using _Code.CellTypes;
using _Code.GridTypes;
using _Code.MainCode;
using UnityEngine;
using Random = System.Random;

namespace _Code.MazeGenerator
{
    public class MazeGenerator : GridGenerator<BitArray>
    {
        [SerializeField] private int _pathWidth = 4;
        [SerializeField] private BitArrayCell _cellPrefab;
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private ExitCell _exitPrefab;
        [SerializeField] private VoidEvent _onStart;
        private Player _currPlayer;
        private ExitCell _currExit;
        private int _visitedCells;
        private Stack<Vector2Int> _stack = new Stack<Vector2Int>();

        private Random rng = new Random();

        protected override Cell<BitArray> RegisterPrefab()
        {
            return _cellPrefab;
        }

        protected override void Start()
        {
            base.Start();
            Reset();
            GenerateMaze();
            _onStart.Raise();
        }

        public void NewMaze()
        {
            foreach (var cell in _grid)
            {
                Destroy(cell.gameObject);
            }

            Start();
        }

        public void Reset()
        {
            _stack.Clear(); //mftu
            _stack.Push(Vector2Int.zero);
            _visitedCells = 1;
            PaintAllCells(Color.black);
            ClearValues();
        }

        public void PerformStep() // Debug function
        {
            if (_visitedCells < _gridWidth * _gridHeight)
            {
                RunIteration();
            }

            PaintAllCells(Color.white);
            SetupAllCells();
            TrackCurrentCell();
        }

        public void GenerateMaze()
        {
            while (_visitedCells < _gridWidth * _gridHeight)
            {
                RunIteration();
            }

            SetupAllCells();
            CreateMazeEnds();
        }

        private void SetupAllCells()
        {
            for (int x = 0; x < _gridWidth; x++)
            {
                for (int y = 0; y < _gridHeight; y++)
                {
                    var cell = _grid[x, y] as BitArrayCell;
                    if (cell)
                        cell.CellSetup(_pathWidth);
                }
            }
        }

        private void CreateMazeEnds()
        {
            var playerStartingPosition = _grid[0, _gridHeight - 1].gameObject.transform.position;
            var offset = new Vector3(1, 1, 0) * _cellScaleSize.Value / 2;
            if (!_currPlayer)
                _currPlayer = Instantiate(_playerPrefab, playerStartingPosition + offset, Quaternion.identity);
            _currPlayer.SetPosition(playerStartingPosition + offset);
            _grid[_gridWidth - 1, 0].Value[3] = true;
    
            var exitCell = _grid[_gridWidth - 1, 0].gameObject.transform;
            if (_currExit != null)
                Destroy(_currExit.gameObject);
            _currExit = Instantiate(_exitPrefab, exitCell.position + new Vector3(+0.25f,+0.25f,0), Quaternion.identity);
        }

        private void RunIteration()
        {
            var currPosition = _stack.Peek();
            BitArray openNeighbours = new BitArray(5);
            openNeighbours.SetAll(false);

            // grid[x,y].Value[0] reads whether the cell's path is open or not

            if (currPosition.y < _gridHeight - 1 &&
                _grid[currPosition.x, currPosition.y + 1].Value[0] == false) // NorthOpen
                openNeighbours[1] = true;
            if (currPosition.x < _gridWidth - 1 &&
                _grid[currPosition.x + 1, currPosition.y].Value[0] == false) // EastOpen
                openNeighbours[2] = true;
            if (currPosition.y > 0 &&
                _grid[currPosition.x, currPosition.y - 1].Value[0] == false) // SouthOpen
                openNeighbours[3] = true;
            if (currPosition.x > 0 &&
                _grid[currPosition.x - 1, currPosition.y].Value[0] == false) // WestOpen
                openNeighbours[4] = true;


            if (NeighboursContainsTrue(openNeighbours))
            {
                var nextCellDirection = GetDirection(openNeighbours);

                switch (nextCellDirection)
                {
                    case 1: // North
                        _grid[currPosition.x, currPosition.y].Value[1] = true;
                        _grid[currPosition.x, currPosition.y + 1].Value[3] = true;
                        _stack.Push(new Vector2Int(currPosition.x, currPosition.y + 1));
                        break;
                    case 2: // East
                        _grid[currPosition.x, currPosition.y].Value[2] = true;
                        _grid[currPosition.x + 1, currPosition.y].Value[4] = true;
                        _stack.Push(new Vector2Int(currPosition.x + 1, currPosition.y));
                        break;
                    case 3: // South
                        _grid[currPosition.x, currPosition.y].Value[3] = true;
                        _grid[currPosition.x, currPosition.y - 1].Value[1] = true;
                        _stack.Push(new Vector2Int(currPosition.x, currPosition.y - 1));
                        break;
                    case 4: // West
                        _grid[currPosition.x, currPosition.y].Value[4] = true;
                        _grid[currPosition.x - 1, currPosition.y].Value[2] = true;
                        _stack.Push(new Vector2Int(currPosition.x - 1, currPosition.y));
                        break;
                }

                _grid[currPosition.x, currPosition.y].Value[0] = true;
                _visitedCells++;
            }
            else
            {
                _grid[currPosition.x, currPosition.y].Value[0] = true;
                _stack.Pop();
            }
        }

        private bool NeighboursContainsTrue(BitArray array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i])
                    return true;
            }

            return false;
        }

        private int GetDirection(BitArray neighbours)
        {
            var directionList = new List<int>();

            for (int i = 1; i < neighbours.Length; i++)
            {
                if (neighbours[i] == true)
                {
                    directionList.Add(i);
                }
            }

            var chosenIndex = rng.Next(0, directionList.Count);
            return directionList[chosenIndex];
        }

        private void PaintAllCells(Color32 color)
        {
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    var cell = _grid[i, j] as BitArrayCell;
                    if (cell)
                        cell.PaintCell(color);
                }
            }
        }

        private void TrackCurrentCell()
        {
            var currPosition = _stack.Peek();
            var cell = _grid[currPosition.x, currPosition.y] as BitArrayCell;
            if (cell)
                cell.PaintCell(Color.red);
        }

        private void ClearValues()
        {
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    for (int k = 0; k < _grid[i, j].Value.Length; k++)
                    {
                        var cell = _grid[i, j] as BitArrayCell;
                        if (cell)
                            cell.ResetCellValues();
                    }
                }
            }
        }

        public override void RandomizeAll()
        {
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    for (int k = 0; k < _grid[i, j].Value.Length; k++)
                    {
                        _grid[i, j].Value[k] = rng.Next(0, i + j + 2) % 2 == 0;
                    }
                }
            }
        }
    }
}