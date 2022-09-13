using GameOfLife.Models;
using GameOfLife.Models.Stats;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfLife.Forms
{
    public partial class TankWindow : Form
    {
        #region Private Members
        private TankConfig _lastConfig;
        #endregion Private Members

        #region Constructors
        public TankWindow()
        {
            InitializeComponent();
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Tank of cells
        /// </summary>
        public Tank Tank { get; private set; }
		#endregion Properties

		#region Public 
		public void Reset(TankConfig config)
		{
			Tank = new Tank(Window.Width, Window.Height, config.CellSize);
			if (config.RandomDensity > 0)
				Tank.Randomize((double)config.RandomDensity / 100);

            _lastConfig = config;
            Render(config);
		}

		/// <summary>
		/// Reset the board with a pattern
		/// </summary>
		/// <param name="pattern"></param>
		public void InjectPattern(TankConfig config, string pattern)
        {
            Tank.BirthPattern(pattern);
            Render(config);
        }

        /// <summary>
        /// Advances the tank 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public CycleStats Advance(TankConfig config)
        {
            CycleStats stats = Tank.Advance();
            Render(config);
            return stats;
        }
        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Draw the Tank onto the window
        /// </summary>
        private void Render(TankConfig config)
        {
            using (var canvas = new Bitmap(Tank.Width, Tank.Height))
            using (var gfx = Graphics.FromImage(canvas))
            {
                gfx.Clear(config.TankColor);

                int buffer = config.ShowGrid && config.CellSize > 1 ? 1 : 0;
                var cellSize = new Size(config.CellSize - buffer, config.CellSize - buffer);
                for (int x = 0; x < Tank.Columns; x++)
                {
                    for (int y = 0; y < Tank.Rows; y++)
                    {
                        Cell cell = Tank[x, y];
                        if (!cell.IsAlive)
                            continue;

                        var cellLocation = new Point(x * config.CellSize, y * config.CellSize);
                        var cellRect = new Rectangle(cellLocation, cellSize);

                        using (var brush = new SolidBrush(config.CellColor))
                            gfx.FillRectangle(brush, cellRect);
                    }
                }

                Window.Image?.Dispose();
                Window.Image = (Bitmap)canvas.Clone();
            }
        }

        /// <summary>
        /// Event after changing the state of the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewPort_SizeChanged(object sender, EventArgs e) 
        {
            // Method hit on form opening, so ignore first round
            if (Tank == null)
                return;

            Reset(_lastConfig);
        }
        #endregion Private Methods
    }
}
