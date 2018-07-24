using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePolygon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private float[] x = new float[50];
        private float[] y = new float[50];
        private int v;

        private void displayLine(float xS, float yS, float xE, float yE)
        {
            Graphics g = panel1.CreateGraphics();
            g.DrawLine(Pens.Black, xS, panel1.Height - yS, xE, panel1.Height - yE);
        }

        private void drawPolygon()
        {
            int i;
            for (i = 0; i < v; i++)
            {
                displayLine(x[i], y[i], x[(i + 1) % v], y[(i + 1) % v]);
            }
        }

        private Boolean checkIntersect(float x1S, float y1S, float x1E, float y1E, float x2S, float y2S, float x2E, float y2E)
        {
            float t1 = x1S * (y1E - y2S) + x1E * (y2S - y1S) + x2S * (y1S - y1E);
            float t2 = x1S * (y1E - y2E) + x1E * (y2E - y1S) + x2E * (y1S - y1E);
            if (t1 * t2 > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean checkSimple()
        {
            int i, j, k;
            Boolean a, b;
            for (i = 0; i < v; i++)
            {
                j = i + 2;
                k = 0;
                while (k != (v - 3))
                {
                    j = j % v;
                    a = checkIntersect(x[i], y[i], x[(i + 1) % v], y[(i + 1) % v], x[j], y[j], x[(j + 1) % v], y[(j + 1) % v]);
                    b = checkIntersect(x[j], y[j], x[(j + 1) % v], y[(j + 1) % v], x[i], y[i], x[(i + 1) % v], y[(i + 1) % v]);
                    if (a==true && b==true)
                    {
                        return false;
                    }
                    j++;
                    k++;
                }
            }
            return true;
        }

        private Boolean checkConvex()
        {
            int i, j, k;
            for (i = 0; i < v; i++)
            {
                j = i + 2;
                k = 0;
                while (k != (v - 3))
                {
                    j = j % v;
                    if(checkIntersect(x[i], y[i], x[(i + 1) % v], y[(i + 1) % v], x[j], y[j], x[(j + 1) % v], y[(j + 1) % v]) == true)
                    {
                        return false;
                    }
                    j++;
                    k++;
                }
            }
            return true;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            int i;
            v = int.Parse(txtVertices.Text);
            Random r = new Random();
            if (v <= 50 && v>2)
            {
                for (i = 0; i < v; i++)
                {
                    x[i] = r.Next(0, panel1.Width);
                    y[i] = r.Next(0, panel1.Height);
                }
                drawPolygon();
            }
            else
            {
                MessageBox.Show("Invalid number of Vertices...\n(must be Vertices<=50 & Vertices>2)");
            }
        }

        private void btnSimple_Click(object sender, EventArgs e)
        {
            int i, k = 0;
            v = int.Parse(txtVertices.Text);
            Random r = new Random();
            if (v <= 50 && v > 2)
            {
                while (k == 0)
                {
                    for (i = 0; i < v; i++)
                    {
                        x[i] = r.Next(0, panel1.Width);
                        y[i] = r.Next(0, panel1.Height);
                    }
                    if (checkSimple() == true)
                    {
                        k = 1;
                        drawPolygon();
                    }
                }

            }
            else
            {
                MessageBox.Show("Invalid number of Vertices...\n(must be Vertices<=50 & Vertices>2)");
            }
        }

        private void btnConvex_Click(object sender, EventArgs e)
        {
            int i, k = 0;
            v = int.Parse(txtVertices.Text);
            Random r = new Random();
            if (v <= 50 && v > 2)
            {
                while (k == 0)
                {
                    for (i = 0; i < v; i++)
                    {
                        x[i] = r.Next(0, panel1.Width);
                        y[i] = r.Next(0, panel1.Height);
                    }
                    if (checkConvex() == true)
                    {
                        k = 1;
                        drawPolygon();
                    }
                }

            }
            else
            {
                MessageBox.Show("Invalid number of Vertices...\n(must be Vertices<=50 & Vertices>2)");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            txtVertices.Clear();
            x = new float[50];
            y = new float[50];
        }
    }
}
