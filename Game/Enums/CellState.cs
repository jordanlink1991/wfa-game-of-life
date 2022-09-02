using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Enums
{
    /// <summary>
    /// Represents the state of a cell
    /// </summary>
    public enum CellState
    {
        Dead,
        ToBeBorn,
        ToDie,
        Alive
    }
}
