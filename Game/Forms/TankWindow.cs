using GameOfLife.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfLife.Forms
{
    public partial class TankWindow : Form
    {
        #region Private Members
        private double _lastDensity;
        private Color _lastCellColor;
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
        /// <summary>
        /// Identify if the grid should be shown on the window
        /// </summary>
        public bool ShowGrid { get; set; }
        /// <summary>
        /// Color of the tank
        /// </summary>
        public Color TankColor { get; set; }
        #endregion Properties

        #region Public 
        /// <summary>
        /// Reset the tank
        /// </summary>
        /// <param name="randomize"></param>
        public void Reset(int size, Color cellColor, double density = 0)
        {
            Tank = new Tank(Window.Width, Window.Height, size);
            foreach (Cell cell in Tank.Cells)
                cell.Color = cellColor;

            if (density > 0)
                Tank.Randomize(density / 100);

            _lastDensity = density;
            _lastCellColor = cellColor;

            Render();
        }

        /// <summary>
        /// Reset the board with a pattern
        /// </summary>
        /// <param name="pattern"></param>
        public void InjectPattern(string pattern)
        {
            Tank.InjectPattern(pattern);
            Render();
        }

        /// <summary>
        /// Advances the tank 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Advance(out int newBorns, out int died)
        {
            Tank.Advance(out newBorns, out died);
            Render();
        }
        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Draw the Tank onto the window
        /// </summary>
        private void Render()
        {
            using (var canvas = new Bitmap(Tank.Width, Tank.Height))
            using (var gfx = Graphics.FromImage(canvas))
            {
                gfx.Clear(TankColor);

                int buffer = ShowGrid && Tank.CellSize > 1 ? 1 : 0;
                var cellSize = new Size(Tank.CellSize - buffer, Tank.CellSize - buffer);
                for (int x = 0; x < Tank.Columns; x++)
                {
                    for (int y = 0; y < Tank.Rows; y++)
                    {
                        Cell cell = Tank[x, y];
                        if (!cell.IsAlive)
                            continue;

                        var cellLocation = new Point(x * Tank.CellSize, y * Tank.CellSize);
                        var cellRect = new Rectangle(cellLocation, cellSize);

                        using (var brush = new SolidBrush(cell.Color))
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
            Reset(Tank.CellSize, _lastCellColor, _lastDensity);
        }
        #endregion Private Methods
    }
}
