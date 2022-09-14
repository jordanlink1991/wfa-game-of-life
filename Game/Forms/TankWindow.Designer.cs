﻿namespace GameOfLife.Forms
{
	partial class TankWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TankWindow));
			this.Window = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.Window)).BeginInit();
			this.SuspendLayout();
			// 
			// Window
			// 
			this.Window.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Window.Location = new System.Drawing.Point(12, 12);
			this.Window.Name = "Window";
			this.Window.Size = new System.Drawing.Size(864, 426);
			this.Window.TabIndex = 0;
			this.Window.TabStop = false;
			this.Window.SizeChanged += new System.EventHandler(this.ViewPort_SizeChanged);
			// 
			// TankWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(888, 450);
			this.Controls.Add(this.Window);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.Name = "TankWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game of Life";
			((System.ComponentModel.ISupportInitialize)(this.Window)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox Window;
	}
}

