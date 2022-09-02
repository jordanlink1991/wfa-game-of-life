using System.Collections.Generic;
using System.Linq;
using GameOfLife.Enums;

namespace GameOfLife.Models
{
    /// <summary>
    /// Represents a space within the tank
    /// </summary>
    public class Cell
    {
		#region Constructors
		public Cell()
        {
            Neighbors = new List<Cell>();
            State = CellState.Dead;
            IsFed = false;
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Age of the cell
        /// </summary>
        public int Age { get; private set; }
        /// <summary>
        /// Identifies if the cell has been fed
        /// </summary>
        public bool IsFed { get; set; }
        /// <summary>
        /// Cell neighbors
        /// </summary>
        public List<Cell> Neighbors { get; set; }
        /// <summary>
        /// Represents the state of the cell
        /// </summary>
        public CellState State { get; set; }
        /// <summary>
        /// Represents if the cell is currently allive
        /// </summary>
        public bool IsAlive => State == CellState.Alive || State == CellState.ToDie;
        #endregion Properties

        #region Public Methods
        /// <summary>
        /// Determine the next state of the space based on the state of its neighbors and the cell itself
        /// </summary>
        public void DetermineNextState()
        {
            var liveNeighbors = Neighbors.Where(x => x.IsAlive);
            var liveNeighborCount = liveNeighbors.Count();
            var areNeighborsFed = liveNeighbors.All(x => x.IsFed);

            if (IsAlive && IsFed)
            {
                if (liveNeighborCount < 1 || liveNeighborCount > 4)
                    State = CellState.ToDie;
            }
            else if (IsAlive)
            {
                // Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                // Any live cell with more than three live neighbours dies, as if by overpopulation.
                // Any live cell with two or three live neighbours lives on to the next generation.
                if (liveNeighborCount < 2 || liveNeighborCount > 3)
                    State = CellState.ToDie;
            }
            else
            {
                // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                if ((areNeighborsFed && liveNeighborCount >= 3)
                    || liveNeighborCount == 3)
                    State = CellState.ToBeBorn;
            }
        }

        /// <summary>
        /// Update the state of the cell
        /// </summary>
        public void Update()
        {
            if (State == CellState.ToDie)
                State = CellState.Dead;
            else if (State == CellState.ToBeBorn)
                State = CellState.Alive;

            if (IsAlive)
            {
                Age++;
                if (IsFed)
                    IsFed = false;
            }
            else
            {
                Age = 0;
            }
        }
        #endregion Public Methods
    }
}
