using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        float x=0, tmp=0;
        char op='0';

        public void getTmp(float a, char c)
        {
            switch (c)
            {
                case '+':
                    tmp = a + float.Parse(txtBox.Text);
                    txtBox.Text = tmp.ToString();
                    break;
                case '-':
                    tmp = a - float.Parse(txtBox.Text);
                    txtBox.Text = tmp.ToString();
                    break;
                case '*':
                    tmp = a * float.Parse(txtBox.Text);
                    txtBox.Text = tmp.ToString();
                    break;
                case '/':
                    tmp = a / float.Parse(txtBox.Text);
                    txtBox.Text = tmp.ToString();
                    break;
            }
        }

        private void txtBox_TextChanged(object sender, EventArgs e) {}

        private void btnZero_Click_1(object sender, EventArgs e)
        {
            if (txtBox.Text != "0")
            {
                txtBox.Text = txtBox.Text + btnZero.Text;
            }
        }
        private void btnOne_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + btnOne.Text;
        }
        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + btnTwo.Text;
        }
        private void btnThree_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + btnThree.Text;
        }
        private void btnFour_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + btnFour.Text;
        }
        private void btnFive_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + btnFive.Text;
        }
        private void btnSix_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + btnSix.Text;
        }
        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + btnSeven.Text;
        }
        private void btnEight_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + btnEight.Text;
        }
        private void btnNine_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + btnNine.Text;
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + btnDot.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (op != '0')
            {
                getTmp(x, op);
            }
            x = float.Parse(txtBox.Text);
            op = '+';
            txtBox.Text = btnZero.Text.ToString();
        }
        private void btnSub_Click(object sender, EventArgs e)
        {
            if (op != '0')
            {
                getTmp(x, op);
            }
            x = float.Parse(txtBox.Text);
            op = '-';
            txtBox.Text = btnZero.Text.ToString();
        }
        private void btnMpy_Click(object sender, EventArgs e)
        {
            if (op != '0')
            {
                getTmp(x, op);
            }
            x = float.Parse(txtBox.Text);
            op = '*';
            txtBox.Text = btnZero.Text.ToString();
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (op != '0')
            {
                getTmp(x, op);
            }
            x = float.Parse(txtBox.Text);
            op = '/';
            txtBox.Text = btnZero.Text.ToString();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            getTmp(x, op);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBox.Text=null;
            tmp = 0;
            op = '0';
            x = 0;
        }
    }
}
