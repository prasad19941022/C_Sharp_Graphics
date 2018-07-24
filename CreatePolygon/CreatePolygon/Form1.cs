using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatePolygon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private float[] arrX = new float[100];
        private float[] arrY = new float[100];
        private int i = 0;

        private void DisplayPoint(float x, float y)
        {
            Graphics g = panel1.CreateGraphics();
            g.DrawLine(Pens.Black, x, panel1.Height - y, x + 0.1F, panel1.Height - y);
        }
        private void DrawLine(float x1,float y1,float x2,float y2)
        {
            if(x1==x2 && y1 == y2)
            {
                DisplayPoint(x1, y1);
            }
            else
            {
                Graphics g = panel1.CreateGraphics();
                g.DrawLine(Pens.Black, x1, panel1.Height - y1, x2, panel1.Height - y2);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtVertices.Text);
            if (n>=3 && i != n)
            {
                arrX[i] = float.Parse(txtX.Text);
                arrY[i] = float.Parse(txtY.Text);
                listBox1.Items.Add("( " + arrX[i] + ", " + arrY[i] + " )");
                i++;
                txtX.Text = null;
                txtY.Text = null;
                if (i != n)
                {
                    groupBox1.Text = "Point " + (i + 1);
                }
                else
                {
                    lblDraw.Text = "Now draw the Polygon...";
                }
            }
            else
            {
                if (n < 3)
                {
                    MessageBox.Show("Invalid number of Vertices");
                }
                if (i >= n)
                {
                    MessageBox.Show("You have already define the correct number of Vertices");
                }
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            int j;
            for (j = 0; j < int.Parse(txtVertices.Text); j++)
            {
                if(j== int.Parse(txtVertices.Text) - 1)
                {
                    DrawLine(arrX[j], arrY[j], arrX[0], arrY[0]);
                }
                else
                {
                    DrawLine(arrX[j], arrY[j], arrX[j + 1], arrY[j + 1]);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            arrX = new float[100];
            arrY = new float[100];
            i = 0;
            txtVertices.Text = null;
            lblDraw.Text = "Enter Points";
            groupBox1.Text = "Point 1";
            listBox1.Items.Clear();
            panel1.Invalidate();
        }
    }
}
