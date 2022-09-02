using System;
using System.Drawing;
using GameOfLife.Enums;

namespace GameOfLife.Models
{
    /// <summary>
    /// Represents a container of cells, like a fish tank!
    /// </summary>
    public class Tank
    {
        #region Private Members
        private readonly Cell[,] _cells;
        private readonly Random _random;
        #endregion Private Members

        #region Constructors
        public Tank(int width, int height, int cellSize, Color cellColor, bool wrap = true)
        {
            _random = new Random();

            _cells = new Cell[width / cellSize, height / cellSize];
            for (int x = 0; x < Columns; x++)
                for (int y = 0; y < Rows; y++)
                    _cells[x, y] = new Cell();

            CellSize = cellSize;
            CellColor = cellColor;
            ConnectCells(wrap);
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Size of the cells
        /// </summary>
        public int CellSize { get; private set; }
        /// <summary>
        /// Amount of columns in the tank
        /// </summary>
		public int Columns => _cells.GetLength(0);
        /// <summary>
        /// Amount of rows in the tank
        /// </summary>
        public int Rows => _cells.GetLength(1);
        /// <summary>
        /// Width of the tank
        /// </summary>
        public int Width => Columns * CellSize;
        /// <summary>
        /// Height of the tank
        /// </summary>
        public int Height => Rows * CellSize;
        /// <summary>
        /// Color of the cells in the tank
        /// </summary>
        public Color CellColor { get; set; }
        #endregion Properties

        #region Public Methods
        /// <summary>
        /// Randomize the state of the tank
        /// </summary>
        /// <param name="liveDensity"></param>
        public void Randomize(double liveDensity)
        {
            foreach (var cell in _cells)
                cell.State = (_random.NextDouble() < liveDensity) ? CellState.Alive : CellState.Dead;
        }

        /// <summary>
        /// Using a known pattern filled with 'x's, set the state of 
        /// the cells from the center of the tank
        /// </summary>
        /// <param name="pattern"></param>
        public void InjectPattern(string pattern)
        {
            string[] lines = pattern.Split('\n');
            int yOffset = (Rows - lines.Length) / 2;
            int xOffset = (Columns - lines[0].Length) / 2;

            for (int y = 0; y < lines.Length; y++)
                for (int x = 0; x < lines[y].Length; x++)
                    if(lines[y].Substring(x, 1) == "X")
                        _cells[x + xOffset, y + yOffset].State = CellState.Alive;
        }

        /// <summary>
        /// Update all the cells
        /// </summary>
        public void Advance(out int newBorns, out int died)
        {
            died = newBorns = 0;
            foreach (var cell in _cells)
            {
                cell.DetermineNextState();
                if (cell.State == CellState.ToBeBorn)
                    newBorns++;
                else if (cell.State == CellState.ToDie)
                    died++;
            }
            
            foreach (var cell in _cells)
                cell.Update();
        }

        /// <summary>
        /// Returns the alive state of the cell at the given position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsCellAlive(int x, int y) => _cells[x, y].IsAlive;

        /// <summary>
        /// Feed all the alive cells
        /// </summary>
        public void FeedCells()
        {
            foreach (var cell in _cells)
                if (cell.IsAlive)
                    cell.IsFed = true;
        }

        /// <summary>
        /// Get metrics of the live cells
        /// </summary>
        /// <param name="alive"></param>
        /// <param name="avgLifespan"></param>
        public void GetAliveCellMetrics(out int alive, out double avgLifespan)
        {
            int totAge = alive = 0;
            foreach (var cell in _cells)
                if (cell.IsAlive)
                {
                    alive++;
                    totAge += cell.Age;
                }

            avgLifespan = alive == 0 ? 0 : (double)totAge / alive;
        }
        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Connect a cell with its neigbors
        /// </summary>
        /// <param name="wrap"></param>
        private void ConnectCells(bool wrap)
        {
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    // Determine if cell is on the side of the tank
                    bool isLeftEdge = (x == 0);
                    bool isRightEdge = (x == Columns - 1);
                    bool isTopEdge = (y == 0);
                    bool isBottomEdge = (y == Rows - 1);
                    bool isEdge = isLeftEdge || isRightEdge || isTopEdge || isBottomEdge;
                    if (!wrap && isEdge)
                        continue;

                    // Determine location of the neighbors
                    int leftNeighbor = isLeftEdge ? Columns - 1 : x - 1;
                    int rightNeighbor = isRightEdge ? 0 : x + 1;
                    int topNeighbor = isTopEdge ? Rows - 1 : y - 1;
                    int bottomNeighbor = isBottomEdge ? 0 : y + 1;

                    // Add the neighbors
                    _cells[x, y].Neighbors.Add(_cells[leftNeighbor, topNeighbor]);
                    _cells[x, y].Neighbors.Add(_cells[x, topNeighbor]);
                    _cells[x, y].Neighbors.Add(_cells[rightNeighbor, topNeighbor]);
                    _cells[x, y].Neighbors.Add(_cells[leftNeighbor, y]);
                    _cells[x, y].Neighbors.Add(_cells[rightNeighbor, y]);
                    _cells[x, y].Neighbors.Add(_cells[leftNeighbor, bottomNeighbor]);
                    _cells[x, y].Neighbors.Add(_cells[x, bottomNeighbor]);
                    _cells[x, y].Neighbors.Add(_cells[rightNeighbor, bottomNeighbor]);
                }
            }
        }
		#endregion Private Methods
    }
}
