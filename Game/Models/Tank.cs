using System;
using System.Drawing;
using GameOfLife.Enums;
using GameOfLife.Models.Stats;

namespace GameOfLife.Models
{
    /// <summary>
    /// Represents a container of cells, like a fish tank!
    /// </summary>
    public class Tank
    {
        #region Private Members
        private readonly Random _random;
        #endregion Private Members

        #region Constructors
        public Tank(int width, int height, int cellSize, bool wrap = true)
        {
            _random = new Random();

            Cells = new Cell[width / cellSize, height / cellSize];
            Width = Columns * cellSize;
            Height = Rows * cellSize;
            for (int x = 0; x < Columns; x++)
                for (int y = 0; y < Rows; y++)
                    Cells[x, y] = new Cell();

            ConnectCells(wrap);
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Cells in the tank
        /// </summary>
        public Cell[,] Cells { get; private set; }
        /// <summary>
        /// Amount of columns in the tank
        /// </summary>
		public int Columns => Cells.GetLength(0);
        /// <summary>
        /// Amount of rows in the tank
        /// </summary>
        public int Rows => Cells.GetLength(1);
        /// <summary>
        /// Width of the tank
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// Height of the tank
        /// </summary>
        public int Height { get; private set; }
        #endregion Properties

        #region Indexers
        /// <summary>
        /// Get the cell at the index
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Cell this[int x, int y] => Cells[x, y];
        #endregion Indexers

        #region Public Methods
        /// <summary>
        /// Randomize the state of the tank
        /// </summary>
        /// <param name="liveDensity"></param>
        public void Randomize(double liveDensity)
        {
            foreach (var cell in Cells)
                cell.State = (_random.NextDouble() < liveDensity) ? CellState.Alive : CellState.Dead;
        }

        /// <summary>
        /// Using a known pattern filled with 'x's, set the state of the cells from 
        /// the center of the tank
        /// </summary>
        /// <param name="pattern"></param>
        public void BirthPattern(string pattern)
        {
            string[] lines = pattern.Split('\n');
            int yOffset = (Rows - lines.Length) / 2;
            int xOffset = (Columns - lines[0].Length) / 2;

            for (int y = 0; y < lines.Length; y++)
                for (int x = 0; x < lines[y].Length; x++)
                    if(lines[y].Substring(x, 1) == "X")
                        Cells[x + xOffset, y + yOffset].State = CellState.Alive;
        }

        /// <summary>
        /// Update all the cells
        /// </summary>
        public CycleStats Advance()
        {
            // Determine the next state of the cell
            CycleStats stats = new CycleStats();
            foreach (var cell in Cells)
            {
                cell.DetermineNextState();
                if (cell.State == CellState.ToBeBorn)
                    stats.CellsBorn++;
                else if (cell.State == CellState.ToDie)
                    stats.CellsDied++;
            }

            // Update cell states
            int totAge = 0;
            foreach (var cell in Cells)
            {
                cell.Update();
                if (cell.State == CellState.Alive)
                {
                    stats.CellsAlive++;
                    totAge += cell.Age;
                }
                else if (cell.State == CellState.Dead)
                {
                    stats.CellsDead++;
                }
            }

            // Determine lifespan
            stats.AvgLifespan = stats.CellsAlive == 0 ? 0 : (double)totAge / stats.CellsAlive;

            return stats;
        }

        /// <summary>
        /// Update all the cells
        /// </summary>
        public void Advance(out int newBorns, out int died)
        {
            died = newBorns = 0;
            foreach (var cell in Cells)
            {
                cell.DetermineNextState();
                if (cell.State == CellState.ToBeBorn)
                    newBorns++;
                else if (cell.State == CellState.ToDie)
                    died++;
            }
        }

        /// <summary>
        /// Feed all the alive cells
        /// </summary>
        public void Feed()
        {
            foreach (var cell in Cells)
                cell.IsFed = cell.IsAlive;
        }
        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Connect a cell with its neighbors
        /// </summary>
        /// <param name="wrap"></param>
        private void ConnectCells(bool wrap)
        {
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    // Determine if cell is on the side of the tank
                    bool isLeftEdge = x == 0;
                    bool isRightEdge = x == Columns - 1;
                    bool isTopEdge = y == 0;
                    bool isBottomEdge = y == Rows - 1;
                    bool isEdge = isLeftEdge || isRightEdge || isTopEdge || isBottomEdge;
                    
                    if (!wrap && isEdge)
                        continue;

                    // Determine location of the neighbors
                    int leftNeighbor = isLeftEdge ? Columns - 1 : x - 1;
                    int rightNeighbor = isRightEdge ? 0 : x + 1;
                    int topNeighbor = isTopEdge ? Rows - 1 : y - 1;
                    int bottomNeighbor = isBottomEdge ? 0 : y + 1;

                    // Add the neighbors
                    var currentCell = Cells[x, y];
                    currentCell.Neighbors.Add(Cells[leftNeighbor, topNeighbor]);
                    currentCell.Neighbors.Add(Cells[x, topNeighbor]);
                    currentCell.Neighbors.Add(Cells[rightNeighbor, topNeighbor]);
                    currentCell.Neighbors.Add(Cells[leftNeighbor, y]);
                    currentCell.Neighbors.Add(Cells[rightNeighbor, y]);
                    currentCell.Neighbors.Add(Cells[leftNeighbor, bottomNeighbor]);
                    currentCell.Neighbors.Add(Cells[x, bottomNeighbor]);
                    currentCell.Neighbors.Add(Cells[rightNeighbor, bottomNeighbor]);
                }
            }
        }
		#endregion Private Methods
    }
}
