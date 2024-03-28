using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeithleyDMM
{
    public interface IKeithleyDMMDriver
    {
        #region Connection Methods
        /// <summary>
        /// It will establish connection with the Keithley DMM.
        /// </summary>
        void Connect(string visaAddress);
        /// <summary>
        /// It will disconnect with the Keithley DMM.
        /// </summary>
        void Disconnect();

        #endregion

        #region Configuration Methods

        /// <summary>
        /// It will configure with the DC Voltage of the Keithley DMM connected with.
        /// </summary>
        /// <param name="range"></param>
        void ConfigureReadDCVoltage(double  range, bool autoRange);

        /// <summary>
        /// It will configure with the ACVoltage of the Keithley DMM connected with.
        /// </summary>
        /// <param name="range"></param>
        void ConfigureReadACVoltage(double range, bool autoRange);
        /// <summary>
        /// It will configure with the  DC current of the Keithley DMM Connected with.
        /// </summary>
        /// <param name="range"></param>
        void ConfigureReadDCCurrent(double range, bool autoRange);
        /// <summary>
        /// It will configure with the AC current of the Keithley DMM connected with.
        /// </summary>
        /// <param name="range"></param>
        void ConfigureReadACCurrent(double range, bool autoRange);
        /// <summary>
        /// It will configure with the Resistance of the Keithley DMM connected with.
        /// </summary>
        /// <param name="range"></param>
        void ConfigureReadResistance(double range, bool autoOn);
        /// <summary>
        /// It will configure with the Capacitance of the Keithley DMM connected with.
        /// </summary>
        /// <param name="range"></param>
        void ConfigureReadCapacitance(double range, bool autoRange);
        /// <summary>
        /// It will configure with the Diode of the Keithley DMM connected with.
        /// </summary>
        void ConfigureReadDiode();

        #endregion

        #region ReadData
        /// <summary>
        /// It will return the value from the DCVoltage of the Keithley DMM connected with.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        double ReadDCVoltage(double range, bool autoRange);
        /// <summary>
        /// It will return the value from the ACVoltage of the Keithley DMM connected with.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        double ReadACVoltage(double range, bool autoRange);
        /// <summary>
        /// It will return the value from the DCCurrent of the Keithley DMM connected with.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        double ReadDCCurrent(double range, bool autoRange);
        /// <summary>
        /// It will return the value from the AC current of the Keithley DMM connected with.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        double ReadACCurrent(double range, bool autoRange);
        /// <summary>
        /// It will return the value from the Resistance of the Keithley DMM connected with.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        double ReadResistance(double range, bool autoRange);
        /// <summary>
        /// It will return the value from the Capacitance of the keithley DMM connected with.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        double ReadCapacitance(double range, bool autoRange);
        /// <summary>
        /// It will return the diode value from the /keithley DMM connected with.
        /// </summary>
        /// <returns></returns>
        double ReadDiode();

        /// <summary>
        /// It will return the array of digitized voltage values from the Keithley DMM connected with.
        /// </summary>
        /// <param name="samplingInterval"></param>
        /// <param name="numberOfSamplesToRead"></param>
        /// <returns></returns>
        double[] ReadVoltageWaveform(double samplingInterval, double numberOfSamplesToRead);
        /// <summary>
        /// It will return the array of digitized Current values from the Keithley DMM connected with.
        /// </summary>
        /// <param name="samplingInterval"></param>
        /// <param name="numberOfSamplesToRead"></param>
        /// <returns></returns>
        double[] ReadCurrentWaveform(double samplingInterval, double numberOfSamplesToRead);

        #endregion
        #region Digitization Abort
        void Abort();
        #endregion
    }
}
