using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vesak_Triangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private float[] arr1 = new float[6];
        private float[] arr2 = new float[6];
        private float[] arr3 = new float[6];
        private float[] arr4 = new float[6];

        private static float RAD = (float)Math.PI / 180;

        private void displayLine(String s,float xS,float yS,float xE,float yE)
        {
            Graphics g = panel.CreateGraphics();
            if (s == "Black")
            {
                g.DrawLine(Pens.Black, xS, panel.Height - yS, xE, panel.Height - yE);
            }
            else if (s == "Red")
            {
                g.DrawLine(Pens.Red, xS, panel.Height - yS, xE, panel.Height - yE);
            }
            else
            {
                g.DrawLine(Pens.White, xS, panel.Height - yS, xE, panel.Height - yE);
            }
        }
        private void displayTriangle(String s,float[] arr)
        {
            if (s == "Black")
            {
                for(int i = 0; i < arr.Length; i = i + 2)
                {
                    displayLine("Black", arr[i % 6], arr[(i + 1) % 6], arr[(i + 2) % 6], arr[(i + 3) % 6]);
                }
            }
            else if (s == "Red")
            {
                for (int i = 0; i < arr.Length; i = i + 2)
                {
                    displayLine("Red", arr[i % 6], arr[(i + 1) % 6], arr[(i + 2) % 6], arr[(i + 3) % 6]);
                }
            }
            else
            {
                for (int i = 0; i < arr.Length; i = i + 2)
                {
                    displayLine("White", arr[i % 6], arr[(i + 1) % 6], arr[(i + 2) % 6], arr[(i + 3) % 6]);
                }
            }
        }
        private float[] createTrianglePoints(int r, float cX, float cY)
        {
            float[] arr = new float[6];
            float X = r * (float)Math.Cos(30 * RAD);
            float Y = r * (float)Math.Sin(30 * RAD);
            arr[0] = cX - X;
            arr[1] = cY - Y;
            arr[2] = cX + X;
            arr[3] = cY - Y;
            arr[4] = cX;
            arr[5] = cY + r;
            return arr;
        }
        private void rotatePoint(float[] arr,float cX,float cY,int i,int r)
        {
            arr[0] = cX + r * (float)Math.Cos((210 + i) * RAD);
            arr[1] = cY + r * (float)Math.Sin((210 + i) * RAD);
            arr[2] = cX + r * (float)Math.Cos((330 + i) * RAD);
            arr[3] = cY + r * (float)Math.Sin((330 + i) * RAD);
            arr[4] = cX + r * (float)Math.Cos((90 + i) * RAD);
            arr[5] = cY + r * (float)Math.Sin((90 + i) * RAD);
        }

        private void thread1()
        {
            float cX = panel.Width / 2;
            float cY = panel.Height / 2;
            arr1 = createTrianglePoints(120, cX, cY);
            displayTriangle("Black", arr1);
            for (int i = 0; i >= 0; i++)
            {
                displayTriangle("White", arr1);
                rotatePoint(arr1, cX, cY, i, 120);
                displayTriangle("Black", arr1);
                Task.Delay(10).Wait();
            }
        }
        private void thread2()
        {
            arr2 = createTrianglePoints(60, arr1[0], arr1[1]);
            for (int i = 0; i >= 0; i++)
            {
                displayTriangle("Red", arr2);
                Task.Delay(10).Wait();
                displayTriangle("White", arr2);
                rotatePoint(arr2, arr1[0], arr1[1], -i, 60);
            }
        }
        private void thread3()
        {
            arr3 = createTrianglePoints(60, arr1[2], arr1[3]);
            for (int i = 0; i >= 0; i++)
            {
                displayTriangle("Red", arr3);
                Task.Delay(10).Wait();
                displayTriangle("White", arr3);
                rotatePoint(arr3, arr1[2], arr1[3], -i, 60);
            }
        }
        private void thread4()
        {
            arr4 = createTrianglePoints(60, arr1[4], arr1[5]);
            for (int i = 0; i >= 0; i++)
            {
                displayTriangle("Red", arr4);
                Task.Delay(10).Wait();
                displayTriangle("White", arr4);
                rotatePoint(arr4, arr1[4], arr1[5], -i, 60);
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            System.Threading.Thread a = new System.Threading.Thread(thread1);
            System.Threading.Thread b = new System.Threading.Thread(thread2);
            System.Threading.Thread c = new System.Threading.Thread(thread3);
            System.Threading.Thread d = new System.Threading.Thread(thread4);
            a.Start();
            b.Start();
            c.Start();
            d.Start();
        }
    }
}
