using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        int uniWith = 10;
        int uniHeight = 10;
        // The universe array
        bool[,] universe = new bool[10, 10];
        bool[,] scratchPad = new bool[10, 10];

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.RoyalBlue;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        int seed = 0;
        bool isToroidal = true;
        Font font = new Font("Arial", 20f);
        public Form1()
        {
            InitializeComponent();
            universe = new bool[uniWith, uniHeight];
            scratchPad = new bool[uniWith, uniHeight];

            graphicsPanel1.BackColor = Properties.Settings.Default.BackColor;
            gridColor = Properties.Settings.Default.GridColor;
            cellColor = Properties.Settings.Default.CellColor;
            timer.Interval = Properties.Settings.Default.Time;
            uniWith = Properties.Settings.Default.UniWidth;
            uniHeight = Properties.Settings.Default.UniHeight;
            isToroidal = Properties.Settings.Default.IsTorodial;

            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running
        }

        // Calculate the next generation of cells
        private void NextGeneration()
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int count;
                    if (isToroidal == true)
                        count = CountNeighborsToroidal(x, y);
                    else
                        count = CountNeighborsFinite(x, y);
                    //Apply the rules
                    if (count > 2)
                    {
                        scratchPad[x, y] = false;
                    }
                    if (count > 3)
                    {
                        scratchPad[x, y] = false;
                    }
                    if (count == 2 || count == 3)
                    {
                        scratchPad[x, y] = true;
                    }
                    if (scratchPad[x, y] == false & count == 3)
                    {
                        scratchPad[x, y] = true;
                    }
                    //Turn it on/off the scratchPad

                }
            }
            //Copy from scratchPad to Universe
            bool[,] temp = universe;
            universe = scratchPad;
            scratchPad = temp;

            // Increment generation count
            generations++;

            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();

            //Invaildate the Graphics Panel
            graphicsPanel1.Invalidate();
        }
        private void CountNeighbors()
        {
            int alive = 0;
            int dead = 0;
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (universe[x, y] == true)
                    {
                        alive++;
                        AliveStripStatusLabel1.Text = "Alive Cells = " + alive.ToString();
                    }
                    if (universe[x, y] == false)
                    {
                        dead++;
                        DeadStripStatusLabel1.Text = "Dead Cells = " + dead.ToString();
                    }
                }
            }
            graphicsPanel1.Invalidate();
        }

        private int CountNeighborsFinite(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;
                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == yOffset)
                        continue;
                    // if xCheck is less than 0 then continue
                    if (xCheck < 0)
                        continue;
                    // if yCheck is less than 0 then continue
                    if (yCheck < 0)
                        continue;
                    // if xCheck is greater than or equal too xLen then continue
                    if (xCheck >= xLen)
                        continue;
                    // if yCheck is greater than or equal too yLen then continue
                    if (yCheck >= yLen)
                        continue;
                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
            return count;
        }
        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
            CountNeighbors();
        }

        private void Randomize()
        {
            Random random = new Random();
            Random randomSeed = new Random(seed);

            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    random.Next(0, 2);
                    if (random.Next(0, 2) == 0)
                        universe[x, y] = true;
                }
            }
            CountNeighbors();
            SeedStripStatusLabel.Text = "Seed = " + random.Next(0, 100000).ToString();
            graphicsPanel1.Invalidate();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    RectangleF cellRect = RectangleF.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                        if (isToroidal == true)
                        {
                            e.Graphics.DrawString(CountNeighborsToroidal(x, y).ToString(), font, Brushes.Black, cellRect, stringFormat);
                        }
                        else
                        {
                            e.Graphics.DrawString(CountNeighborsFinite(x, y).ToString(), font, Brushes.Black, cellRect, stringFormat);
                        }

                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);

                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];
                if (isToroidal == true)
                    CountNeighborsToroidal(x, y);
                else
                    CountNeighborsFinite(x, y);

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int CountNeighborsToroidal(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;
                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 & yOffset == 0)
                    {
                        continue;
                    }
                    // if xCheck is less than 0 then set to xLen - 1
                    if (xCheck < 0)
                    {
                        xLen = -1;
                    }
                    // if yCheck is less than 0 then set to yLen - 1
                    if (yCheck < 0)
                        yLen = -1;
                    // if xCheck is greater than or equal too xLen then set to 0
                    if (xCheck >= xLen)
                        xCheck = 0;
                    // if yCheck is greater than or equal too yLen then set to 0
                    if (yCheck >= yLen)
                    {
                        yCheck = 0;
                    }
                    if (universe[xCheck, yCheck]) count++;
                }
            }
            return count;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                }
            }
            graphicsPanel1.Invalidate();
            timer.Enabled = false;
            generations = 0;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";


            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                // Write any comments you want to include first.
                // Prefix all comment strings with an exclamation point.
                // Use WriteLine to write the strings to the file. 
                // It appends a CRLF for you.
                writer.WriteLine("!Save as a text file(example.txt)");

                // Iterate through the universe one row at a time.
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    // Create a string to represent the current row.
                    String currentRow = string.Empty;

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // to the row string.
                        if (universe[x, y])
                        {
                            currentRow += 'O';
                        }
                        // Else if the universe[x,y] is dead then append '.' (period)
                        // to the row string.
                        else
                        {
                            currentRow += '.';
                        }
                    }
                    // Once the current row has been read through and the 
                    // string constructed then write it to the file using WriteLine.
                    writer.WriteLine(currentRow);
                }

                // After all rows and columns have been written then close the file.
                writer.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;
            int yPos = 0;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;

                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.
                    if(row[0] == '!')
                    {
                        continue;
                    }
                    // If the row is not a comment then it is a row of cells.
                    // Increment the maxHeight variable for each row read.
                    else
                    {
                        maxHeight++;
                    }
                    // Get the length of the current row string
                    // and adjust the maxWidth variable if necessary.
                    maxWidth = row.Length;
                }

                // Resize the current universe and scratchPad
                // to the width and height of the file calculated above.
                universe = new bool[maxWidth, maxHeight];
                scratchPad = new bool[maxWidth, maxHeight];
                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // Iterate through the file again, this time reading in the cells.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.
                    if (row[0] == '!')
                        continue;
                    // If the row is not a comment then 
                    // it is a row of cells and needs to be iterated through.
                    for (int xPos = 0; xPos < row.Length; xPos++)
                    {
                        // If row[xPos] is a 'O' (capital O) then
                        // set the corresponding cell in the universe to alive.
                        if(row[xPos] == 'O')
                            universe[xPos,yPos] = true;
                        // If row[xPos] is a '.' (period) then
                        // set the corresponding cell in the universe to dead.
                        if(row[xPos] == '.')
                            universe[xPos, yPos] = false;
                    }
                    yPos++;
                }

                // Close the file.
                reader.Close();
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = cellColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;

                graphicsPanel1.Invalidate();
            }

        }

        private void modalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModal dlg2 = new FormModal();
            dlg2.Number = seed;

            if (DialogResult.OK == dlg2.ShowDialog())
            {
                seed = dlg2.Number;
                Randomize();
                SeedStripStatusLabel.Text = "Seed = " + seed.ToString();
            }
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;

                graphicsPanel1.Invalidate();
            }
        }

        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = gridColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;

                graphicsPanel1.Invalidate();
            }

        }

        private void randomizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Randomize();
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OptionsForm options = new OptionsForm();

            options.Number = timer.Interval;
            options.WidthNum = uniWith;
            options.HeightNum = uniHeight;

            if (DialogResult.OK == options.ShowDialog())
            {
                uniWith = options.WidthNum;
                uniHeight = options.HeightNum;
                timer.Interval = options.Number;
                timeStripStatusLabel1.Text = "Time Interval = " + timer.Interval.ToString();
                universe = new bool[uniWith, uniHeight];
                scratchPad = new bool[uniWith, uniHeight];

                graphicsPanel1.Invalidate();
            }
        }

        private void toggleGridLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toggleGridLinesToolStripMenuItem.Checked)
                gridColor = Color.Empty;
            else
            {
                gridColor = Color.Black;
            }
        }

        private void finiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isToroidal = false;
            toroidalToolStripMenuItem.Checked = false;
        }

        private void toroidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isToroidal = true;
            finiteToolStripMenuItem.Checked = false;
        }

        private void toggleHUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = !statusStrip1.Visible;

        }

        public void WhosWho()
        {
            if (toroidalToolStripMenuItem.Checked == true)
                CountStripStatusLabel1.Text = "Counting Style = Toroidal";
            else
                CountStripStatusLabel1.Text = "Counting Style = Finite";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.BackColor = graphicsPanel1.BackColor;
            Properties.Settings.Default.GridColor = gridColor;
            Properties.Settings.Default.CellColor = cellColor;
            Properties.Settings.Default.Time = timer.Interval;
            Properties.Settings.Default.UniWidth = uniWith;
            Properties.Settings.Default.UniHeight = uniHeight;
            Properties.Settings.Default.IsTorodial = isToroidal;

            Properties.Settings.Default.Save();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();

            graphicsPanel1.BackColor = Properties.Settings.Default.BackColor;
            gridColor = Properties.Settings.Default.GridColor;
            cellColor = Properties.Settings.Default.CellColor;
            timer.Interval = Properties.Settings.Default.Time;
            uniWith = Properties.Settings.Default.UniWidth;
            uniHeight = Properties.Settings.Default.UniHeight;
            isToroidal = Properties.Settings.Default.IsTorodial;
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();

            graphicsPanel1.BackColor = Properties.Settings.Default.BackColor;
            gridColor = Properties.Settings.Default.GridColor;
            cellColor = Properties.Settings.Default.CellColor;
            timer.Interval = Properties.Settings.Default.Time;
            uniWith = Properties.Settings.Default.UniWidth;
            uniHeight = Properties.Settings.Default.UniHeight;
            isToroidal = Properties.Settings.Default.IsTorodial;
        }

    }
}