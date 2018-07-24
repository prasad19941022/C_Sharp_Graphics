using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static double RAD = Math.PI / 180;

        private void displayLine(String s,float xS,float yS,float xE,float yE)
        {
            Graphics g = panel.CreateGraphics();
            if (s == "Red")
            {
                g.DrawLine(Pens.Red, xS, panel.Height - yS, xE, panel.Height - yE);
            }
            else if (s == "Black")
            {
                g.DrawLine(Pens.Black, xS, panel.Height - yS, xE, panel.Height - yE);
            }
            else if (s == "Blue")
            {
                g.DrawLine(Pens.Blue, xS, panel.Height - yS, xE, panel.Height - yE);
            }
            else
            {
                g.DrawLine(Pens.White, xS, panel.Height - yS, xE, panel.Height - yE);
            }
        }
        private void displayNumbers()
        {
            Graphics g = panel.CreateGraphics();
            Font f = new Font("Arial", 15);
            Point[] p = new Point[12];
            int j = 0;
            for(int i = 0; i < 360; i = i + 30)
            {
                p[j].X = (int)(240 + (235 * Math.Cos(i * RAD)));
                p[j].Y = (int)(240 + (235 * Math.Sin(i * RAD)));
                j++;
            }
            g.DrawString("3", f, Brushes.Black, p[0]);
            g.DrawString("4", f, Brushes.Black, p[1]);
            g.DrawString("5", f, Brushes.Black, p[2]);
            g.DrawString("6", f, Brushes.Black, p[3]);
            g.DrawString("7", f, Brushes.Black, p[4]);
            g.DrawString("8", f, Brushes.Black, p[5]);
            g.DrawString("9", f, Brushes.Black, p[6]);
            g.DrawString("10", f, Brushes.Black, p[7]);
            g.DrawString("11", f, Brushes.Black, p[8]);
            g.DrawString("12", f, Brushes.Black, p[9]);
            g.DrawString("1", f, Brushes.Black, p[10]);
            g.DrawString("2", f, Brushes.Black, p[11]);
        }
        private void displayClockBackground()
        {
            Graphics g = panel.CreateGraphics();
            double x, y;
            for (int i = 0; i < 360; i = i + 6)
            {
                x = 240 + (210 * Math.Cos(i * RAD));
                y = 240 + (210 * Math.Sin(i * RAD));
                g.DrawEllipse(Pens.Blue, (float)x, (float)y, 15, 15);
                if (i % 30 == 0)
                {
                    g.FillEllipse(Brushes.Blue, (float)x, (float)y, 15, 15);
                }
            }
        }

        private void thread1()
        {
            displayNumbers();
            displayClockBackground();
        }
        private void thread2()
        {
            double[] x = new double[3];
            double[] y = new double[3];
            for (int i = 90; i <= 360; i = i - 6)
            {
                x[0] = (250 + (190 * Math.Cos(i * RAD)));
                y[0] = (250 + (190 * Math.Sin(i * RAD)));
                x[1] = (250 + (170 * Math.Cos(((i / 60) + 90) * RAD)));
                y[1] = (250 + (170 * Math.Sin(((i / 60) + 90) * RAD)));
                x[2] = (250 + (150 * Math.Cos(((i / 120) + 90) * RAD)));
                y[2] = (250 + (150 * Math.Sin(((i / 120) + 90) * RAD)));
                displayLine("Red", 250, 250, (float)x[0], (float)y[0]);
                displayLine("Black", 250, 250, (float)x[1], (float)y[1]);
                displayLine("Blue", 250, 250, (float)x[2], (float)y[2]);
                Task.Delay(1000).Wait();
                displayLine("White", 250, 250, (float)x[0], (float)y[0]);
                displayLine("White", 250, 250, (float)x[1], (float)y[1]);
                displayLine("White", 250, 250, (float)x[2], (float)y[2]);
                i = i % 360;
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            System.Threading.Thread t1 = new System.Threading.Thread(thread1);
            System.Threading.Thread t2 = new System.Threading.Thread(thread2);
            t1.Start();
            t2.Start();
        }
    }
}