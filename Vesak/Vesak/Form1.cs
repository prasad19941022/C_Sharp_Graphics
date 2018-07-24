using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vesak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public float[] arr0 = new float[8];
        public float[] arr1 = new float[8];
        public float[] arr2 = new float[8];
        public float[] arr3 = new float[8];
        public float[] arr4 = new float[8];
        public float piRad = (float)Math.PI / 180;
        public float cX, cY, r1, r2;

        private void displayLine(String s, float xS, float yS, float xE, float yE)
        {
            Graphics g = panel1.CreateGraphics();
            if (s == "Red")
            {
                g.DrawLine(Pens.Red, xS, panel1.Height - yS, xE, panel1.Height - yE);
            }
            else if (s == "Black")
            {
                g.DrawLine(Pens.Black, xS, panel1.Height - yS, xE, panel1.Height - yE);
            }
            else
            {
                g.DrawLine(Pens.White, xS, panel1.Height - yS, xE, panel1.Height - yE);
            }
        }
        private void displaySquare(String s, float [] arr)
        {
            for(int i = 0; i < arr.Length; i=i+2)
            {
                displayLine(s, arr[i % 8], arr[(i + 1) % 8], arr[(i + 2) % 8], arr[(i + 3) % 8]);
            }
        }
        private void displaySystem(String s,float[] arr0, float[] arr1, float[] arr2, float[] arr3, float[] arr4)
        {
            if (s == "White")
            {
                displaySquare("White", arr0);
                displaySquare("White", arr1);
                displaySquare("White", arr2);
                displaySquare("White", arr3);
                displaySquare("White", arr4);
            }
            else
            {
                displaySquare("Black", arr0);
                displaySquare("Red", arr1);
                displaySquare("Red", arr2);
                displaySquare("Red", arr3);
                displaySquare("Red", arr4);
            }
        }
        private void calCords1(int angle, float[] arr)
        {
            arr[0] = cX + r1 * (float)Math.Cos((225 + angle) * piRad);
            arr[1] = cY + r1 * (float)Math.Sin((225 + angle) * piRad);
            arr[2] = cX + r1 * (float)Math.Cos((315 + angle) * piRad);
            arr[3] = cY + r1 * (float)Math.Sin((315 + angle) * piRad);
            arr[4] = cX + r1 * (float)Math.Cos((45 + angle) * piRad);
            arr[5] = cY + r1 * (float)Math.Sin((45 + angle) * piRad);
            arr[6] = cX + r1 * (float)Math.Cos((135 + angle) * piRad);
            arr[7] = cY + r1 * (float)Math.Sin((135 + angle) * piRad);
        }
        private void calCords2(int sqNo, int i, int angle, float[] arr0, float[] arr1)
        {
            arr1[0] = arr0[i] + r2 * (float)Math.Cos((225 - angle) * piRad);
            arr1[1] = arr0[i + 1] + r2 * (float)Math.Sin((225 - angle) * piRad);
            arr1[2] = arr0[i] + r2 * (float)Math.Cos((315 - angle) * piRad);
            arr1[3] = arr0[i + 1] + r2 * (float)Math.Sin((315 - angle) * piRad);
            arr1[4] = arr0[i] + r2 * (float)Math.Cos((45 - angle) * piRad);
            arr1[5] = arr0[i + 1] + r2 * (float)Math.Sin((45 - angle) * piRad);
            arr1[6] = arr0[i] + r2 * (float)Math.Cos((135 - angle) * piRad);
            arr1[7] = arr0[i + 1] + r2 * (float)Math.Sin((135 - angle) * piRad);
        }

        private void thread()
        {
            cX = panel1.Width / 2;
            cY = panel1.Height / 2;

            float[] arr0 = { (cX / 2) + 50, (cY / 2) + 50, (cX * 3 / 2) - 50, (cY / 2) + 50, (cX * 3 / 2) - 50, (cY * 3 / 2) - 50, (cX / 2) + 50, (cY * 3 / 2) - 50 };
            float[] arr1 = { arr0[0] - 60, arr0[1] - 60, arr0[0] + 60, arr0[1] - 60, arr0[0] + 60, arr0[1] + 60, arr0[0] - 60, arr0[1] + 60 };
            float[] arr2 = { arr0[2] - 60, arr0[3] - 60, arr0[2] + 60, arr0[3] - 60, arr0[2] + 60, arr0[3] + 60, arr0[2] - 60, arr0[3] + 60 };
            float[] arr3 = { arr0[4] - 60, arr0[5] - 60, arr0[4] + 60, arr0[5] - 60, arr0[4] + 60, arr0[5] + 60, arr0[4] - 60, arr0[5] + 60 };
            float[] arr4 = { arr0[6] - 60, arr0[7] - 60, arr0[6] + 60, arr0[7] - 60, arr0[6] + 60, arr0[7] + 60, arr0[6] - 60, arr0[7] + 60 };
            displaySystem("Black", arr0, arr1, arr2, arr3, arr4);
            displaySystem("White", arr0, arr1, arr2, arr3, arr4);
            r1 = (float)Math.Sqrt(Math.Pow((cX - arr0[0]), 2) + Math.Pow((cY - arr0[1]), 2));
            r2 = (float)Math.Sqrt(Math.Pow((arr0[0] - arr1[0]), 2) + Math.Pow((arr0[1] - arr1[1]), 2));

            for (int i = 0; i < 1000; i++)
            {
                calCords1(i, arr0);
                calCords2(1, 0, i, arr0, arr1);
                calCords2(2, 2, i, arr0, arr2);
                calCords2(3, 4, i, arr0, arr3);
                calCords2(4, 6, i, arr0, arr4);

                displaySystem("Black", arr0, arr1, arr2, arr3, arr4);
                Task.Delay(15).Wait();
                displaySystem("White", arr0, arr1, arr2, arr3, arr4);

                i = (i + 1) % 360;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            System.Threading.Thread x = new System.Threading.Thread(thread);
            x.Start();
        }
    }
}