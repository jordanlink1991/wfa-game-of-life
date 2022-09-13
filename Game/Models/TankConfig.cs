using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
	public class TankConfig
	{
		#region Constructors
		public TankConfig()
		{
			CellSize = 10;
			CycleTime = 100;
			RandomDensity = 15;
			TankColor = Color.Black;
			CellColor = Color.LightBlue;
			FreezeTime = false;
			ShowGrid = true;
		}
		#endregion Constructors

		#region Properties
		/// <summary>
		/// Size of the cells
		/// </summary>
		public int CellSize { get; set; }
		/// <summary>
		/// Time between cycles
		/// </summary>
		public int CycleTime { get; set; }
		/// <summary>
		/// Random density
		/// </summary>
		public int RandomDensity { get; set; }
		/// <summary>
		/// Color of the tank background
		/// </summary>
		public Color TankColor { get; set; }
		/// <summary>
		/// Color of the cells
		/// </summary>
		public Color CellColor { get; set; }
		/// <summary>
		/// Flag for freezing time
		/// </summary>
		public bool FreezeTime { get; set; }
		/// <summary>
		/// Flag for showing the grid
		/// </summary>
		public bool ShowGrid { get; set; }
		#endregion Properties
	}
}
