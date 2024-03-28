using Ivi.Visa.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMMKeySight
{
	public partial class Form1 : Form
	{
		#region Objects and Variables

		ResourceManager visaResourceManager = new ResourceManager();
		FormattedIO488 visaSession = new FormattedIO488();
		string visaAddress = "USB0::0x2A8D::0x8E01::CN62390086::INSTR";
        List<double> acquiredData = new List<double>();
        bool acquisitionInProgress = false;
        int sampleCount;
        int sampleInterval;
        double range = double.Parse("100");
        const string resolution = "FAST";
        KeysightDMMDriver mKeysightDMMDriver = new KeysightDMMDriver();    
        Thread acquisitionThread;


        #endregion

        #region Constructors
        public Form1()
		{

			InitializeComponent();

			string response=mKeysightDMMDriver.Connect(visaAddress);

			mInfoLabel.Text = "Instrument Identification: " + response;
		}

		#endregion

		#region DC Voltage
		private void mDCVoltageBtn_Click(object sender, EventArgs e)
		{
            double desiredRange = double.Parse(mRangeDropdown.SelectedItem.ToString().Split(' ')[0]);
            string desiredResolution = mResolutionDropdown.SelectedItem.ToString();
            double voltage=mKeysightDMMDriver.ReadDCVoltage(desiredRange, desiredResolution);

            mValueRichTextBox.Text = $"Voltage: {voltage} V";
		}

		#endregion

		#region AC Voltage
		private void mACVoltageBtn_Click(object sender, EventArgs e)
		{
            double desiredRange = double.Parse(mRangeDropdown.SelectedItem.ToString().Split(' ')[0]);
            string desiredResolution = mResolutionDropdown.SelectedItem.ToString();
            double voltage = mKeysightDMMDriver.ReadACVoltage(desiredRange, desiredResolution);
            mValueRichTextBox.Text = $"Voltage: {voltage} V";
		}

		#endregion

		#region Resistance
		private void mOhmBtn_Click(object sender, EventArgs e)
		{

            double desiredRange = double.Parse(mOhmRangeDropdown.SelectedItem.ToString().Split(' ')[0]);
            if (mOhmRangeDropdown.Text.Split(' ')[1].Length > 1)
            {
                if (mOhmRangeDropdown.Text.Split(' ')[1][0] == 'k')
                {
                    desiredRange *= 1000;
                }
                else
                {
                    desiredRange *= 1000000;
                }
            }

            string desiredResolution = mResolutionDropdown.SelectedItem.ToString();
            double resistance=mKeysightDMMDriver.SetDMMResistance(desiredRange, desiredResolution);
            mValueRichTextBox.Text = $"Resistance: {resistance} Ω";
		}

		#endregion

		#region DC Current

		private void mDCCurrentBtn_Click(object sender, EventArgs e)
		{
			
            double desiredRange = double.Parse(mDCIRangeDropdown.SelectedItem.ToString().Split(' ')[0]);

            string desiredResolution = mResolutionDropdown.SelectedItem.ToString();
            double current=mKeysightDMMDriver.ReadDCCurrent(desiredRange, desiredResolution);
            mValueRichTextBox.Text = $"Current: {current} A";
		}

		#endregion

		#region AC Current
		private void mACCurrentBtn_Click(object sender, EventArgs e)
		{
            double desiredRange = double.Parse(mDCIRangeDropdown.SelectedItem.ToString().Split(' ')[0]);

            string desiredResolution = mResolutionDropdown.SelectedItem.ToString();
            

 
            double current=mKeysightDMMDriver.ReadACCurrent(desiredRange, desiredResolution);

            mValueRichTextBox.Text = $"Current: {current} A";
        }

        #endregion

        #region Continuity

        private void mContinuityBtn_Click(object sender, EventArgs e)
        {
             double desiredRange = double.Parse(mRangeDropdown.SelectedItem.ToString().Split(' ')[0]);
            string desiredResolution = mResolutionDropdown.SelectedItem.ToString();
            bool continuity =mKeysightDMMDriver.ReadContinuity(desiredRange,desiredResolution);

            mValueRichTextBox.Text = $"Continuity: {(continuity ? "Open" : "Closed")}";
        }
        #endregion

        #region Frequency
        private void mFrequencyBtn_Click(object sender, EventArgs e)
        {
            double frequency = mKeysightDMMDriver.ReadFrequency();

            mValueRichTextBox.Text = $"Frequency: {frequency} Hz";
        }


        #endregion

        #region Temperature
        private void mTemperatureBtn_Click(object sender, EventArgs e)

        {
            double temperature = mKeysightDMMDriver.ReadTemperature();

            mValueRichTextBox.Text = $"Temperature: {temperature} °C"; 
        }

        #endregion


        #region Acquire

        private void mStartAcquisitionBtn_Click(object sender, EventArgs e)
        {
            if (!acquisitionInProgress)
            {
                acquiredData.Clear();

                sampleCount = int.Parse(mSampleCountNumericUpDown.Text);
                sampleInterval = int.Parse(mSampleIntervalNumericUpDown.Text);

                acquisitionInProgress = true;

                Thread acquisitionThread = new Thread(StartAcquiringData);
                acquisitionThread.Start();

            }
        }

        private void mStopAcquisitionBtn_Click(object sender, EventArgs e)
        {
            acquisitionInProgress = false;
        }

        private void mDisplayBtn_Click(object sender, EventArgs e)
        {
			mValueRichTextBox.Text = $"Acquired data: {string.Join("\n", acquiredData)}";
        }

        private void StartAcquiringData()
        {
            try
            {
                visaSession.WriteString("*CLS");                /*
                visaSession.WriteString("DATA:LOG MODE");
                MessageBox.Show("DLM");

                // Go to data log mode
                visaSession.WriteString("DATA:LOG MODE");

                // Set sample interval and sample count
                visaSession.WriteString("DATA:LOG:INTERVAL 0.1"); // Replace 0.1 with your desired interval
                visaSession.WriteString("DATA:LOG:COUNT 100"); // Replace 100 with your desired count

                // Turn on data logging
                visaSession.WriteString("DATA:LOG:STATE ON");

                // Press run/stop button for data acquisition
                visaSession.WriteString("DATA:LOG:RUN");

                // Read data from buffer
                string data = visaSession.ReadString();
                Console.WriteLine("Data read from buffer: " + data);*/

                visaSession.WriteString(":DATA:DELete NVMEM", true);
                visaSession.WriteString($":CONF:VOLT:DC {range},{resolution}", true);

                visaSession.WriteString(":TRIG:COUN 1", true);

                visaSession.WriteString(":SAMP:COUN 2", true);

                visaSession.WriteString(":SAMP:TIM 1;", true);


                visaSession.WriteString(":TRIG:SOUR IMM;", true);

               

                //visaSession.WriteString(":AUTO ON;",true);

                //visaSession.WriteString(":TRIG:SOUR IMM;", true);
                //visaSession.WriteString(":TRIG:SOUR BUS;", true);
                //visaSession.WriteString(":TRIG:SOUR EXT;", true);
                //visaSession.WriteString(":TRIG:SOUR INIT", true);

                //visaSession.WriteString(":TRIG:DEL:AUTO ON;", true);

                visaSession.WriteString("INIT;", true);
            



                Thread.Sleep(5000);
                visaSession.WriteString("DATA:DATA? NVMEM", true);
                string measurementResponse = visaSession.ReadString();
                
                SetLog(measurementResponse);


                //for (int i = 0; i < sampleCount && acquisitionInProgress; i++)
                //{
                //    visaSession.WriteString("FETC?", true);

                //    string measurementResponse = visaSession.ReadString();

                //    double measurementValue = ParseVoltageResponse(measurementResponse);
                //    acquiredData.Add(measurementValue);

                //    Thread.Sleep(sampleInterval);
                //}
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error during data acquisition: {ex.Message}");
            }

            finally
            {
                acquisitionInProgress = false;
            }
        }

        private void SetLog(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    SetLog(data);
                }));
            }
            else
            {
                mValueRichTextBox.Text = data;
            }
        }
        #endregion

        private void mSampleCountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
