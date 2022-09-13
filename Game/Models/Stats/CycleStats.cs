using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models.Stats
{
	public class CycleStats
	{
		#region Constructors
		public CycleStats()
		{
			Reset();
		}
		#endregion Constructors

		#region Properties
		/// <summary>
		/// Number of cells currently alive
		/// </summary>
		public int CellsAlive { get; set; }
		/// <summary>
		/// Number of cells currently dead
		/// </summary>
		public int CellsDead { get; set; }
		/// <summary>
		/// Number of total births
		/// </summary>
		public int CellsBorn { get; set; }
		/// <summary>
		/// Number of total deaths
		/// </summary>
		public int CellsDied { get; set; }
		/// <summary>
		/// Average lifespan of a cell
		/// </summary>
		public double AvgLifespan { get; set; }
		#endregion Properties

		#region Public Methods
		/// <summary>
		/// Reset stats
		/// </summary>
		public void Reset()
		{
			CellsAlive = 0;
			CellsDead = 0;
			CellsBorn = 0;
			CellsDied = 0;
			AvgLifespan = 0;
		}
		#endregion Public Methods
	}
}
