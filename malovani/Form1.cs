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
        Color customColor = Color.FromArgb(50, Color.Black);
        public Point shapeOld = new Point();
        public Point shapeNew = new Point();
        public bool buttonCliked = false;
        public int reset = 0;
        public int shapes = 0;
        public int tool = 1;
        Bitmap surface;
        public Form1()

        {
            InitializeComponent();
            
            g = flowLayoutPanel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

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
            if (e.Button == MouseButtons.Left && buttonCliked == false)
            {
                switch (tool)
                {
                    case 1:

                        current = e.Location;
                        g.DrawLine(pen, old, current);
                        old = current;
                        break;
                    case 2:
                        current = e.Location;
                        Pen brush = new Pen(Color.FromArgb(17, pen.Color), pen.Width);
                        brush.StartCap = brush.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        g.DrawLine(brush, old, current);
                        old = current;
                        break;
                    case 3:
                        customColor = pen.Color;
                        Brush spray = new SolidBrush(customColor);
                        Random rnd = new Random();
                        int border = Convert.ToInt32(pen.Width);
                        int size = rnd.Next(1, border / 2);
                        g.FillEllipse(spray, e.X + rnd.Next(border, border * 2), e.Y + rnd.Next(border, border * 2), size, size); 
                        spray.Dispose();
                        break;
                    case 4: // kdyz je pomalejsi tak je sirsi
                        
                        current = e.Location;
                        double distance = Math.Sqrt(Math.Pow(e.X - old.X, 2) + Math.Pow(e.Y - old.Y, 2));
                        double speed = distance / pen.Width; 
                        float pencilWidth = (float)(pen.Width / speed);
                        Pen pen4 = new Pen(pen.Color, pencilWidth);
                        pen4.StartCap = pen4.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        g.DrawLine(pen4, old, current);
                        old = current;
                        break;
                    

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

            if (shapes == 2 || shapes == 3 || shapes == 4)
            {
                reset = 0;
            }
            if (reset == 0)
            {
                shapeNew.X = 0;
                shapeNew.Y = 0;
                shapeOld.X = 0;
                shapeOld.Y = 0;
            }
            reset++;
                buttonCliked = true;
            int width = shapeNew.X - shapeOld.X;
            int height = shapeNew.Y - shapeOld.Y;
             g.DrawRectangle(pen, shapeOld.X, shapeOld.Y, width, height);
            shapes = 1;
        }

        private void flowLayoutPanel1_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                shapeNew = e.Location;
            }
        }

        private void buttonElipse_Click(object sender, EventArgs e)
        {
            if (shapes == 1 || shapes == 3 || shapes == 4 || shapes == 5)
            {
                reset = 0;
            }
            if (reset == 0)
            {
                shapeNew.X = 0;
                shapeNew.Y = 0;
                shapeOld.X = 0;
                shapeOld.Y = 0;
            }
            reset++;
            buttonCliked = true;
            int width = shapeNew.X - shapeOld.X;
            int height = shapeNew.Y - shapeOld.Y;
            g.DrawEllipse(pen, shapeOld.X, shapeOld.Y, width, height);
            shapes = 2;
        }

        private void buttonFilledRectangle_Click(object sender, EventArgs e)
        {
            customColor = pen.Color;
            SolidBrush brush = new SolidBrush(customColor);

            if (shapes == 1 || shapes == 2 || shapes == 4 || shapes == 5)
            {
                reset = 0;
            }
            if (reset == 0)
            {
                shapeNew.X = 0;
                shapeNew.Y = 0;
                shapeOld.X = 0;
                shapeOld.Y = 0;
            }
            reset++;
            buttonCliked = true;
            int width = shapeNew.X - shapeOld.X;
            int height = shapeNew.Y - shapeOld.Y;
            g.FillRectangle(brush, shapeOld.X, shapeOld.Y, width, height);
            shapes = 3;
            brush.Dispose();
        }

        private void buttonFilledEllipse_Click(object sender, EventArgs e)
        {
            customColor = pen.Color;
            SolidBrush brush = new SolidBrush(customColor);

            if (shapes == 1 || shapes == 2 || shapes == 3 || shapes == 5)
            {
                reset = 0;
            }
            if (reset == 0)
            {
                shapeNew.X = 0;
                shapeNew.Y = 0;
                shapeOld.X = 0;
                shapeOld.Y = 0;
            }
            reset++;
            buttonCliked = true;
            int width = shapeNew.X - shapeOld.X;
            int height = shapeNew.Y - shapeOld.Y;
            g.FillEllipse(brush, shapeOld.X, shapeOld.Y, width, height);
            shapes = 4;
            brush.Dispose();
        }

        private void buttonPencil_Click(object sender, EventArgs e)
        {
            reset = 0;
            buttonCliked = false;
            tool = 1;
        }

        private void buttonBrush_Click(object sender, EventArgs e)
        {
            reset = 0;
            buttonCliked = false;
            tool = 2;

        }

        private void buttonSpray_Click(object sender, EventArgs e)
        {
            reset = 0;
            buttonCliked = false;
            tool = 3;
        }

        private void buttonPen_Click(object sender, EventArgs e)
        {
            reset = 0;
            buttonCliked = false;
            tool = 4;
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            if (shapes == 1 || shapes == 2 || shapes == 3 || shapes == 4)
            {
                reset = 0;
            }
            if (reset == 0)
            {
                shapeNew.X = 0;
                shapeNew.Y = 0;
                shapeOld.X = 0;
                shapeOld.Y = 0;
            }
            reset++;
            buttonCliked = true;
            g.DrawLine(pen,shapeOld,shapeNew);
            shapes = 5;
        }
    }
}
