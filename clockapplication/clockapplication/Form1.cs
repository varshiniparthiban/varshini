using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace clockapplication
{
    public partial class Form1 : Form
    {
        private Thread clockThread;
        private bool running = true;
        public Form1()
        {
            InitializeComponent();
            clockThread = new Thread(UpdateClock);
            clockThread.Start();
            //UpdateClock();
        }
        private void UpdateClock()
        {
            while (running)
            {
                string currentTime = DateTime.Now.ToString("HH:mm:ss");
                UpdateClockLabel(currentTime);
                Thread.Sleep(1000); // Update every second
            }
        }
        private void UpdateClockLabel(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { UpdateClockLabel(text); }));
            }
            else
            {
                label1.Text = text;
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                running = true;
                clockThread = new Thread(UpdateClock);
                clockThread.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            running = false;
            clockThread.Join();
        }
    }
}
