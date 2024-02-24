using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customEvents
{
    public partial class Form1 : Form
    {
        public delegate string CustomEventHandler(object sender, string str1);
        public static event CustomEventHandler CustomEvent1;

        public Form1()
        {
            InitializeComponent();
            CustomEvent customevent = new CustomEvent();
           
        }
        

        public void OnCustomEvent1(string str1)
        {
            string str = CustomEvent1?.Invoke(this, str1);
         
            MessageBox.Show(str);
        }
        

        

        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void log_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (txt1.Text == "Varshini" && txt2.Text == "Varshini@123")
            {
                OnCustomEvent1("Welcome varshini! you have logged in Successfully");
            }
            else
            {
                OnCustomEvent1("Invalid user sign in again");
            }
        }
    }
}
