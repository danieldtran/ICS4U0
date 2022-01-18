using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tortoise_And_Hare_DanielTran
{
    public partial class formHarevsTortoise : Form
    {
        //Contender Object
        public class Contender
        {
            //Tracks the current sessions's wins, losses, and ties
            public int iCurrentWins;
            public int iCurrentTies;
            //Tracks the total wins, losses, and ties of all sessions
            protected int iWins;
            protected int iTies;
            protected int iPosition;
            protected int iNumberOfSteps;
            public Color clr;
            //Contender Constructors
            //default contender constructor with no parameters
            public Contender()
            {
                iPosition = 0;
                iNumberOfSteps = 70;
                clr = Color.Black;
            }
            //contender method with three parameters to input
            public Contender(int pos, int step, Color col)
            {
                iPosition = pos;
                iNumberOfSteps = step;
                clr = col;
            }
            //Getter for total wins
            public int GetWins()
            {
                return iWins;
            }
            //Getter for total ties
            public int GetTies()
            {
                return iTies;
            }
            //Getter for current position
            public int GetPosition()
            {
                return iPosition;
            }
            //Getter for current steps
            public int GetSteps()
            {
                return iNumberOfSteps;
            }
            //Getter for current colour
            public Color GetColour()
            {
                return clr;
            }
            //Setters for current colour
            public void SetColor(Color col)
            {
                clr = col;
            }
            //Setters for total wins
            public void SetWins(int wins)
            {
                if (wins < 0)
                {
                    iWins = -wins;
                }
                else
                {
                    iWins = wins;
                }
            }
            //Setter for total ties
            public void SetTies(int ties)
            {
                if (iTies < 0)
                {
                    iTies = -ties;
                }
                else
                {
                    iTies = ties;
                }
            }
            //Update the current and total wins
            public void UpdateWins()
            {
                iWins = iWins + 1;
                iCurrentWins = iCurrentWins + 1;
            }
            //Update the current and total ties
            public void UpdateTies()
            {
                iTies = iTies + 1;
                iCurrentTies = iCurrentTies + 1;
            }
            //Setter for total steps
            public void SetSteps(int NumOfSteps)
            {
                if (iNumberOfSteps < 0)
                {
                    iNumberOfSteps = -NumOfSteps;
                }
                else
                {
                    iNumberOfSteps = NumOfSteps;
                }
            }
            //Setter for the position
            public void SetPosition(int pos)
            {
                if (iNumberOfSteps < 0)
                {
                    iPosition = -pos;
                }
                else
                {
                    iPosition = pos; ;
                }
            }
            //returns a statement depending on the position compared to the total number of steps
            public bool IsWinner()
            {
                if (iPosition >= iNumberOfSteps)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        Hare HareRacer;
        //Hare Class
        public class Hare : Contender
        {
            //variable to determine the random moves of the hare
            Random rng;
            //Hare Constructors
            //constructor for hare is the same as contender class with the added random variable
            public Hare() : base()
            {
                rng = new Random();
            }
            //constrctor for Hare with three parameters 
            public Hare(int pos, int step, Color col) : base()
            {
                iPosition = pos;
                iNumberOfSteps = step;
                clr = col;
                rng = new Random();
            }
            //Determines the next position of the hare
            public void UpdatePosition()
            {

                int i = rng.Next(0, 100);
                if (i < 20)
                {
                    iPosition += 0;
                }
                else if (i < 40)
                {
                    iPosition += 9;
                }
                else if (i < 50)
                {
                    iPosition -= 12;
                    if (iPosition < 0)
                    {
                        SetPosition(0);
                    }
                }
                else if (i < 80)
                {
                    iPosition += 1;
                }
                else
                {
                    iPosition -= 2;
                    if (iPosition < 0)
                    {
                        SetPosition(0);
                    }
                }
            }
            //Draws a circle to represent the hare when in draw mode
            public void Draw(Graphics g, int yLoc)
            {
                SolidBrush myBrush = new SolidBrush(clr);
                g.FillEllipse(myBrush, iPosition * 10 + 15, yLoc, 15, 15);
            }
        }
        Tortoise TortoiseRacer;
        //Tortoise class
        public class Tortoise : Contender
        {
            //variable to determine the random moves of the tortoise
            Random rng;
            //constructor is the same as the hare class
            public Tortoise() : base()
            {
                rng = new Random();
            }
            //constructor has three parameters, identical to the hare contender with three parameters
            public Tortoise(int pos, int step, Color col) : base()
            {
                iPosition = pos;
                iNumberOfSteps = step;
                clr = col;
                rng = new Random();
            }
            //determines the next position of the tortoise using rng
            public void UpdatePosition()
            {
                int i = rng.Next(0, 100);
                if (i < 50)
                {
                    iPosition += 3;
                }
                else if (i < 70)
                {
                    iPosition -= 6;
                    if (iPosition < 0)
                    {
                        SetPosition(0);
                    }
                }
                else
                {
                    iPosition += 1;
                }
            }
            //draws a filled in square to represent the tortoise when in the draw mode
            public void Draw(Graphics g, int yLoc)
            {
                SolidBrush myBrush = new SolidBrush(clr);
                g.FillRectangle(myBrush, iPosition * 10 + 15, yLoc, 15, 15);
            }
        }

        public formHarevsTortoise()
        {
            InitializeComponent();
            //initialize both contenders as hare and tortoise respectively
            HareRacer = new Hare();
            TortoiseRacer = new Tortoise();
        }
        //method to update the scoreboard everytime
        //scoreboard records the current session's wins, losses, and ties
        public void UpdateScoreboard()
        {
            lbScoreboard.Items.Clear();
            lbScoreboard.Items.Add("Hare");
            lbScoreboard.Items.Add("Wins: " + HareRacer.iCurrentWins);
            lbScoreboard.Items.Add("");
            lbScoreboard.Items.Add("Tortoise");
            lbScoreboard.Items.Add("Wins: " + TortoiseRacer.iCurrentWins);
            lbScoreboard.Items.Add("");
            lbScoreboard.Items.Add("Ties: " + TortoiseRacer.iCurrentTies);
        }
        //method to update the statistics listbox everytime
        //lifetime stats records the total of all session's wins, losses, and ties
        public void LifeTimeStats()
        {
            lbLifetime.Items.Clear();
            lbLifetime.Items.Add("Hare");
            lbLifetime.Items.Add("Wins: " + HareRacer.GetWins());
            lbLifetime.Items.Add("");
            lbLifetime.Items.Add("Tortoise");
            lbLifetime.Items.Add("Wins: " + TortoiseRacer.GetWins());
            lbLifetime.Items.Add("");
            lbLifetime.Items.Add("Ties: " + TortoiseRacer.GetTies());
        }
        //Updates the graph in the statistics tab with the total of all session's wins, losses, and ties
        public void UpdateGraph()
        {
            chartStatistics.Series["SeriesWins"].Points.Clear();
            chartStatistics.Series["SeriesWins"].Points.AddY( HareRacer.GetWins());
            chartStatistics.Series["SeriesWins"].Points.AddY( TortoiseRacer.GetWins());
            chartStatistics.Series["SeriesWins"].Points.AddY( TortoiseRacer.GetTies());
            chartStatistics.Series["SeriesWins"].Points[0].LegendText = "Hare Wins";
            chartStatistics.Series["SeriesWins"].Points[1].LegendText = "Tortoise Wins";
            chartStatistics.Series["SeriesWins"].Points[2].LegendText = "Ties";
            chartStatistics.Invalidate();
        }
        //starts the timer and sets the tick speed according to what the user has selected
        //starts the race
        private void btnPlay_Click(object sender, EventArgs e)
        {
            string strSpeed = Convert.ToString(cmbSpeed.Text);
            if (strSpeed == "Slow")
            {
                raceTimer.Interval = 200;
            }

            else if ((strSpeed == "Default") || (strSpeed == ""))
            {
                raceTimer.Interval = 150;
            }
            else if (strSpeed == "Fast")
            {
                raceTimer.Interval = 50;
            }
            raceTimer.Start();

        }
        //pauses the race
        private void btnPause_Click(object sender, EventArgs e)
        {
            raceTimer.Stop();
        }
        //resets the positions of both the contenders to 0
        //resets the race
        private void btnReset_Click(object sender, EventArgs e)
        {
            raceTimer.Stop();
            HareRacer.SetPosition(0);
            TortoiseRacer.SetPosition(0);
            pbRace.Invalidate();
        }
        //everytime the timer ticks
        private void raceTimer_Tick(object sender, EventArgs e)
        {
            //inputs the speed again if the user changes the speed midway through the race    
            string strSpeed = Convert.ToString(cmbSpeed.Text);
                if (strSpeed == "Slow")
                {
                    raceTimer.Interval = 200;
                }
                else if (strSpeed == "Default")
                {
                    raceTimer.Interval = 150;
                }
                else if (strSpeed == "Fast")
                {
                    raceTimer.Interval = 50;
                }
                //moves the hare
                HareRacer.UpdatePosition();
                //moves the tortoise
                TortoiseRacer.UpdatePosition();
                pbRace.Invalidate();
            //when the hare is the winner    
            if (HareRacer.IsWinner())
                {
                    raceTimer.Stop();
                //gives a biased message when the hare wins    
                MessageBox.Show("Hare wins. Yuch.");
                    HareRacer.UpdateWins();
                //resets the positions    
                HareRacer.SetPosition(0);
                    TortoiseRacer.SetPosition(0);
                    pbRace.Invalidate();
                //update scoreboards and statistics    
                UpdateScoreboard();
                    UpdateGraph();
                    LifeTimeStats();
                }
            //when the tortoise is the winner    
            else if (TortoiseRacer.IsWinner())
                {
                    raceTimer.Stop();
                //gives a biased message when the tortoise wins    
                MessageBox.Show("TORTOISE WINS!!! YAY!!!");
                    TortoiseRacer.UpdateWins();
                //resets the positions of both contenders    
                HareRacer.SetPosition(0);
                    TortoiseRacer.SetPosition(0);
                    pbRace.Invalidate();
                //update scoreboards and statistics    
                UpdateScoreboard();
                    UpdateGraph();
                    LifeTimeStats();
                }
            //when the result is a tie
            else if (TortoiseRacer.IsWinner() && (HareRacer.IsWinner()))
                {
                    
                raceTimer.Stop();
                    MessageBox.Show("It's a tie");
                //since ties are the same for both hare and tortoise, they can both be used
                    TortoiseRacer.UpdateTies();
                //resets the positions of the contenders    
                HareRacer.SetPosition(0);
                    TortoiseRacer.SetPosition(0);
                    pbRace.Invalidate();
                //update scorebaords and statistics
                    UpdateScoreboard();
                    UpdateGraph();
                    LifeTimeStats();
                }
            //when the positions are reset, make sure it doesn't display ouch a bunch of times
            //only display ouch when the have started the race
            if (HareRacer.GetPosition() > 0 || TortoiseRacer.GetPosition() > 0)
             {
                if (HareRacer.GetPosition() == TortoiseRacer.GetPosition())
                {
                    MessageBox.Show("OUCH!!! The tortoise bites the hare at square " + HareRacer.GetPosition());
                }
            }
        }
        //draws the track
        //draws the hare and tortoise when set to draw mode
        private void pbRace_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen trackPen = new Pen(Color.Red, 2);
            trackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawLine(trackPen, 15, 100, 715, 100);
            g.DrawLine(trackPen, 15, 200, 715, 200);
            //when draw mode is selected, draw the hare and tortoise, make the picture boxes go away
            if (rbDrawMode.Checked == true)
            {
                HareRacer.Draw(g, 100);
                TortoiseRacer.Draw(g, 200);
                pbHare.Visible = false;
                pbTortoise.Visible = false;
            }
            //when picture mode is selected, make the hare and tortoise appear
            else
            {
                pbHare.Visible = true;
                pbTortoise.Visible = true;
                pbHare.Location = new Point(HareRacer.GetPosition() * 10 + 15, 60);
                pbTortoise.Location = new Point(TortoiseRacer.GetPosition() * 10 + 15, 170);
            }
        }
        //changes the colour of the hare
        private void btnHareColor_Click(object sender, EventArgs e)
        {
            ColorDialog clrDlg = new ColorDialog();
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                HareRacer.clr = clrDlg.Color;
                pbRace.Invalidate();
            }
        }
        //changes the colour of the tortoise
        private void btnTortoiseColor_Click(object sender, EventArgs e)
        {
            ColorDialog clrDlg = new ColorDialog();
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                TortoiseRacer.clr = clrDlg.Color;
                pbRace.Invalidate();
            }
        }
        //resets the current session's wins, losses, ties
        private void btnResetScore_Click(object sender, EventArgs e)
        {
            HareRacer.iCurrentWins = 0;
            HareRacer.iCurrentTies = 0;
            TortoiseRacer.iCurrentWins = 0;;
            UpdateScoreboard();
            UpdateGraph();
            LifeTimeStats();
        }
        //when the form closes, save a file automatically
        //writes out the wins and ties
        //file gets saved in the debug project file
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TextWriter tw = new StreamWriter("Hare vs Tortoise Results.txt");
            tw.Write(HareRacer.GetWins() + ",");
            tw.Write(TortoiseRacer.GetWins() + ",");
            tw.WriteLine(HareRacer.GetTies());
            tw.Close();
        }
        //when the form loads, automatically run the file that was saved from the last session
        private void formHarevsTortoise_Load(object sender, EventArgs e)
        {
            //if the file exists
            //read from the file
            if (File.Exists(@"Hare vs Tortoise Results.txt"))
            {
                string strInput;
                string[] splittedInput;
                TextReader tr = new StreamReader("Hare vs Tortoise Results.txt");
                while ((strInput = tr.ReadLine()) != null)
                {
                    splittedInput = strInput.Split(',');
                    HareRacer.SetWins(Convert.ToInt32(splittedInput[0]));
                    TortoiseRacer.SetWins(Convert.ToInt32(splittedInput[1]));
                    HareRacer.SetTies(Convert.ToInt32(splittedInput[2]));
                }
                tr.Close();
                //update scoreboard and lifetime stats
                UpdateScoreboard();
                UpdateGraph();
                LifeTimeStats();
            }
            //if the file does not already exist
            //make a new file with the default values for wins and ties
            //then read it from the file with default values
            else
            {
                TextWriter tw = new StreamWriter("Hare vs Tortoise Results.txt");
                tw.Write(0 + ",");
                tw.Write(0 + ",");
                tw.WriteLine(0);
                tw.Close();
                string strInput;
                string[] splittedInput;
                TextReader tr = new StreamReader("Hare vs Tortoise Results.txt");
                while ((strInput = tr.ReadLine()) != null)
                {
                    splittedInput = strInput.Split(',');
                    HareRacer.SetWins(Convert.ToInt32(splittedInput[0]));
                    TortoiseRacer.SetWins(Convert.ToInt32(splittedInput[1]));
                    HareRacer.SetTies(Convert.ToInt32(splittedInput[2]));
                }
                tr.Close();
                UpdateScoreboard();
                UpdateGraph();
                LifeTimeStats();
            }
        }
        //when the picture mode is changed
        private void rbPictureMode_CheckedChanged(object sender, EventArgs e)
        {
            pbHare.Visible = true;
            pbTortoise.Visible = true;
        }
        //when the draw mode is changed
        private void rbDrawMode_CheckedChanged(object sender, EventArgs e)
        {
            pbHare.Visible = false;
            pbTortoise.Visible = false;
        }
    }
}
