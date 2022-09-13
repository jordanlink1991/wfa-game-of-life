using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models.Stats
{
	public class TankStats
	{
		#region Constructors
		public TankStats()
		{
			Reset();
		}
		#endregion Constructors

		#region Properties
		/// <summary>
		/// Number of cells currently alive
		/// </summary>
		public int TotalAlive { get; set; }
		/// <summary>
		/// Number of cells currently dead
		/// </summary>
		public int TotalDead { get; set; }
		/// <summary>
		/// Number of total births
		/// </summary>
		public int TotalBirths { get; set; }
		/// <summary>
		/// Number of total deaths
		/// </summary>
		public int TotalDeaths { get; set; }
		/// <summary>
		/// Number of total cycles
		/// </summary>
		public int TotalCycles { get; set; }
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
			TotalAlive = 0;
			TotalDead = 0;
			TotalBirths = 0;
			TotalDeaths = 0;
			TotalCycles = 0;
			AvgLifespan = 0;
		}
		#endregion Public Methods
	}
}
