using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace malovani
{
    public partial class Form1 : Form
    {
        public Point current = new Point();
        public Point old = new Point();
        public Graphics g;
        public Graphics graph;
        public Pen pen = new Pen(Color.Black, 3);
        public Point shapeOld = new Point();
        public Point shapeNew = new Point();
        public bool buttonCliked = false;
        Bitmap surface;
        public Form1()

        {
            InitializeComponent();
            
            g = flowLayoutPanel1.CreateGraphics();


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

        public void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            old = e.Location;
            shapeOld = e.Location;
        }

        private void flowLayoutPanel1_MouseHover(object sender, EventArgs e)
        {
        }

        public void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(buttonCliked == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    current = e.Location;
                    g.DrawLine(pen, old, current);
                    old = current;
                    
                }
            }
            else 
            {

                if (e.Button == MouseButtons.Left)
                {
                    shapeNew = e.Location;
                }
            }
        }

        private void buttonBLue_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Blue;
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            pen.Color= Color.Red;
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Green;
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Yellow;
        }

        private void buttonBlack_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Black;
        }

        private void buttonLightBlue_Click(object sender, EventArgs e)
        {
            pen.Color = Color.LightSkyBlue;
        }

        private void buttonOrange_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Orange;
        }

        private void buttonLightGreen_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Lime;
        }

        private void buttonPink_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Fuchsia;
        }

        private void buttonWhite_Click(object sender, EventArgs e)
        {
            pen.Color = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            g.FillRectangle(Brushes.White, 0, 0, flowLayoutPanel1.Width, flowLayoutPanel1.Height);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           trackBarWidth.TickFrequency = 1;
            trackBarWidth.Maximum = 50;
            trackBarWidth.Minimum = 1;
            pen.Width = trackBarWidth.Value;

        }

        public void buttonRectangle_Click(object sender, EventArgs o)
        {
            buttonCliked = true;
            int width = shapeNew.X - shapeOld.X;
            int height = shapeNew.Y - shapeOld.Y;

            
             g.DrawRectangle(pen, shapeOld.X, shapeOld.Y, width, height);
            
        } 

    }
}
