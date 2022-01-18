
namespace Tortoise_And_Hare_DanielTran
{
    partial class formHarevsTortoise
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.raceTimer = new System.Windows.Forms.Timer(this.components);
            this.btnHareColor = new System.Windows.Forms.Button();
            this.btnTortoiseColor = new System.Windows.Forms.Button();
            this.rbDrawMode = new System.Windows.Forms.RadioButton();
            this.rbPictureMode = new System.Windows.Forms.RadioButton();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.cmbSpeed = new System.Windows.Forms.ComboBox();
            this.lbScoreboard = new System.Windows.Forms.ListBox();
            this.lblScoreboard = new System.Windows.Forms.Label();
            this.btnResetScore = new System.Windows.Forms.Button();
            this.pbTortoise = new System.Windows.Forms.PictureBox();
            this.pbHare = new System.Windows.Forms.PictureBox();
            this.pbRace = new System.Windows.Forms.PictureBox();
            this.tcHarevsTortoise = new System.Windows.Forms.TabControl();
            this.tpSimulation = new System.Windows.Forms.TabPage();
            this.tpStatistics = new System.Windows.Forms.TabPage();
            this.lbLifetime = new System.Windows.Forms.ListBox();
            this.chartStatistics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pbTortoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRace)).BeginInit();
            this.tcHarevsTortoise.SuspendLayout();
            this.tpSimulation.SuspendLayout();
            this.tpStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(16, 309);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(97, 309);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(178, 309);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // raceTimer
            // 
            this.raceTimer.Tick += new System.EventHandler(this.raceTimer_Tick);
            // 
            // btnHareColor
            // 
            this.btnHareColor.Location = new System.Drawing.Point(16, 388);
            this.btnHareColor.Name = "btnHareColor";
            this.btnHareColor.Size = new System.Drawing.Size(129, 23);
            this.btnHareColor.TabIndex = 4;
            this.btnHareColor.Text = "Change Hare Color";
            this.btnHareColor.UseVisualStyleBackColor = true;
            this.btnHareColor.Click += new System.EventHandler(this.btnHareColor_Click);
            // 
            // btnTortoiseColor
            // 
            this.btnTortoiseColor.Location = new System.Drawing.Point(16, 417);
            this.btnTortoiseColor.Name = "btnTortoiseColor";
            this.btnTortoiseColor.Size = new System.Drawing.Size(129, 23);
            this.btnTortoiseColor.TabIndex = 5;
            this.btnTortoiseColor.Text = "Change Tortoise Color";
            this.btnTortoiseColor.UseVisualStyleBackColor = true;
            this.btnTortoiseColor.Click += new System.EventHandler(this.btnTortoiseColor_Click);
            // 
            // rbDrawMode
            // 
            this.rbDrawMode.AutoSize = true;
            this.rbDrawMode.Location = new System.Drawing.Point(162, 388);
            this.rbDrawMode.Name = "rbDrawMode";
            this.rbDrawMode.Size = new System.Drawing.Size(80, 17);
            this.rbDrawMode.TabIndex = 9;
            this.rbDrawMode.Text = "Draw Mode";
            this.rbDrawMode.UseVisualStyleBackColor = true;
            this.rbDrawMode.CheckedChanged += new System.EventHandler(this.rbDrawMode_CheckedChanged);
            // 
            // rbPictureMode
            // 
            this.rbPictureMode.AutoSize = true;
            this.rbPictureMode.Checked = true;
            this.rbPictureMode.Location = new System.Drawing.Point(162, 352);
            this.rbPictureMode.Name = "rbPictureMode";
            this.rbPictureMode.Size = new System.Drawing.Size(88, 17);
            this.rbPictureMode.TabIndex = 8;
            this.rbPictureMode.TabStop = true;
            this.rbPictureMode.Text = "Picture Mode";
            this.rbPictureMode.UseVisualStyleBackColor = true;
            this.rbPictureMode.CheckedChanged += new System.EventHandler(this.rbPictureMode_CheckedChanged);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(13, 351);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(41, 13);
            this.lblSpeed.TabIndex = 7;
            this.lblSpeed.Text = "Speed:";
            // 
            // cmbSpeed
            // 
            this.cmbSpeed.AutoCompleteCustomSource.AddRange(new string[] {
            "Slow",
            "Default",
            "Fast"});
            this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeed.FormattingEnabled = true;
            this.cmbSpeed.Items.AddRange(new object[] {
            "Slow",
            "Default",
            "Fast"});
            this.cmbSpeed.Location = new System.Drawing.Point(60, 348);
            this.cmbSpeed.Name = "cmbSpeed";
            this.cmbSpeed.Size = new System.Drawing.Size(68, 21);
            this.cmbSpeed.TabIndex = 3;
            // 
            // lbScoreboard
            // 
            this.lbScoreboard.FormattingEnabled = true;
            this.lbScoreboard.Location = new System.Drawing.Point(271, 334);
            this.lbScoreboard.Name = "lbScoreboard";
            this.lbScoreboard.Size = new System.Drawing.Size(237, 95);
            this.lbScoreboard.TabIndex = 0;
            this.lbScoreboard.TabStop = false;
            // 
            // lblScoreboard
            // 
            this.lblScoreboard.AutoSize = true;
            this.lblScoreboard.Font = new System.Drawing.Font("Gotham Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreboard.Location = new System.Drawing.Point(309, 308);
            this.lblScoreboard.Name = "lblScoreboard";
            this.lblScoreboard.Size = new System.Drawing.Size(165, 24);
            this.lblScoreboard.TabIndex = 11;
            this.lblScoreboard.Text = "SCOREBOARD";
            // 
            // btnResetScore
            // 
            this.btnResetScore.Location = new System.Drawing.Point(400, 435);
            this.btnResetScore.Name = "btnResetScore";
            this.btnResetScore.Size = new System.Drawing.Size(108, 23);
            this.btnResetScore.TabIndex = 6;
            this.btnResetScore.Text = "Reset Scoreboard";
            this.btnResetScore.UseVisualStyleBackColor = true;
            this.btnResetScore.Click += new System.EventHandler(this.btnResetScore_Click);
            // 
            // pbTortoise
            // 
            this.pbTortoise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbTortoise.Image = global::Tortoise_And_Hare_DanielTran.Properties.Resources.tortoise;
            this.pbTortoise.Location = new System.Drawing.Point(12, 160);
            this.pbTortoise.Name = "pbTortoise";
            this.pbTortoise.Size = new System.Drawing.Size(43, 35);
            this.pbTortoise.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTortoise.TabIndex = 16;
            this.pbTortoise.TabStop = false;
            this.pbTortoise.Visible = false;
            // 
            // pbHare
            // 
            this.pbHare.Image = global::Tortoise_And_Hare_DanielTran.Properties.Resources.imgbin_european_hare_arctic_hare_snowshoe_hare_rabbit_iUws4nbrdYe57CT7NDHEfMpwV_t_removebg_preview;
            this.pbHare.Location = new System.Drawing.Point(12, 51);
            this.pbHare.Name = "pbHare";
            this.pbHare.Size = new System.Drawing.Size(42, 43);
            this.pbHare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHare.TabIndex = 15;
            this.pbHare.TabStop = false;
            this.pbHare.Visible = false;
            // 
            // pbRace
            // 
            this.pbRace.Location = new System.Drawing.Point(6, 3);
            this.pbRace.Name = "pbRace";
            this.pbRace.Size = new System.Drawing.Size(730, 300);
            this.pbRace.TabIndex = 0;
            this.pbRace.TabStop = false;
            this.pbRace.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRace_Paint);
            // 
            // tcHarevsTortoise
            // 
            this.tcHarevsTortoise.Controls.Add(this.tpSimulation);
            this.tcHarevsTortoise.Controls.Add(this.tpStatistics);
            this.tcHarevsTortoise.Location = new System.Drawing.Point(12, 12);
            this.tcHarevsTortoise.Name = "tcHarevsTortoise";
            this.tcHarevsTortoise.SelectedIndex = 0;
            this.tcHarevsTortoise.Size = new System.Drawing.Size(751, 486);
            this.tcHarevsTortoise.TabIndex = 0;
            this.tcHarevsTortoise.TabStop = false;
            // 
            // tpSimulation
            // 
            this.tpSimulation.Controls.Add(this.pbTortoise);
            this.tpSimulation.Controls.Add(this.btnPlay);
            this.tpSimulation.Controls.Add(this.pbHare);
            this.tpSimulation.Controls.Add(this.btnPause);
            this.tpSimulation.Controls.Add(this.btnReset);
            this.tpSimulation.Controls.Add(this.btnResetScore);
            this.tpSimulation.Controls.Add(this.btnHareColor);
            this.tpSimulation.Controls.Add(this.lblScoreboard);
            this.tpSimulation.Controls.Add(this.btnTortoiseColor);
            this.tpSimulation.Controls.Add(this.lbScoreboard);
            this.tpSimulation.Controls.Add(this.rbDrawMode);
            this.tpSimulation.Controls.Add(this.cmbSpeed);
            this.tpSimulation.Controls.Add(this.rbPictureMode);
            this.tpSimulation.Controls.Add(this.lblSpeed);
            this.tpSimulation.Controls.Add(this.pbRace);
            this.tpSimulation.Location = new System.Drawing.Point(4, 22);
            this.tpSimulation.Name = "tpSimulation";
            this.tpSimulation.Padding = new System.Windows.Forms.Padding(3);
            this.tpSimulation.Size = new System.Drawing.Size(743, 460);
            this.tpSimulation.TabIndex = 0;
            this.tpSimulation.Text = "Simulation";
            this.tpSimulation.UseVisualStyleBackColor = true;
            // 
            // tpStatistics
            // 
            this.tpStatistics.Controls.Add(this.lbLifetime);
            this.tpStatistics.Controls.Add(this.chartStatistics);
            this.tpStatistics.Location = new System.Drawing.Point(4, 22);
            this.tpStatistics.Name = "tpStatistics";
            this.tpStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatistics.Size = new System.Drawing.Size(743, 460);
            this.tpStatistics.TabIndex = 1;
            this.tpStatistics.Text = "Statistics";
            this.tpStatistics.UseVisualStyleBackColor = true;
            // 
            // lbLifetime
            // 
            this.lbLifetime.FormattingEnabled = true;
            this.lbLifetime.Location = new System.Drawing.Point(6, 6);
            this.lbLifetime.Name = "lbLifetime";
            this.lbLifetime.Size = new System.Drawing.Size(188, 108);
            this.lbLifetime.TabIndex = 1;
            this.lbLifetime.TabStop = false;
            // 
            // chartStatistics
            // 
            chartArea2.Name = "ChartArea1";
            this.chartStatistics.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartStatistics.Legends.Add(legend2);
            this.chartStatistics.Location = new System.Drawing.Point(200, 6);
            this.chartStatistics.Name = "chartStatistics";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "SeriesWins";
            this.chartStatistics.Series.Add(series2);
            this.chartStatistics.Size = new System.Drawing.Size(540, 448);
            this.chartStatistics.TabIndex = 0;
            this.chartStatistics.Text = "chartStatistics";
            // 
            // formHarevsTortoise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 505);
            this.Controls.Add(this.tcHarevsTortoise);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formHarevsTortoise";
            this.Text = "Hare vs Tortoise Simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.formHarevsTortoise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTortoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRace)).EndInit();
            this.tcHarevsTortoise.ResumeLayout(false);
            this.tpSimulation.ResumeLayout(false);
            this.tpSimulation.PerformLayout();
            this.tpStatistics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRace;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer raceTimer;
        private System.Windows.Forms.Button btnHareColor;
        private System.Windows.Forms.Button btnTortoiseColor;
        private System.Windows.Forms.RadioButton rbDrawMode;
        private System.Windows.Forms.RadioButton rbPictureMode;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.ComboBox cmbSpeed;
        private System.Windows.Forms.ListBox lbScoreboard;
        private System.Windows.Forms.Label lblScoreboard;
        private System.Windows.Forms.Button btnResetScore;
        private System.Windows.Forms.PictureBox pbHare;
        private System.Windows.Forms.PictureBox pbTortoise;
        private System.Windows.Forms.TabControl tcHarevsTortoise;
        private System.Windows.Forms.TabPage tpSimulation;
        private System.Windows.Forms.TabPage tpStatistics;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistics;
        private System.Windows.Forms.ListBox lbLifetime;
    }
}

