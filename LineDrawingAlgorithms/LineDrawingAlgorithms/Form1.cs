using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineDrawingAlgorithms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void displayPoint(float x, float y)
        {
            Graphics g = panel.CreateGraphics();
            g.DrawLine(Pens.Red, x, panel.Height - y, x + 0.1F, panel.Height - y);
        }

        private void btnDDA_Click(object sender, EventArgs e)
        {
            float x = float.Parse(txtXStart.Text);
            float y = float.Parse(txtYStart.Text);
            float dx = float.Parse(txtXEnd.Text) - x;
            float dy = float.Parse(txtYEnd.Text) - y;
            float steps;
            if (Math.Abs(dx) >= Math.Abs(dy))
            {
                steps = Math.Abs(dx);
            }
            else
            {
                steps = Math.Abs(dy);
            }
            float xInc = dx / dx;
            float yInc = dy / dx;
            displayPoint((float)Math.Round(x), (float)Math.Round(y));
            for(int i = 0; i < steps; i++)
            {
                x = x + xInc;
                y = y + yInc;
                displayPoint((float)Math.Round(x), (float)Math.Round(y));
            }
        }

        private void btnBresenham_Click(object sender, EventArgs e)
        {
            float x = float.Parse(txtXStart.Text);
            float y = float.Parse(txtYStart.Text);
            float dx = float.Parse(txtXEnd.Text) - x;
            float dy = float.Parse(txtYEnd.Text) - y;
            if ((dy / dx) < 1)
            {
                displayPoint(x, y);
                float pK = (2 * dy) - dx;
                float pN = 2 * dy;
                float pP = (2 * dy) - (2 * dx);
                while(x<=float.Parse(txtXEnd.Text) || y <= float.Parse(txtYEnd.Text))
                {
                    if (pK < 0)
                    {
                        displayPoint(x + 1, y);
                        pK = pK + pN;
                    }
                    else
                    {
                        displayPoint(x + 1, y + 1);
                        pK = pK + pP;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            panel.Invalidate();
            txtXStart.Text = null;
            txtYStart.Text = null;
            txtXEnd.Text = null;
            txtYEnd.Text = null;
        }
    }
}
