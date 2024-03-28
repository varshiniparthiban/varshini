using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ivi.Visa.Interop;

namespace KeithleyDMM
{
    
    public class KeithleyDMMDriver : IKeithleyDMMDriver
    {
        #region Objects and Variables

        Ivi.Visa.Interop.ResourceManager Resourcemanager = new Ivi.Visa.Interop.ResourceManager();
        FormattedIO488 VisaRef = new FormattedIO488();
        double Result;
        string ReadValuesforDigitization;
        bool NeedToAbort;

        #endregion

        #region Helping Methods

        void GetBuffer()
        {
            VisaRef.WriteString("*RST");
            Thread.Sleep(100);
            VisaRef.WriteString(":TRACe:CLEar \"defbuffer1\"");
            VisaRef.WriteString(":TRACe:FILL:MODE CONT, \"defbuffer1\"");
        }
        public void Abort()
        {
            NeedToAbort = true;
        }

        #endregion

        #region Public Methods

        public void ConfigureReadACCurrent(double range, bool autoRange)
        {
            VisaRef.WriteString("*RST");
            VisaRef.WriteString(":SENS:FUNC \"CURR:AC\"");
            string command = ":SENS:CURR:AC:RANG";


            if (autoRange)
            {
                VisaRef.WriteString(command + ":AUTO ON");
            }
            else
            {
                VisaRef.WriteString(command + " " + range.ToString());
            }
        }

        public void ConfigureReadACVoltage(double range, bool autoRange)
        {
            VisaRef.WriteString("*RST");
            VisaRef.WriteString(":SENS:FUNC \"VOLT:AC\"");
            
            if (autoRange)
            {
                VisaRef.WriteString(":SENS:VOLT:AC:RANG:AUTO ON");
            }
            else
            {
               VisaRef.WriteString(":SENS:VOLT:AC:RANG " + range.ToString());
            }
        }

        public void ConfigureReadCapacitance(double range, bool autoRange)
        {
            VisaRef.WriteString("*RST");
            VisaRef.WriteString(":SENS:FUNC \"CAP\"");
            
            if (autoRange)
            {
                VisaRef.WriteString(":SENS:CAP:RANG:AUTO ON");
            }
            else
            {
                VisaRef.WriteString(":SENS:CAP:RANG " + range.ToString());

            }
        }

        public void ConfigureReadDCCurrent(double range, bool autoRange)
        {
            VisaRef.WriteString("*RST");
            VisaRef.WriteString(":SENS:FUNC \"CURR:DC\"");
            
            if (autoRange)
            {
                VisaRef.WriteString(":SENS:CURR:DC:RANG:AUTO ON");
            }
            else
            {
                VisaRef.WriteString(":SENS:CURR:DC:RANG " + range.ToString());
            }
        }

        public void ConfigureReadDCVoltage(double range, bool autoRange)
        {
            VisaRef.WriteString("*RST");
            VisaRef.WriteString(":SENS:FUNC \"VOLT:DC\"");
            
            if (autoRange)
            {
                VisaRef.WriteString(":SENS:VOLT:DC:RANG:AUTO ON");
            }
            else
            {
                VisaRef.WriteString(":SENS:VOLT:DC:RANG " + range.ToString());
            }
        }

        public void ConfigureReadDiode()
        {
            VisaRef.WriteString("*RST");
            VisaRef.WriteString(":SENS:FUNC \"DIOD\"");
        }

        public void ConfigureReadResistance(double range, bool autoRange)
        {
            VisaRef.WriteString("*RST");
            VisaRef.WriteString(":SENS:FUNC \"RES\"");
            
            if (autoRange)
            {
                VisaRef.WriteString(":SENS:RES:RANG:AUTO ON");
            }
            else
            {
                VisaRef.WriteString(":SENS:RES:RANG " + range.ToString());
            }
        }

        public void Connect(string visaAddress)
        {
            VisaRef.IO = (Ivi.Visa.Interop.IMessage)Resourcemanager.Open(visaAddress, AccessMode.NO_LOCK, 1000, "");
            VisaRef.IO.Timeout = 10000;
        }

        public void Disconnect()
        {
            VisaRef.IO.Close();
        }

        public double ReadACCurrent(double range, bool autoRange)
        {
            ConfigureReadACCurrent(range, autoRange);
            
            Thread.Sleep(150);
            VisaRef.WriteString("READ?");
            Result = Double.Parse(VisaRef.ReadString());
            return Result;
            
        }

        public double ReadACVoltage(double range, bool autoRange)
        {
            ConfigureReadACVoltage(range,autoRange);
            Thread.Sleep(150);
            VisaRef.WriteString("READ?");
            Result = Double.Parse(VisaRef.ReadString());
            return Result;
        }

