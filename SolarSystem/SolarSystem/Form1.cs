using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static float CX, CY;
        private static double RAD = Math.PI / 180;

        private float[] calXY(double A, double B, int i, float cx, float cy)
        {
            float[] arr = new float[2];
            arr[0] = (float)Math.Sqrt((A * B) / (B + (A * Math.Pow(Math.Tan(i * RAD), 2))));
            arr[1] = (float)(arr[0] * Math.Tan(i * RAD));
            return arr;
        }
        private void drawWorld()
        {
            
        }
        private void displaySun()
        {
            Graphics g = panel.CreateGraphics();
            g.DrawEllipse(Pens.Yellow, CX - 38, panel.Height - (CY + 38), 76, 76);
            g.FillEllipse(Brushes.Yellow, CX - 38, panel.Height - (CY + 38), 76, 76);
        }
        private void displayMercury()
        {
            Graphics g = panel.CreateGraphics();
            float[] c = new float[2];
            double A = Math.Pow(100, 2);
            double B = Math.Pow(50, 2);
            for (int i = 0; i >= 0; i++)
            {
                c = calXY(A, B, i, CX, CY);
                if (i > 90 && i < 270)
                {
                    c[0] = c[0] * (-1);
                    c[1] = c[1] * (-1);
                }
                g.DrawEllipse(Pens.Gray, CX - 100, panel.Height - (CY + 50), 200, 100);
                g.DrawEllipse(Pens.DarkGray, CX + c[0] - 4, panel.Height - (CY + c[1] + 4), 8, 8);
                g.FillEllipse(Brushes.DarkGray, CX + c[0] - 4, panel.Height - (CY + c[1] + 4), 8, 8);
                Task.Delay(30).Wait();
                g.DrawEllipse(Pens.Black, CX + c[0] - 4, panel.Height - (CY + c[1] + 4), 8, 8);
                g.FillEllipse(Brushes.Black, CX + c[0] - 4, panel.Height - (CY + c[1] + 4), 8, 8);
                i = i % 360;
            }
        }
        private void displayVenus()
        {
            Graphics g = panel.CreateGraphics();
            float[] c = new float[2];
            double A = Math.Pow(130, 2);
            double B = Math.Pow(75, 2);
            for (int i = 360; i >= 0; i--)
            {
                c = calXY(A, B, i, CX, CY);
                
                if (i > 90 && i < 270)
                {
                    c[0] = c[0] * (-1);
                    c[1] = c[1] * (-1);
                }
                g.DrawEllipse(Pens.Gray, CX - 130, panel.Height - (CY + 75), 260, 150);
                g.DrawEllipse(Pens.SandyBrown, CX + c[0] - 10, panel.Height - (CY + c[1] + 10), 20, 20);
                g.FillEllipse(Brushes.SandyBrown, CX + c[0] - 10, panel.Height - (CY + c[1] + 10), 20, 20);
                Task.Delay(60).Wait();
                g.DrawEllipse(Pens.Black, CX + c[0] - 10, panel.Height - (CY + c[1] + 10), 20, 20);
                g.FillEllipse(Brushes.Black, CX + c[0] - 10, panel.Height - (CY + c[1] + 10), 20, 20);
                if (i == 0)
                {
                    i = 360;
                }
            }
        }
        private void displayEarth()
        {
            Graphics g = panel.CreateGraphics();
            float[] c = new float[2];
            double A = Math.Pow(170, 2);
            double B = Math.Pow(100, 2);
            for (int i = 0; i >= 0; i++)
            {
                c = calXY(A, B, i, CX, CY);
                if (i > 90 && i < 270)
                {
                    c[0] = c[0] * (-1);
                    c[1] = c[1] * (-1);
                }
                g.DrawEllipse(Pens.Gray, CX - 170, panel.Height - (CY + 100), 340, 200);
                g.DrawEllipse(Pens.Blue, CX + c[0] - 8, panel.Height - (CY + c[1] + 8), 16, 16);
                g.FillEllipse(Brushes.Blue, CX + c[0] - 8, panel.Height - (CY + c[1] + 8), 16, 16);
                Task.Delay(120).Wait();
                g.DrawEllipse(Pens.Black, CX + c[0] - 8, panel.Height - (CY + c[1] + 8), 16, 16);
                g.FillEllipse(Brushes.Black, CX + c[0] - 8, panel.Height - (CY + c[1] + 8), 16, 16);
                i = i % 360;
            }
        }
        private void displayMars()
        {
            Graphics g = panel.CreateGraphics();
            float[] c = new float[2];
            double A = Math.Pow(220, 2);
            double B = Math.Pow(125, 2);
            for (int i = 0; i >= 0; i++)
            {
                c = calXY(A, B, i, CX, CY);
                if (i > 90 && i < 270)
                {
                    c[0] = c[0] * (-1);
                    c[1] = c[1] * (-1);
                }
                g.DrawEllipse(Pens.Gray, CX - 220, panel.Height - (CY + 125), 440, 250);
                g.DrawEllipse(Pens.Red, CX + c[0] - 6, panel.Height - (CY + c[1] + 6), 12, 12);
                g.FillEllipse(Brushes.Red, CX + c[0] - 6, panel.Height - (CY + c[1] + 6), 12, 12);
                Task.Delay(240).Wait();
                g.DrawEllipse(Pens.Black, CX + c[0] - 6, panel.Height - (CY + c[1] + 6), 12, 12);
                g.FillEllipse(Brushes.Black, CX + c[0] - 6, panel.Height - (CY + c[1] + 6), 12, 12);
                i = i % 360;
            }
        }
        private void displayJupiter()
        {
            Graphics g = panel.CreateGraphics();
            float[] c = new float[2];
            double A = Math.Pow(280, 2);
            double B = Math.Pow(175, 2);
            for (int i = 0; i >= 0; i++)
            {
                c = calXY(A, B, i, CX, CY);
                if (i > 90 && i < 270)
                {
                    c[0] = c[0] * (-1);
                    c[1] = c[1] * (-1);
                }
                g.DrawEllipse(Pens.Gray, CX - 280, panel.Height - (CY + 175), 560, 350);
                g.DrawEllipse(Pens.RosyBrown, CX + c[0] - 18, panel.Height - (CY + c[1] + 18), 36, 36);
                g.FillEllipse(Brushes.RosyBrown, CX + c[0] - 18, panel.Height - (CY + c[1] + 18), 36, 36);
                Task.Delay(480).Wait();
                g.DrawEllipse(Pens.Black, CX + c[0] - 18, panel.Height - (CY + c[1] + 18), 36, 36);
                g.FillEllipse(Brushes.Black, CX + c[0] - 18, panel.Height - (CY + c[1] + 18), 36, 36);
                i = i % 360;
            }
        }
        private void displaySaturn()
        {
            Graphics g = panel.CreateGraphics();
            float[] c = new float[2];
            double A = Math.Pow(340, 2);
            double B = Math.Pow(210, 2);
            for (int i = 0; i >= 0; i++)
            {
                c = calXY(A, B, i, CX, CY);
                if (i > 90 && i < 270)
                {
                    c[0] = c[0] * (-1);
                    c[1] = c[1] * (-1);
                }
                g.DrawEllipse(Pens.Gray, CX - 340, panel.Height - (CY + 210), 680, 420);
                g.DrawEllipse(Pens.Orange, CX + c[0] - 14, panel.Height - (CY + c[1] + 14), 28, 28);
                g.FillEllipse(Brushes.Orange, CX + c[0] - 14, panel.Height - (CY + c[1] + 14), 28, 28);
                Task.Delay(960).Wait();
                g.DrawEllipse(Pens.Black, CX + c[0] - 14, panel.Height - (CY + c[1] + 14), 28, 28);
                g.FillEllipse(Brushes.Black, CX + c[0] - 14, panel.Height - (CY + c[1] + 14), 28, 28);
                i = i % 360;
            }
        }
        private void displayUranus()
        {
            Graphics g = panel.CreateGraphics();
            float[] c = new float[2];
            double A = Math.Pow(410, 2);
            double B = Math.Pow(250, 2);
            for (int i = 360; i >= 0; i--)
            {
                c = calXY(A, B, i, CX, CY);
                if (i > 90 && i < 270)
                {
                    c[0] = c[0] * (-1);
                    c[1] = c[1] * (-1);
                }
                g.DrawEllipse(Pens.Gray, CX - 410, panel.Height - (CY + 250), 820, 500);
                g.DrawEllipse(Pens.LightSkyBlue, CX + c[0] - 12, panel.Height - (CY + c[1] + 12), 24, 24);
                g.FillEllipse(Brushes.LightSkyBlue, CX + c[0] - 12, panel.Height - (CY + c[1] + 12), 24, 24);
                Task.Delay(1920).Wait();
                g.DrawEllipse(Pens.Black, CX + c[0] - 12, panel.Height - (CY + c[1] + 12), 24, 24);
                g.FillEllipse(Brushes.Black, CX + c[0] - 12, panel.Height - (CY + c[1] + 12), 24, 24);
                if (i == 0)
                {
                    i = 360;
                }
            }
        }
        private void displayNeptune()
        {
            Graphics g = panel.CreateGraphics();
            float[] c = new float[2];
            double A = Math.Pow(490, 2);
            double B = Math.Pow(275, 2);
            for (int i = 0; i >= 0; i++)
            {
                c = calXY(A, B, i, CX, CY);
                if (i > 90 && i < 270)
                {
                    c[0] = c[0] * (-1);
                    c[1] = c[1] * (-1);
                }
                g.DrawEllipse(Pens.Gray, CX - 490, panel.Height - (CY + 275), 980, 550);
                g.DrawEllipse(Pens.BlueViolet, CX + c[0] - 11, panel.Height - (CY + c[1] + 11), 22, 22);
                g.FillEllipse(Brushes.BlueViolet, CX + c[0] - 11, panel.Height - (CY + c[1] + 11), 22, 22);
                Task.Delay(3840).Wait();
                g.DrawEllipse(Pens.Black, CX + c[0] - 11, panel.Height - (CY + c[1] + 11), 22, 22);
                g.FillEllipse(Brushes.Black, CX + c[0] - 11, panel.Height - (CY + c[1] + 11), 22, 22);
                i = i % 360;
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            CX = panel.Width / 2;
            CY = panel.Height / 2;
            System.Threading.Thread sun = new System.Threading.Thread(displaySun);
            System.Threading.Thread mercury = new System.Threading.Thread(displayMercury);
            System.Threading.Thread venus = new System.Threading.Thread(displayVenus);
            System.Threading.Thread earth = new System.Threading.Thread(displayEarth);
            System.Threading.Thread mars = new System.Threading.Thread(displayMars);
            System.Threading.Thread jupiter = new System.Threading.Thread(displayJupiter);
            System.Threading.Thread saturn = new System.Threading.Thread(displaySaturn);
            System.Threading.Thread uranus = new System.Threading.Thread(displayUranus);
            System.Threading.Thread neptune = new System.Threading.Thread(displayNeptune);
            sun.Start();
            mercury.Start();
            venus.Start();
            earth.Start();
            mars.Start();
            jupiter.Start();
            saturn.Start();
            uranus.Start();
            neptune.Start();
        }
    }
}
