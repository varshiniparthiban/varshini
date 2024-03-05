using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ivi.Visa;
using Ivi.Visa.Interop;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace KeithleyDMM
{
    public partial class Form1 : Form
    {
        Ivi.Visa.Interop.ResourceManager resourcemanager = new Ivi.Visa.Interop.ResourceManager();
        FormattedIO488 ioObject = new FormattedIO488();
        string[] DCV = {":AUTO ON", " 100e-3", " 1", " 10", " 100", " 1000" };
        string[] ACV = {":AUTO ON", " 100e-3", " 1", " 10", " 100", " 750" };
        string[] DCI = {":AUTO ON", " 10e-6", " 100e-6", " 1e-3", " 10e-3", " 100e-3", " 1", " 3" };
        string[] ACI = {":AUTO ON", " 100e-6", " 1e-3", " 10e-3", " 100e-3", " 1", " 3" };
        string[] RES = {":AUTO ON", " 10", " 100", " 1e3", " 10e3", " 100e3", " 1e6", " 10e6", " 100e6" };
        string[] CAP = {":AUTO ON", " 1e-9", " 10e-9", " 100e-9", " 1e-6", " 10e-6", " 100e-6" };
        string visaAddress = "USB0::0x05E6::0x6500::04499434::INSTR";

        string param = "";
        string range = "";
        string result = "";
        string unit = "";
        public Form1()
        {
            InitializeComponent();
            mRangePanel.Visible = false;
            ioObject.IO = (Ivi.Visa.Interop.IMessage)resourcemanager.Open(visaAddress, AccessMode.NO_LOCK, 1000, "");
            ioObject.IO.Timeout = 10000;
        }
        public void getBuffer()
        {
            ioObject.WriteString("*RST");
            Thread.Sleep(100);
            ioObject.WriteString(":TRACe:CLEar \"defbuffer1\"");
            ioObject.WriteString(":TRACe:FILL:MODE CONT, \"defbuffer1\"");
        }
        private void getCommand()
        {
            try
            {
                ioObject.IO = (Ivi.Visa.Interop.IMessage)resourcemanager.Open(visaAddress, AccessMode.NO_LOCK, 1000, "");
                ioObject.IO.Timeout = 10000;
                ioObject.WriteString("*RST");
                ioObject.WriteString(":SENS:FUNC \"" + param + "\"");
                if (!range.Equals(""))
                    ioObject.WriteString(":SENS:" + param + ":RANG" + range);
                Thread.Sleep(150);
                ioObject.WriteString("READ?");
                result = ioObject.ReadString();
                ioObject.IO.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DataTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Read measurement result
                getCommand();
                mOutputLabel.Text = float.Parse(result) * 1e0 + unit;
                double measurementResult = Convert.ToDouble(result);
                DiaChart.Series[0].Points.AddY(measurementResult);

                // Limit the number of points on the chart (adjust as needed)
                if (DiaChart.Series[0].Points.Count > 50)
                {
                    DiaChart.Series[0].Points.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading from DMM: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getCommand();
            DiaChart.Series[0].Points.Clear();
            mOutputLabel.Text = float.Parse(result) * 1e0 + unit;
            System.Windows.Forms.Timer dataTimer = new System.Windows.Forms.Timer();
            dataTimer.Interval = 100; // Update every 1 second (adjust as needed)
            dataTimer.Tick += DataTimer_Tick;
            dataTimer.Start();
        }      

        private void DCVBtn_Click(object sender, EventArgs e)
        {
            mRangeComboBox.Items.Clear();
            for(int i=0;i<DCV.Length;i++)
                mRangeComboBox.Items.Add(DCV[i]);
            mRangePanel.Visible = true;
            param = "VOLT:DC";
            unit = " V";
           
        }

        private void DCIBtn_Click(object sender, EventArgs e)
        {
            mRangeComboBox.Items.Clear();
            for (int i = 0; i < DCI.Length; i++)
                mRangeComboBox.Items.Add(DCI[i]);
            mRangePanel.Visible = true;
            param = "CURR:DC";
            unit = " A";
        }

        private void ResistanceBtn_Click(object sender, EventArgs e)
        {
            mRangeComboBox.Items.Clear();
            for (int i = 0; i < RES.Length; i++)
                mRangeComboBox.Items.Add(RES[i]);
            mRangePanel.Visible = true;
            param = "RES";
            unit = " Ω";
        }

        private void ACVBtn_Click(object sender, EventArgs e)
        {
            mRangeComboBox.Items.Clear();
            for (int i = 0; i < ACV.Length; i++)
                mRangeComboBox.Items.Add(ACV[i]);
            mRangePanel.Visible = true;
            param = "VOLT:AC";
            unit = " V";
        }

        private void ACIBtn_Click(object sender, EventArgs e)
        {
            mRangeComboBox.Items.Clear();
            for (int i = 0; i < ACI.Length; i++)
                mRangeComboBox.Items.Add(ACI[i]);
            mRangePanel.Visible = true;
            param = "CURR:AC";
            unit = " A";
        }

        private void CapacitanceBtn_Click(object sender, EventArgs e)
        {

            mRangeComboBox.Items.Clear();
            for (int i = 0; i < CAP.Length; i++)
                mRangeComboBox.Items.Add(CAP[i]);
            mRangePanel.Visible = true;
            param = "CAP";
            unit = " F";
        }

        private void DiodeBtn_Click(object sender, EventArgs e)
        {
            mRangePanel.Visible = false;
            param = "DIOD";
            range = "";
            unit = " V";
        }

        private void mRangeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            range = mRangeComboBox.SelectedItem.ToString();
        }

        private void DiaChart_Click(object sender, EventArgs e)
        {

        }

        private void mRangePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void digiVBtn_Click(object sender, EventArgs e)
        {
            getBuffer();
            
            //ioObject.WriteString("*RST");
            ioObject.WriteString(":SENSe:DIGitize:FUNCtion \"VOLT\"");
            ioObject.WriteString(":SENSe:DIGitize:VOLTage:SRATe "+SampletxtBox.Text);
            ioObject.WriteString(":DIG:VOLT:ATR:MODE EDGE");
            ioObject.WriteString(":DIG:VOLT:ATR:EDGE:LEV 0.5");
            ioObject.WriteString(":TRACe:POINts ,"+CounttxtBox.Text + "\"defbuffer1\"");
            ioObject.WriteString(":TRIGger:LOAD \"LoopUntilEvent\", ATRigger, 25, ENTer, 0, \"defbuffer1\"");
            ioObject.WriteString(":DISPlay:SCReen GRAPh");
            ioObject.WriteString("*WAI");
            ioObject.WriteString(":INIT");
            Thread.Sleep(int.Parse(SampletxtBox.Text) + int.Parse(CounttxtBox.Text) + 50);
            ioObject.WriteString(":TRACe:DATA? 1, " + CounttxtBox.Text);
            result = ioObject.ReadString();
            double[] value = result.Split(',').Select(Double.Parse).ToArray();
            DiaChart.Series[0].Points.Clear();
            DiaChart.Series[0].Points.DataBindY(value);
        }

        private void digiIBtn_Click(object sender, EventArgs e)
        {
            getBuffer();

            //ioObject.WriteString("*RST");
            ioObject.WriteString(":SENSe:DIGitize:FUNCtion \"CURR\"");
            ioObject.WriteString(":SENSe:DIGitize:CURRent:SRATe " + SampletxtBox.Text);
            ioObject.WriteString(":DIG:CURR:ATR:MODE EDGE");
            ioObject.WriteString(":DIG:CURR:ATR:EDGE:LEV 0.5");
            ioObject.WriteString(":TRACe:POINts ," + CounttxtBox.Text + "\"defbuffer1\"");
            ioObject.WriteString(":TRIGger:LOAD \"LoopUntilEvent\", ATRigger, 25, ENTer, 0, \"defbuffer1\"");
            ioObject.WriteString(":DISPlay:SCReen GRAPh");
            ioObject.WriteString("*WAI");
            ioObject.WriteString(":INIT");
            Thread.Sleep(int.Parse(SampletxtBox.Text) + int.Parse(CounttxtBox.Text) + 50);
            ioObject.WriteString(":TRACe:DATA? 1, " + CounttxtBox.Text);
            result = ioObject.ReadString();
            double[] value = result.Split(',').Select(Double.Parse).ToArray();
            DiaChart.Series[0].Points.Clear();
            DiaChart.Series[0].Points.DataBindY(value);
        }
    }
}
