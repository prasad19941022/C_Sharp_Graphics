using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intersect2Lines
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int R;

        private void DisplayPoint(float x, float y)
        {
            Graphics g = panel1.CreateGraphics();
            g.DrawLine(Pens.Black, x, panel1.Height - y, x + 0.1F, panel1.Height - y);
        }
        private void DisplayLine(float x1, float y1, float x2, float y2)
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
        private int CheckIntersect()
        {
            float t1, t2, t3, t4;
            float Xs1, Ys1, Xe1, Ye1, Xs2, Ys2, Xe2, Ye2;

            Xs1 = float.Parse(txtXs1.Text);
            Ys1 = float.Parse(txtYs1.Text);
            Xe1 = float.Parse(txtXe1.Text);
            Ye1 = float.Parse(txtYe1.Text);
            Xs2 = float.Parse(txtXs2.Text);
            Ys2 = float.Parse(txtYs2.Text);
            Xe2 = float.Parse(txtXe2.Text);
            Ye2 = float.Parse(txtYe2.Text);

            t1 = Xs1 * (Ye1 - Ys2) + Xe1 * (Ys2 - Ys1) + Xs2 * (Ys1 - Ye1);
            t2 = Xs1 * (Ye1 - Ye2) + Xe1 * (Ye2 - Ys1) + Xe2 * (Ys1 - Ye1);
            t3 = Xs2 * (Ye2 - Ys1) + Xe2 * (Ys1 - Ys2) + Xs1 * (Ys2 - Ye2);
            t4 = Xs2 * (Ye2 - Ye1) + Xe2 * (Ye1 - Ys2) + Xe1 * (Ys2 - Ye2);

            if (t1 * t2 > 0 && t3 * t4 > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void btnDraw1_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayLine(float.Parse(txtXs1.Text), float.Parse(txtYs1.Text), float.Parse(txtXe1.Text), float.Parse(txtYe1.Text));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
        private void btnDraw2_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayLine(float.Parse(txtXs2.Text), float.Parse(txtYs2.Text), float.Parse(txtXe2.Text), float.Parse(txtYe2.Text));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            txtXs1.Text = null;
            txtYs1.Text = null;
            txtXe1.Text = null;
            txtYe1.Text = null;
            txtXs2.Text = null;
            txtYs2.Text = null;
            txtXe2.Text = null;
            txtYe2.Text = null;
            txtOutput.Text = null;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            R = CheckIntersect();
            if (R == 0)
            {
                txtOutput.Text = "These 2 lines are not Intersect";
            }
            else
            {
                float X, Y, M1, M2, C1, C2;
                M1 = (float.Parse(txtYe1.Text) - float.Parse(txtYs1.Text)) / (float.Parse(txtXe1.Text) - float.Parse(txtXs1.Text));
                M2 = (float.Parse(txtYe2.Text) - float.Parse(txtYs2.Text)) / (float.Parse(txtXe2.Text) - float.Parse(txtXs2.Text));
                C1 = float.Parse(txtYs1.Text) - M1 * float.Parse(txtXs1.Text);
                C2 = float.Parse(txtYs2.Text) - M2 * float.Parse(txtXs2.Text);

                X = (C2 - C1) / (M1 - M2);
                Y = (C1 * M2 - C2 * M1) / (M2 - M1);

                txtOutput.Text = "These 2 lines are Intersect in ( " + X + ", " + Y + " )";
            }
        }
    }
}