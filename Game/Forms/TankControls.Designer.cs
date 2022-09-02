
namespace GameOfLife.Forms
{
	partial class TankControls
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.CellSize = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.Delay = new System.Windows.Forms.NumericUpDown();
			this.Density = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.ShowGrid = new System.Windows.Forms.CheckBox();
			this.StopTime = new System.Windows.Forms.CheckBox();
			this.Feed = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.TotCycles = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.AvgLifespan = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.TotAlive = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.TotDead = new System.Windows.Forms.Label();
			this.Dead = new System.Windows.Forms.Label();
			this.TotBirths = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.TotDeaths = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.GunButton = new System.Windows.Forms.Button();
			this.ResetButton = new System.Windows.Forms.Button();
			this.GliderButton = new System.Windows.Forms.Button();
			this.SpaceshipButton = new System.Windows.Forms.Button();
			this.RowButton = new System.Windows.Forms.Button();
			this.Timer = new System.Windows.Forms.Timer(this.components);
			this.ColorDialog = new System.Windows.Forms.ColorDialog();
			this.ColorButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.CellSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Delay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Density)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(46, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Cell Size";
			// 
			// CellSize
			// 
			this.CellSize.Location = new System.Drawing.Point(102, 22);
			this.CellSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.CellSize.Name = "CellSize";
			this.CellSize.Size = new System.Drawing.Size(53, 20);
			this.CellSize.TabIndex = 4;
			this.CellSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.CellSize.ValueChanged += new System.EventHandler(this.CellSize_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Cycle time (ms):";
			// 
			// Delay
			// 
			this.Delay.Location = new System.Drawing.Point(102, 48);
			this.Delay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.Delay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.Delay.Name = "Delay";
			this.Delay.Size = new System.Drawing.Size(53, 20);
			this.Delay.TabIndex = 10;
			this.Delay.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.Delay.ValueChanged += new System.EventHandler(this.Delay_ValueChanged);
			// 
			// Density
			// 
			this.Density.Location = new System.Drawing.Point(106, 51);
			this.Density.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.Density.Name = "Density";
			this.Density.Size = new System.Drawing.Size(53, 20);
			this.Density.TabIndex = 12;
			this.Density.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.Density.ValueChanged += new System.EventHandler(this.Density_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Rand Density (%):";
			// 
			// ShowGrid
			// 
			this.ShowGrid.AutoSize = true;
			this.ShowGrid.Checked = true;
			this.ShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ShowGrid.Location = new System.Drawing.Point(80, 104);
			this.ShowGrid.Name = "ShowGrid";
			this.ShowGrid.Size = new System.Drawing.Size(75, 17);
			this.ShowGrid.TabIndex = 14;
			this.ShowGrid.Text = "Show Grid";
			this.ShowGrid.UseVisualStyleBackColor = true;
			this.ShowGrid.CheckedChanged += new System.EventHandler(this.ShowGrid_CheckedChanged);
			// 
			// StopTime
			// 
			this.StopTime.AutoSize = true;
			this.StopTime.Location = new System.Drawing.Point(6, 104);
			this.StopTime.Name = "StopTime";
			this.StopTime.Size = new System.Drawing.Size(74, 17);
			this.StopTime.TabIndex = 15;
			this.StopTime.Text = "Stop Time";
			this.StopTime.UseVisualStyleBackColor = true;
			this.StopTime.CheckedChanged += new System.EventHandler(this.StopTime_CheckedChanged);
			// 
			// Feed
			// 
			this.Feed.Location = new System.Drawing.Point(12, 149);
			this.Feed.Name = "Feed";
			this.Feed.Size = new System.Drawing.Size(308, 65);
			this.Feed.TabIndex = 16;
			this.Feed.Text = "Feed";
			this.Feed.UseVisualStyleBackColor = true;
			this.Feed.Click += new System.EventHandler(this.Feed_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 103);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "Cycles: ";
			// 
			// TotCycles
			// 
			this.TotCycles.Location = new System.Drawing.Point(56, 103);
			this.TotCycles.Name = "TotCycles";
			this.TotCycles.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TotCycles.Size = new System.Drawing.Size(71, 13);
			this.TotCycles.TabIndex = 19;
			this.TotCycles.Text = "0";
			this.TotCycles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 90);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 13);
			this.label6.TabIndex = 20;
			this.label6.Text = "Deaths:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.AvgLifespan);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.TotAlive);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.TotDead);
			this.groupBox1.Controls.Add(this.Dead);
			this.groupBox1.Controls.Add(this.TotBirths);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.TotDeaths);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.TotCycles);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(134, 131);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Stats";
			// 
			// AvgLifespan
			// 
			this.AvgLifespan.Location = new System.Drawing.Point(89, 52);
			this.AvgLifespan.Name = "AvgLifespan";
			this.AvgLifespan.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.AvgLifespan.Size = new System.Drawing.Size(38, 13);
			this.AvgLifespan.TabIndex = 31;
			this.AvgLifespan.Text = "0.0";
			this.AvgLifespan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 52);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 13);
			this.label10.TabIndex = 30;
			this.label10.Text = "Avg Lifespan:";
			// 
			// TotAlive
			// 
			this.TotAlive.Location = new System.Drawing.Point(56, 26);
			this.TotAlive.Name = "TotAlive";
			this.TotAlive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TotAlive.Size = new System.Drawing.Size(71, 13);
			this.TotAlive.TabIndex = 27;
			this.TotAlive.Text = "0";
			this.TotAlive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 26);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(33, 13);
			this.label8.TabIndex = 26;
			this.label8.Text = "Alive:";
			// 
			// TotDead
			// 
			this.TotDead.Location = new System.Drawing.Point(56, 39);
			this.TotDead.Name = "TotDead";
			this.TotDead.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TotDead.Size = new System.Drawing.Size(71, 13);
			this.TotDead.TabIndex = 25;
			this.TotDead.Text = "0";
			this.TotDead.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Dead
			// 
			this.Dead.AutoSize = true;
			this.Dead.Location = new System.Drawing.Point(6, 39);
			this.Dead.Name = "Dead";
			this.Dead.Size = new System.Drawing.Size(36, 13);
			this.Dead.TabIndex = 24;
			this.Dead.Text = "Dead:";
			// 
			// TotBirths
			// 
			this.TotBirths.Location = new System.Drawing.Point(56, 77);
			this.TotBirths.Name = "TotBirths";
			this.TotBirths.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TotBirths.Size = new System.Drawing.Size(71, 13);
			this.TotBirths.TabIndex = 23;
			this.TotBirths.Text = "0";
			this.TotBirths.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 77);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(36, 13);
			this.label7.TabIndex = 22;
			this.label7.Text = "Births:";
			// 
			// TotDeaths
			// 
			this.TotDeaths.Location = new System.Drawing.Point(56, 90);
			this.TotDeaths.Name = "TotDeaths";
			this.TotDeaths.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TotDeaths.Size = new System.Drawing.Size(71, 13);
			this.TotDeaths.TabIndex = 21;
			this.TotDeaths.Text = "0";
			this.TotDeaths.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ColorButton);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.CellSize);
			this.groupBox2.Controls.Add(this.Delay);
			this.groupBox2.Controls.Add(this.StopTime);
			this.groupBox2.Controls.Add(this.ShowGrid);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(152, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(168, 131);
			this.groupBox2.TabIndex = 22;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Config";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.GunButton);
			this.groupBox3.Controls.Add(this.ResetButton);
			this.groupBox3.Controls.Add(this.GliderButton);
			this.groupBox3.Controls.Add(this.SpaceshipButton);
			this.groupBox3.Controls.Add(this.RowButton);
			this.groupBox3.Controls.Add(this.Density);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Location = new System.Drawing.Point(12, 220);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(308, 82);
			this.groupBox3.TabIndex = 23;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Reset";
			// 
			// GunButton
			// 
			this.GunButton.Location = new System.Drawing.Point(227, 19);
			this.GunButton.Name = "GunButton";
			this.GunButton.Size = new System.Drawing.Size(74, 23);
			this.GunButton.TabIndex = 19;
			this.GunButton.Text = "Glider Gun";
			this.GunButton.UseVisualStyleBackColor = true;
			this.GunButton.Click += new System.EventHandler(this.GunButton_Click);
			// 
			// ResetButton
			// 
			this.ResetButton.Location = new System.Drawing.Point(6, 19);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(153, 23);
			this.ResetButton.TabIndex = 15;
			this.ResetButton.Text = "Random";
			this.ResetButton.UseVisualStyleBackColor = true;
			this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// GliderButton
			// 
			this.GliderButton.Location = new System.Drawing.Point(165, 19);
			this.GliderButton.Name = "GliderButton";
			this.GliderButton.Size = new System.Drawing.Size(56, 23);
			this.GliderButton.TabIndex = 17;
			this.GliderButton.Text = "Glider";
			this.GliderButton.UseVisualStyleBackColor = true;
			this.GliderButton.Click += new System.EventHandler(this.GliderButton_Click);
			// 
			// SpaceshipButton
			// 
			this.SpaceshipButton.Location = new System.Drawing.Point(165, 48);
			this.SpaceshipButton.Name = "SpaceshipButton";
			this.SpaceshipButton.Size = new System.Drawing.Size(66, 23);
			this.SpaceshipButton.TabIndex = 18;
			this.SpaceshipButton.Text = "Spaceship";
			this.SpaceshipButton.UseVisualStyleBackColor = true;
			this.SpaceshipButton.Click += new System.EventHandler(this.SpaceshipButton_Click);
			// 
			// RowButton
			// 
			this.RowButton.Location = new System.Drawing.Point(237, 48);
			this.RowButton.Name = "RowButton";
			this.RowButton.Size = new System.Drawing.Size(64, 23);
			this.RowButton.TabIndex = 16;
			this.RowButton.Text = "Row";
			this.RowButton.UseVisualStyleBackColor = true;
			this.RowButton.Click += new System.EventHandler(this.RowButton_Click);
			// 
			// Timer
			// 
			this.Timer.Enabled = true;
			this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
			// 
			// ColorButton
			// 
			this.ColorButton.Location = new System.Drawing.Point(6, 75);
			this.ColorButton.Name = "ColorButton";
			this.ColorButton.Size = new System.Drawing.Size(149, 23);
			this.ColorButton.TabIndex = 18;
			this.ColorButton.Text = "Set Color";
			this.ColorButton.UseVisualStyleBackColor = true;
			this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
			// 
			// TankControls
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(332, 312);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.Feed);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.HelpButton = true;
			this.Name = "TankControls";
			this.Text = "Tank Controls";
			((System.ComponentModel.ISupportInitialize)(this.CellSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Delay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Density)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown CellSize;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown Delay;
		private System.Windows.Forms.NumericUpDown Density;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox ShowGrid;
		private System.Windows.Forms.CheckBox StopTime;
		private System.Windows.Forms.Button Feed;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label TotCycles;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label TotAlive;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label TotDead;
		private System.Windows.Forms.Label Dead;
		private System.Windows.Forms.Label TotBirths;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label TotDeaths;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button GunButton;
		private System.Windows.Forms.Button ResetButton;
		private System.Windows.Forms.Button GliderButton;
		private System.Windows.Forms.Button SpaceshipButton;
		private System.Windows.Forms.Button RowButton;
		private System.Windows.Forms.Timer Timer;
		private System.Windows.Forms.Label AvgLifespan;
		private System.Windows.Forms.ColorDialog ColorDialog;
		private System.Windows.Forms.Button ColorButton;
	}
}