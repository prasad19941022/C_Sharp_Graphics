using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scaling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private float[] arrX = new float[10];
        private float[] arrY = new float[10];

        private void displayLine(String s,float xS,float yS,float xE,float yE)
        {
            Graphics g = panel.CreateGraphics();
            if (s == "White")
            {
                g.DrawLine(Pens.White, xS, panel.Height - yS, xE, panel.Height - yE);
            }
            else
            {
                g.DrawLine(Pens.Black, xS, panel.Height - yS, xE, panel.Height - yE);
            }
        }
        private void getRandomPoints(int n)
        {
            Random r = new Random();
            for(int i = 0; i < n; i++)
            {
                arrX[i] = r.Next(125, 375);
                arrY[i] = r.Next(125, 375);
            }
        }
        private void displayPolygon(String s)
        {
            int points = int.Parse(txtVertices.Text);
            for (int i = 0; i < points; i++)
            {
                displayLine(s, arrX[i % points], arrY[i % points], arrX[(i + 1) % points], arrY[(i + 1) % points]);
            }
        }
        private float getMax(float[] arr)
        {
            float tmp=arr[0];
            for(int i = 1; i < int.Parse(txtVertices.Text); i++)
            {
                if (tmp < arr[i])
                {
                    tmp = arr[i];
                }
            }
            return tmp;
        }
        private float getMin(float[] arr)
        {
            float tmp = arr[0];
            for (int i = 1; i < int.Parse(txtVertices.Text); i++)
            {
                if (tmp > arr[i])
                {
                    tmp = arr[i];
                }
            }
            return tmp;
        }
        private void getScalePoints(int n)
        {
            float gX = getMin(arrX) + (getMax(arrX) - getMin(arrX)) / 2;
            float gY = getMin(arrY) + (getMax(arrY) - getMin(arrY)) / 2;
            for(int i = 0; i < int.Parse(txtVertices.Text); i++)
            {
                arrX[i] = n * (arrX[i] - gX) + gX;
                arrY[i] = n * (arrY[i] - gY) + gY;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            getRandomPoints(int.Parse(txtVertices.Text));
            displayPolygon("Black");
        }
        private void btnScale_Click(object sender, EventArgs e)
        {
            displayPolygon("White");
            getScalePoints(int.Parse(txtScale.Text));
            displayPolygon("Black");
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            panel.Invalidate();
            arrX = new float[10];
            arrY = new float[10];
            txtScale.Text = null;
            txtVertices.Text = null;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
