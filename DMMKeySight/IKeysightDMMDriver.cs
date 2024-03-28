using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMKeySight
{
    public interface IKeysightDMMDriver
    {
        #region Configuration
        /// <summary>
        /// It will configure with the DC voltage of the Keysight DMM Connected with.
        /// </summary>
        /// <param name="desiredRange"></param>
        /// <param name="desiredResolution"></param>
        void ConfigureReadDCVoltage(double desiredRange, string desiredResolution);
        /// <summary>
        /// It will configure with the AC voltage of the Keysight DMM connected with.
        /// </summary>
        /// <param name="desiredRange"></param>
        /// <param name="desiredResolution"></param>

        void ConfigureReadACVoltage(double desiredRange, string desiredResolution);
        /// <summary>
        /// It will configure with the resistance of the Keysight DMM connected with.
        /// </summary>
        /// <param name="desiredRange"></param>
        /// <param name="desiredResolution"></param>

        void ConfigureSetDMMResistance(double desiredRange, string desiredResolution);
        /// <summary>
        /// It will configure with the DC current of the Keysight DMM connected with.
        /// </summary>
        /// <param name="desiredRange"></param>
        /// <param name="desiredResolution"></param>

        void ConfigureReadDCCurrent(double desiredRange, string desiredResolution);
        /// <summary>
        /// It will configure with the AC current of the keysight DMM connected with.
        /// </summary>
        /// <param name="desiredRange"></param>
        /// <param name="desiredResolution"></param>

        void ConfigureReadACCurrent(double desiredRange, string desiredResolution);
        /// <summary>
        /// It will configure with the continuity of the keysight DMM connected with.
        /// </summary>
        /// <param name="desiredRange"></param>
        /// <param name="desiredResolution"></param>
        void ConfigureReadContinuity(double desiredRange, string desiredResolution);
        /// <summary>
        /// It will configure with the Frequency of the Keysight DMM connected with.
        /// </summary>
        void ConfigureReadFrequency();
        /// <summary>
        /// It will configure with the Temperature mode of the Keysight DMM connected with.
        /// </summary>
        void ConfigureReadTemperature();
        #endregion
        #region ReadData
        /// <summary>
        /// It will read and return the DC voltage value from the keysight DMM connected with.
        /// </summary>
        /// <param name="desiredRange"></param>
        /// <param name="desiredResolution"></param>
        double ReadDCVoltage(double desiredRange, string desiredResolution);

        /// <summary>
        /// It will read and return the AC Voltage value from the keysight DMM connected with.
        /// </summary>
        /// <param name="desiredRange"></param>
        /// <param name="desiredResolution"></param>

        double ReadACVoltage(double desiredRange, string desiredResolution);

        /// <summary>
        /// It will read and return the resistance value from the keysight DMM connected with. 
        /// </summary>
        /// <param name="desiredRange"></param>
        /// <param name="desiredResolution"></param>
        double SetDMMResistance(double desiredRange, string desiredResolution);

        /// <summary>
        /// It will read and return the DC current value  from keysight DMM conected with.
        /// </summary>
        /// <param name="desiredRange"></param>
        /// <param name="desiredResolution"></param>
        double ReadDCCurrent(double desiredRange, string desiredResolution);

        /// <summary>
        /// It will read and return the AC current value from Keysight DMM connected with.
        /// </summary>
        /// <param name="desiredRange"></param>
        /// <param name="desiredResolution"></param>
        double ReadACCurrent(double desiredRange, string desiredResolution);

        /// <summary>
        /// It will read and return the Continuity value from Keysight DMM connected with.
        /// </summary>
        /// <param name="desiredRange"></param>
        /// <param name="desiredResolution"></param>
        bool ReadContinuity(double desiredRange, string desiredResolution);

        /// <summary>
        /// It will read and return the Frequency value from Keysight DMM connected with.
        /// </summary>
        double ReadFrequency();

        /// <summary>
        /// It will read and return the temperature value from Keysight DMM connected with.
        /// </summary>
        
        double ReadTemperature ();

        #endregion


        #region Connection Methods

        /// <summary>
        /// It will connect with Keysight DMM of the given Visa Address
        /// </summary>
        /// <param name="visaAddress"></param>
        string Connect(string visaAddress);

        /// <summary>
        /// It will disconnect with the Keysight DMM already connected with.
        /// </summary>
        void Disconnect();


        #endregion
    }
}
