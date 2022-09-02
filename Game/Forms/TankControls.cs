using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameOfLife.Models;

namespace GameOfLife.Forms
{
	public partial class TankControls : Form
	{
		#region Private Members
		private readonly TankWindow _window;

		private int _cellsAlive;
		private int _cellsDead;
		private int _totBirths;
		private int _totDeaths;
		private int _totCycles;
		private double _avgLifespan;
		#endregion Private Members

		#region Constructors
		public TankControls(TankWindow window)
		{
			_window = window;
			InitializeComponent();

			TankColorDialog.Color = Color.Black;
			CellColorDialog.Color = Color.LightBlue;

			_window.TankColor = TankColorDialog.Color;
			_window.ShowGrid = ShowGrid.Checked;
			_window.FormClosed += (s, e) => Close();
			_window.Show();

			Reset();
		}
		#endregion Constructors

		#region Tank Options
		/// <summary>
		/// Change the size of the cell
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CellSize_ValueChanged(object sender, EventArgs e) => Reset();

		/// <summary>
		/// Set the value of time in the tank
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Delay_ValueChanged(object sender, EventArgs e) => Timer.Interval = (int)Delay.Value;

		/// <summary>
		/// Change the dentity of the tank
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Density_ValueChanged(object sender, EventArgs e) => Reset();

		/// <summary>
		/// Identifies if the tank grid should be shown
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShowGrid_CheckedChanged(object sender, EventArgs e) => _window.ShowGrid = ShowGrid.Checked;

		/// <summary>
		/// Stop time within the tank
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StopTime_CheckedChanged(object sender, EventArgs e) => Timer.Enabled = !StopTime.Checked;
		#endregion Tank Options

		#region Other Controls
		/// <summary>
		/// Feed the cells to encourange life
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Feed_Click(object sender, EventArgs e) => _window.Tank.FeedCells();

		/// <summary>
		/// Method hit on after every time interval
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Timer_Tick(object sender, EventArgs e)
		{
			_window.Advance(out int newBorns, out int died);

			int totAge = _cellsAlive = 0;
			int totCells = _window.Tank.Rows * _window.Tank.Columns;
			foreach (var cell in _window.Tank.Cells)
				if (cell.IsAlive)
				{
					_cellsAlive++;
					totAge += cell.Age;
				}

			_cellsDead = totCells - _cellsAlive;
			_totBirths += newBorns;
			_totDeaths += died;
			_totCycles++;
			_avgLifespan = _cellsAlive == 0 ? 0 : (double)totAge / _cellsAlive;

			SetStats();
		}
		#endregion Other Controls

		#region Options
		private void ResetButton_Click(object sender, EventArgs e) => Reset();

		private void GliderButton_Click(object sender, EventArgs e) => Reset(CellPatterns.GLIDER);

		private void SpaceshipButton_Click(object sender, EventArgs e) => Reset(CellPatterns.SPACESHIP);

		private void GunButton_Click(object sender, EventArgs e) => Reset(CellPatterns.GUN);

		private void RowButton_Click(object sender, EventArgs e) => Reset(CellPatterns.ROW);

		private void SunButton_Click(object sender, EventArgs e) => Reset(CellPatterns.SUN);

		private void CellColorButton_Click(object sender, EventArgs e)
		{
			if (CellColorDialog.ShowDialog() != DialogResult.OK)
				return;

			foreach (Cell cell in _window.Tank.Cells)
				cell.Color = CellColorDialog.Color;
		}

		private void TankColorButton_Click(object sender, EventArgs e)
		{
			if (TankColorDialog.ShowDialog() != DialogResult.OK)
				return;
			_window.TankColor = TankColorDialog.Color;
		}
		#endregion Options

		#region Private Methods
		/// <summary>
		/// Reset the state of the tank
		/// </summary>
		private void Reset()
		{
			ResetStats();
			SetStats();

			_window.Reset((int)CellSize.Value, CellColorDialog.Color, (double)Density.Value);
		}

		/// <summary>
		/// Reset the state of the tank
		/// </summary>
		private void Reset(string pattern)
		{
			ResetStats();
			SetStats();
			_window.Reset((int)CellSize.Value, CellColorDialog.Color);
			_window.InjectPattern(pattern);
		}

		/// <summary>
		/// Reset the state of the tank
		/// </summary>
		private void ResetStats()
		{
			_cellsAlive = 0;
			_cellsDead = 0;
			_totBirths = 0;
			_totDeaths = 0;
			_totCycles = 0;
			_avgLifespan = 0;
			SetStats();
		}

		/// <summary>
		/// Set the values for the stats
		/// </summary>
		private void SetStats()
		{
			TotAlive.Text = _cellsAlive.ToString();
			TotDead.Text = _cellsDead.ToString();
			AvgLifespan.Text = string.Format("{0:0.##}", _avgLifespan);
			TotBirths.Text = _totBirths.ToString();
			TotDeaths.Text = _totDeaths.ToString();
			TotCycles.Text = _totCycles.ToString();
		}
		#endregion Private Methods
	}
}