        public double ReadCapacitance(double range, bool autoRange)
        {
            ConfigureReadCapacitance(range, autoRange);
            Thread.Sleep(150);
            VisaRef.WriteString("READ?");
            Result = Double.Parse(VisaRef.ReadString());
            return Result;
        }

        public double[] ReadCurrentWaveform(double samplingInterval, double numberOfSamplesToRead)
        {
            GetBuffer();

            //ioObject.WriteString("*RST");
            VisaRef.WriteString(":SENSe:DIGitize:FUNCtion \"CURR\"");
            VisaRef.WriteString(":SENSe:DIGitize:CURRent:SRATe " + samplingInterval);
            VisaRef.WriteString(":DIG:CURR:ATR:MODE EDGE");
            VisaRef.WriteString(":DIG:CURR:ATR:EDGE:LEV 0.5");
            VisaRef.WriteString(":TRACe:POINts ," + numberOfSamplesToRead + "\"defbuffer1\"");
            VisaRef.WriteString(":TRIGger:LOAD \"LoopUntilEvent\", ATRigger, 25, ENTer, 0, \"defbuffer1\"");
            VisaRef.WriteString(":DISPlay:SCReen GRAPh");
            VisaRef.WriteString("*WAI");
            VisaRef.WriteString(":INIT");

            int milliSecondToWait = Convert.ToInt32(samplingInterval) + Convert.ToInt32(numberOfSamplesToRead);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (!NeedToAbort)
            {
                if (stopwatch.ElapsedMilliseconds > milliSecondToWait)
                    break;

                Thread.Sleep(50);
            }

            stopwatch.Stop();
            stopwatch = null;

            if (NeedToAbort)
                throw new Exception("Aborted!");

            Thread.Sleep(50);
            VisaRef.WriteString(":TRACe:DATA? 1, " + numberOfSamplesToRead);
            ReadValuesforDigitization = VisaRef.ReadString();
            double[] value = ReadValuesforDigitization.Split(',').Select(Double.Parse).ToArray();
            return value;
        }

        public double ReadDCCurrent(double range, bool autoRange)
        {
            ConfigureReadDCCurrent(range, autoRange);
            Thread.Sleep(150);
            VisaRef.WriteString("READ?");
            Result = Double.Parse(VisaRef.ReadString());
            return Result;
        }

        public double ReadDCVoltage(double range, bool autoRange)
        {
            ConfigureReadDCVoltage(range, autoRange);
            Thread.Sleep(150);
            VisaRef.WriteString("READ?");
            Result = Double.Parse(VisaRef.ReadString());
            return Result;
        }

        public double ReadDiode()
        {
            ConfigureReadDiode();
            Thread.Sleep(150);
            VisaRef.WriteString("READ?");
            Result = Double.Parse(VisaRef.ReadString());
            return Result;
        }

        public double ReadResistance(double range, bool autoRange)
        {
            ConfigureReadResistance(range, autoRange);
            Thread.Sleep(150);
            VisaRef.WriteString("READ?");
            Result = Double.Parse(VisaRef.ReadString());
            return Result;
        }

        public double[] ReadVoltageWaveform(double samplingInterval, double numberOfSamplesToRead)
        {
            NeedToAbort = false;

            GetBuffer();
            //ioObject.WriteString("*RST");
            VisaRef.WriteString(":SENSe:DIGitize:FUNCtion \"VOLT\"");
            VisaRef.WriteString(":SENSe:DIGitize:VOLTage:SRATe " + samplingInterval);
            VisaRef.WriteString(":DIG:VOLT:ATR:MODE EDGE");
            VisaRef.WriteString(":DIG:VOLT:ATR:EDGE:LEV 0.5");
            VisaRef.WriteString(":TRACe:POINts ," + numberOfSamplesToRead + "\"defbuffer1\"");
            VisaRef.WriteString(":TRIGger:LOAD \"LoopUntilEvent\", ATRigger, 25, ENTer, 0, \"defbuffer1\"");
            VisaRef.WriteString(":DISPlay:SCReen GRAPh");
            VisaRef.WriteString("*WAI");
            VisaRef.WriteString(":INIT");

            int milliSecondToWait = Convert.ToInt32(samplingInterval) + Convert.ToInt32(numberOfSamplesToRead);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (!NeedToAbort)
            {
                if (stopwatch.ElapsedMilliseconds > milliSecondToWait)
                    break;

                Thread.Sleep(50);
            }

            stopwatch.Stop();
            stopwatch = null;

            if (NeedToAbort)
                throw new Exception("Aborted!");

            Thread.Sleep(50);

            VisaRef.WriteString(":TRACe:DATA? 1, " + samplingInterval);
            ReadValuesforDigitization = VisaRef.ReadString();
            double[] value = ReadValuesforDigitization.Split(',').Select(Double.Parse).ToArray();
            return value;
        }

        

        #endregion
    }
}
