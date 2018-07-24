using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaOfCustomPolygon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public float[] x = new float[50];
        public float[] y = new float[50];
        public int n=0;

        private void drawLine(float xS, float yS, float xE, float yE)
        {
            Graphics g = panel1.CreateGraphics();
            g.DrawLine(Pens.Black, xS, panel1.Height - yS, xE, panel1.Height - yE);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            int v = int.Parse(txtVertices.Text);
            x[n] = e.X;
            y[n] = panel1.Height - e.Y;
            if (n > 0 && n < v)
            {
                drawLine(x[n - 1], y[n - 1], x[n], y[n]);
            }
            if (n == v - 1)
            {
                drawLine(x[n], y[n], x[0], y[0]);
            }
            n++;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Draw a Polygon...\n(Caution :- This is only for Convex Polygons)");
            panel1.Enabled = true;
            groupBox2.Enabled = true;
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            int i;
            int v = int.Parse(txtVertices.Text);
            float[] arr = new float[v - 2];
            float sum=0;
            for (i = 0; i < v - 2; i++)
            {
                arr[i] = (x[0] * (y[i + 1] - y[i + 2]) + x[i + 1] * (y[i + 2] - y[0]) + x[i + 2] * (y[0] - y[i + 1])) / 2;
                sum = sum + arr[i];
            }
            txtArea.Text = "" + Math.Abs(sum);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            groupBox2.Enabled = false;
            n = new int();
            x = new float[50];
            y = new float[50];
            txtVertices.Clear();
            txtVertices.Focus();
            txtArea.Text = "0";
        }
    }
}
