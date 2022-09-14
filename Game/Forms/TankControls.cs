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
using GameOfLife.Models.Stats;

namespace GameOfLife.Forms
{
	public partial class TankControls : Form
	{
		#region Private Members
		private readonly TankWindow _window;
		private readonly TankConfig _config;
		private readonly TankStats _stats;
		#endregion Private Members

		#region Constructors
		public TankControls(TankWindow window)
		{
			_window = window;
			_config = new TankConfig();
			_stats = new TankStats();

			InitializeComponent();

			TankColorDialog.Color = _config.TankColor;
			CellColorDialog.Color = _config.CellColor;
			CellSize.Value = _config.CellSize;
			CycleTime.Value = Timer.Interval = _config.CycleTime;
			RandomDensity.Value = _config.RandomDensity;
			FreezeTime.Checked = _config.FreezeTime;
			Timer.Enabled = !_config.FreezeTime;
			ShowGrid.Checked = _config.ShowGrid;

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
		private void CellSize_ValueChanged(object sender, EventArgs e)
		{
			_config.CellSize = (int)CellSize.Value;
			Reset();
		}

		/// <summary>
		/// Set the value of time in the tank
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Delay_ValueChanged(object sender, EventArgs e) => Timer.Interval = _config.CycleTime = (int)CycleTime.Value;

		/// <summary>
		/// Change the dentity of the tank
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Density_ValueChanged(object sender, EventArgs e)
		{
			_config.RandomDensity = (int)RandomDensity.Value;
			Reset();
		}

		/// <summary>
		/// Identifies if the tank grid should be shown
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShowGrid_CheckedChanged(object sender, EventArgs e) => _config.ShowGrid = ShowGrid.Checked;

		/// <summary>
		/// Stop time within the tank
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StopTime_CheckedChanged(object sender, EventArgs e)
		{
			_config.FreezeTime = FreezeTime.Checked;
			Timer.Enabled = !_config.FreezeTime;
		}
		#endregion Tank Options

		#region Other Controls
		/// <summary>
		/// Feed the cells to encourange life
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Feed_Click(object sender, EventArgs e) => _window.Tank.Feed();

		/// <summary>
		/// Method hit on after every time interval
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Timer_Tick(object sender, EventArgs e)
		{
			// Advance window
			CycleStats cycleStats = _window.Advance(_config);

			// Update stats
			_stats.TotalAlive = cycleStats.CellsAlive;
			_stats.TotalDead = cycleStats.CellsDead;
			_stats.TotalBirths += cycleStats.CellsBorn;
			_stats.TotalDeaths += cycleStats.CellsDied;
			_stats.AvgLifespan = (_stats.AvgLifespan = cycleStats.AvgLifespan) / 2;
			_stats.TotalCycles++;
			SetStats();
		}
		
		/// <summary>
		/// Method hit when clicking the link
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CompanyLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start("https://linkrulzsoftware.com/");
		#endregion Other Controls

		#region Options
		private void ResetButton_Click(object sender, EventArgs e) => Reset();

		private void GliderButton_Click(object sender, EventArgs e) => Reset(CellPatterns.GLIDER);

		private void SpaceshipButton_Click(object sender, EventArgs e) => Reset(CellPatterns.SPACESHIP);

		private void GunButton_Click(object sender, EventArgs e) => Reset(CellPatterns.GUN);

		private void RowButton_Click(object sender, EventArgs e) => Reset(CellPatterns.ROW);

		private void PulsarButton_Click(object sender, EventArgs e) => Reset(CellPatterns.PULSAR);

		private void CellColorButton_Click(object sender, EventArgs e)
		{
			if (CellColorDialog.ShowDialog() != DialogResult.OK)
				return;

			_config.CellColor = CellColorDialog.Color;
		}

		private void TankColorButton_Click(object sender, EventArgs e)
		{
			if (TankColorDialog.ShowDialog() != DialogResult.OK)
				return;

			_config.TankColor = TankColorDialog.Color;
		}
		#endregion Options

		#region Private Methods
		/// <summary>
		/// Reset the state of the tank
		/// </summary>
		private void Reset()
		{
			_stats.Reset();
			SetStats();

			_window.Reset(_config);
		}

		/// <summary>
		/// Reset the state of the tank with a pattern
		/// </summary>
		private void Reset(string pattern)
		{
			_stats.Reset();
			SetStats();

			// Reset with empty tank
			int dens = _config.RandomDensity;
			_config.RandomDensity = 0;
			_window.Reset(_config);
			_config.RandomDensity = dens;

			_window.InjectPattern(_config, pattern);
		}

		/// <summary>
		/// Set the values for the stats
		/// </summary>
		private void SetStats()
		{
			TotAlive.Text = _stats.TotalAlive.ToString();
			TotDead.Text = _stats.TotalDead.ToString();
			AvgLifespan.Text = string.Format("{0:0.##}", _stats.AvgLifespan);
			TotBirths.Text = _stats.TotalBirths.ToString();
			TotDeaths.Text = _stats.TotalDeaths.ToString();
			TotCycles.Text = _stats.TotalCycles.ToString();
		}
		#endregion Private Methods
	}
}
