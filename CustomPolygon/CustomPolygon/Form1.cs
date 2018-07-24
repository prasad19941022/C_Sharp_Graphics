using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomPolygon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private float[] arrX = new float[50];
        private float[] arrY = new float[50];
        private int points = 0;

        private void displayLine(float xS,float yS,float xE,float yE)
        {
            Graphics g = panel1.CreateGraphics();
            g.DrawLine(Pens.Black, xS, panel1.Height - yS, xE, panel1.Height - yE);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            arrX[points] = e.X;
            arrY[points] = panel1.Height-e.Y;
            if (points >= 1)
            {
                displayLine(arrX[points-1], arrY[points-1],arrX[points],arrY[points]);
            }
            points++;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            arrX = new float[50];
            arrY = new float[50];
            points = 0;
        }
    }
}
