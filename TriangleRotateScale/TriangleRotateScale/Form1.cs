using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriangleRotateScale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private float[][] arr = new float[3][];
        private float[] center = new float[2];
        private static float RAD = (float)Math.PI / 180;

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
        private void displayTriangle(String s,float[][] arr)
        {
            for(int i = 0; i < 3; i++)
            {
                displayLine(s, arr[i % 3][0], arr[i % 3][1], arr[(i + 1) % 3][0], arr[(i + 1) % 3][1]);
            }
        }
        private void getRandomPoints(float[][] arr)
        {
            Random r = new Random();
            for(int i = 0; i < 3; i++)
            {
                arr[i][0] = r.Next(150, 350);
                arr[i][1] = r.Next(150, 350);
            }
            center[0] = (arr[0][0] + arr[1][0] + arr[2][0]) / 3;
            center[1] = (arr[0][1] + arr[1][1] + arr[2][1]) / 3;
        }

        private void Rotate(float[][] arr,int n)
        {
            float X=0, Y=0;
            for(int i = 0; i < 3; i++)
            {
                X = arr[i][0] - center[0];
                Y = arr[i][1] - center[1];
                arr[i][0] = (X * (float)Math.Cos(n * RAD)) - (Y * (float)Math.Sin(n * RAD)) + center[0];
                arr[i][1] = (X * (float)Math.Sin(n * RAD)) + (Y * (float)Math.Cos(n * RAD)) + center[1];
            }
        }
        private void scale(float[][] arr,double n)
        {
            float X = 0, Y = 0;
            for (int i = 0; i < 3; i++)
            {
                X = arr[i][0] - center[0];
                Y = arr[i][1] - center[1];
                arr[i][0] = (float)(n * X) + center[0];
                arr[i][1] = (float)(n * Y) + center[1];
            }
        }

        private void thread()
        {
            for (int i = 0; i < 3; i++)
            {
                arr[i] = new float[2];
            }
            getRandomPoints(arr);
            for(int i = 0; i >= 0; i++)
            {
                displayTriangle("Black", arr);
                Task.Delay(1).Wait();
                displayTriangle("White", arr);
                Rotate(arr, 1);
                if(i>=0 && i<360)
                {
                    scale(arr, 1.003);
                }
                else if(i>=360 && i < 720)
                {
                    scale(arr, 1/1.003);
                }
                i = i % 720;
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            System.Threading.Thread x = new System.Threading.Thread(thread);
            x.Start();
        }
    }
}
