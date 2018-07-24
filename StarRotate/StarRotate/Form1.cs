using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarRotate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static float CX, CY, cX, cY;
        private static double RAD = Math.PI / 180; 

        private void displayLine(String s,float xS,float yS,float xE,float yE)
        {
            Graphics g = panel.CreateGraphics();
            if (s == "Black")
            {
                g.DrawLine(Pens.Blue, xS, panel.Height - yS, xE, panel.Height - yE);
            }
            else
            {
                g.DrawLine(Pens.White, xS, panel.Height - yS, xE, panel.Height - yE);
            }
        }
        private void drawSun()
        {
            Graphics g = panel.CreateGraphics();
            g.DrawEllipse(Pens.Orange, CX - 25, panel.Height - (CY + 25), 50, 50);
            g.FillEllipse(Brushes.Orange, CX - 25, panel.Height - (CY + 25), 50, 50);
        }
        private void drawStar(String s, float[] x, float[] y)
        {
            displayLine(s, x[0], y[0], x[1], y[1]);
            displayLine(s, x[1], y[1], x[2], y[2]);
            displayLine(s, x[2], y[2], x[0], y[0]);
        }
        private void rotateStar()
        {
            Graphics g = panel.CreateGraphics();
            float[] x1 = new float[3];
            float[] y1 = new float[3];
            float[] x2 = new float[3];
            float[] y2 = new float[3];
            int j = 0, k = 0;
            for(int i = 0; i >= 0; i++)
            {
                cX = CX + (float)(175 * Math.Cos(i * RAD));
                cY = CY + (float)(175 * Math.Sin(i * RAD));
                x1[0] = cX + (float)(50 * Math.Cos(j * RAD));
                y1[0] = cY + (float)(50 * Math.Sin(j * RAD));
                x1[1] = cX + (float)(50 * Math.Cos((j + 120) * RAD));
                y1[1] = cY + (float)(50 * Math.Sin((j + 120) * RAD));
                x1[2] = cX + (float)(50 * Math.Cos((j + 240) * RAD));
                y1[2] = cY + (float)(50 * Math.Sin((j + 240) * RAD));
                x2[0] = cX - (float)(50 * Math.Cos(k * RAD));
                y2[0] = cY - (float)(50 * Math.Sin(k * RAD));
                x2[1] = cX - (float)(50 * Math.Cos((k + 120) * RAD));
                y2[1] = cY - (float)(50 * Math.Sin((k + 120) * RAD));
                x2[2] = cX - (float)(50 * Math.Cos((k + 240) * RAD));
                y2[2] = cY - (float)(50 * Math.Sin((k + 240) * RAD));
                drawStar("Black", x1, y1);
                drawStar("Black", x2, y2);
                Task.Delay(20).Wait();
                drawStar("White", x1, y1);
                drawStar("White", x2, y2);
                g.DrawEllipse(Pens.Gray, CX - 175, panel.Height - (CY + 175), 350, 350);
                i = i % 360;
                j--;
                k++;
            }
        }
        private void thread()
        {
            CX = panel.Width / 2;
            CY = panel.Height / 2;
            drawSun();
            rotateStar();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(thread);
            t.Start();
        }
    }
}
