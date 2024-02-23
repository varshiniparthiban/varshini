using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }
        double result;


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void lblcalculator_Click(object sender, EventArgs e)
        {

        }

        private void btnClickThis_Load(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + btn3.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + btn6.Text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + btn9.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + btn0.Text;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            
            txtTotal.Text = txtTotal.Text + "+";
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            
            txtTotal.Text = txtTotal.Text + "-";
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            
            txtTotal.Text = txtTotal.Text + "*";
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + "^";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            
            txtTotal.Text = txtTotal.Text + "/";
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            
           
            txtTotal.Text = txtTotal.Text + "%";
        }

        private void btnEql_Click(object sender, EventArgs e)
        {
            

            Calculator c = new Calculator();
            result = c.Calculate(txtTotal.Text);
            txtTotal.Text = result+" ";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTotal.Clear();
            result = (0);
            
        }
    }
}
