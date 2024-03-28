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
        KeithleyDMMDriver mKeithleyDMMDriver = new KeithleyDMMDriver();
        string[] DCV = {":AUTO ON", " 100e-3", " 1", " 10", " 100", " 1000" };
        string[] ACV = {":AUTO ON", " 100e-3", " 1", " 10", " 100", " 750" };
        string[] DCI = {":AUTO ON", " 10e-6", " 100e-6", " 1e-3", " 10e-3", " 100e-3", " 1", " 3" };
        string[] ACI = {":AUTO ON", " 100e-6", " 1e-3", " 10e-3", " 100e-3", " 1", " 3" };
        string[] RES = {":AUTO ON", " 10", " 100", " 1e3", " 10e3", " 100e3", " 1e6", " 10e6", " 100e6" };
        string[] CAP = {":AUTO ON", " 1e-9", " 10e-9", " 100e-9", " 1e-6", " 10e-6", " 100e-6" };
        string visaAddress = "USB0::0x05E6::0x6500::04499434::INSTR";

        string param = "";
        double range;
        bool flag = false;
        string result = "";
        string unit = "";
        public Form1()
        {
            InitializeComponent();
            mRangePanel.Visible = false;
            /*ioObject.IO = (Ivi.Visa.Interop.IMessage)resourcemanager.Open(visaAddress, AccessMode.NO_LOCK, 1000, "");
            ioObject.IO.Timeout = 10000;*/
            mKeithleyDMMDriver.Connect(visaAddress);

        }
        /*public void getBuffer()
        {
            ioObject.WriteString("*RST");
            Thread.Sleep(100);
            ioObject.WriteString(":TRACe:CLEar \"defbuffer1\"");
            ioObject.WriteString(":TRACe:FILL:MODE CONT, \"defbuffer1\"");
        }*/
        /*private void getCommand()
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
        }*/
        private void DataTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // config
                // Read measurement result
                
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
            //config
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
            try
            {
                mKeithleyDMMDriver.Connect(visaAddress);
                if(mRangeComboBox.SelectedIndex.ToString().Equals(":AUTO ON")==true){
                    result = mKeithleyDMMDriver.ReadDCVoltage(0, true).ToString();
                }
                else
                {
                    
                    result = mKeithleyDMMDriver.ReadDCVoltage(range, false).ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            unit = " V";
           
        }

        private void DCIBtn_Click(object sender, EventArgs e)
        {
            mRangeComboBox.Items.Clear();
            for (int i = 0; i < DCI.Length; i++)
                mRangeComboBox.Items.Add(DCI[i]);
            mRangePanel.Visible = true;
            try
            {
                mKeithleyDMMDriver.Connect(visaAddress);
                if (mRangeComboBox.SelectedIndex.ToString().Equals(":AUTO ON")==true){
                    result = mKeithleyDMMDriver.ReadDCCurrent(0, true).ToString();
                }
                else
                {
                    //range = Double.Parse(mRangeComboBox.SelectedItem.ToString());
                    result = mKeithleyDMMDriver.ReadDCCurrent(range, false).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            unit = " A";
        }

        private void ResistanceBtn_Click(object sender, EventArgs e)
        {
            mRangeComboBox.Items.Clear();
            for (int i = 0; i < RES.Length; i++)
                mRangeComboBox.Items.Add(RES[i]);
            mRangePanel.Visible = true;
            try
            {
                mKeithleyDMMDriver.Connect(visaAddress);
                if (mRangeComboBox.SelectedIndex.ToString().Equals(":AUTO ON") == true){
                    result = mKeithleyDMMDriver.ReadResistance(0, true).ToString();
                }
                else
                {
                    //range = Double.Parse(mRangeComboBox.SelectedItem.ToString());
                    result = mKeithleyDMMDriver.ReadResistance(range, false).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            unit = " Ω";
        }

        private void ACVBtn_Click(object sender, EventArgs e)
        {
            mRangeComboBox.Items.Clear();
            for (int i = 0; i < ACV.Length; i++)
                mRangeComboBox.Items.Add(ACV[i]);
            mRangePanel.Visible = true;
            try
            {
                mKeithleyDMMDriver.Connect(visaAddress);
                if (mRangeComboBox.SelectedIndex.ToString().Equals(":AUTO ON") == true){
                    result = mKeithleyDMMDriver.ReadACVoltage(0, true).ToString();
                }
                else
                {
                    //range = Double.Parse(mRangeComboBox.SelectedItem.ToString());
                    result = mKeithleyDMMDriver.ReadACVoltage(range, false).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            unit = " V";
        }

        private void ACIBtn_Click(object sender, EventArgs e)
        {
            mRangeComboBox.Items.Clear();
            for (int i = 0; i < ACI.Length; i++)
                mRangeComboBox.Items.Add(ACI[i]);
            mRangePanel.Visible = true;
            try
            {
                mKeithleyDMMDriver.Connect(visaAddress);
                if (mRangeComboBox.SelectedIndex.ToString().Equals(":AUTO ON")==true){
                    result = mKeithleyDMMDriver.ReadACCurrent(0, true).ToString();
                }
                else
                {
                    //range = Double.Parse(mRangeComboBox.SelectedItem.ToString());
                    result = mKeithleyDMMDriver.ReadACCurrent(range, false).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            unit = " A";
        }

        private void CapacitanceBtn_Click(object sender, EventArgs e)
        {

            mRangeComboBox.Items.Clear();
            for (int i = 0; i < CAP.Length; i++)
                mRangeComboBox.Items.Add(CAP[i]);
            mRangePanel.Visible = true;
            try
            {
                mKeithleyDMMDriver.Connect(visaAddress);
                if (flag)
                {
                    result = mKeithleyDMMDriver.ReadCapacitance(0, true).ToString();
                }
                else {
                    //range = Double.Parse(mRangeComboBox.SelectedItem.ToString());
                    result = mKeithleyDMMDriver.ReadCapacitance(range, false).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            unit = " F";
        }

        private void DiodeBtn_Click(object sender, EventArgs e)
        {
            mRangePanel.Visible = false;
            try
            {
                mKeithleyDMMDriver.Connect(visaAddress);
                result = mKeithleyDMMDriver.ReadDiode().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            unit = " V";
        }

        private void mRangeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mRangeComboBox.SelectedItem.ToString().Equals(":AUTO ON") == false)
            {
                //MessageBox.Show("Auto On Not Selected");
                range = Double.Parse(mRangeComboBox.SelectedItem.ToString());
                flag = false;
            }
            else
            {
                flag = true;
            }
            


        }

        private void DiaChart_Click(object sender, EventArgs e)
        {

        }

        private void mRangePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void digiVBtn_Click(object sender, EventArgs e)
        {
            
            double sample=Double.Parse(SampletxtBox.Text);
            double count=Double.Parse(CounttxtBox.Text);
            double[] value = mKeithleyDMMDriver.ReadVoltageWaveform(sample, count);
            DiaChart.Series[0].Points.Clear();
            DiaChart.Series[0].Points.DataBindY(value);
        }

        private void digiIBtn_Click(object sender, EventArgs e)
        {
            double sample = Double.Parse(SampletxtBox.Text);
            double count = Double.Parse(CounttxtBox.Text);
            double[] value = mKeithleyDMMDriver.ReadCurrentWaveform(sample, count);
            DiaChart.Series[0].Points.Clear();
            DiaChart.Series[0].Points.DataBindY(value);
        }

        private void mOutputLabel_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            mKeithleyDMMDriver.Abort();
        }
    }
}
