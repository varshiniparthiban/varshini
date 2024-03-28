using Ivi.Visa.Interop;
using System;

namespace DMMKeySight
{
    public class KeysightDMMDriver : IKeysightDMMDriver
    {
        ResourceManager visaResourceManager = new ResourceManager();
        FormattedIO488 visaSession = new FormattedIO488();
        public double ReadACCurrent(double desiredRange, string desiredResolution)
        {
            ConfigureReadACCurrent(desiredRange, desiredResolution);
            //visaSession.WriteString($"CONF:CURR:AC {desiredRange},{desiredResolution}", true);
            visaSession.WriteString("READ?", true);
            string measurementResponse = visaSession.ReadString();
            double accurrent = ParseResistanceResponse(measurementResponse);
            return accurrent;
        }

        public double  ReadACVoltage(double desiredRange, string desiredResolution)
        {
            ConfigureReadACVoltage(desiredRange, desiredResolution);
            //visaSession.WriteString($"CONF:VOLT:AC {desiredRange},{desiredResolution}", true);
            visaSession.WriteString("READ?", true);
            string measurementResponse = visaSession.ReadString();

            double voltage = ParseVoltageResponse(measurementResponse);
            return voltage;
        }

        public bool ReadContinuity(double desiredRange, string desiredResolution)
        {
            ConfigureReadContinuity(desiredRange, desiredResolution);
            //visaSession.WriteString($"CONF:CONT {desiredRange},{desiredResolution}", true);
            visaSession.WriteString("READ?", true);
            string measurementResponse = visaSession.ReadString();

            bool continuity = ParseContinuityResponse(measurementResponse);
            return continuity;
        }

        public double ReadDCCurrent(double desiredRange, string desiredResolution)
        {
            ConfigureReadDCCurrent(desiredRange, desiredResolution);
            //visaSession.WriteString($"CONF:CURR:DC {desiredRange},{desiredResolution}", true);
            visaSession.WriteString("READ?", true);
            string measurementResponse = visaSession.ReadString();
            double dccurrent = ParseResistanceResponse(measurementResponse);
            return dccurrent;
        }

        public double ReadDCVoltage(double desiredRange, string desiredResolution)
        {
            ConfigureReadDCVoltage(desiredRange, desiredResolution);
            //visaSession.WriteString($"CONF:VOLT:DC {desiredRange},{desiredResolution}", true);
            visaSession.WriteString("READ?", true);
            string measurementResponse = visaSession.ReadString();
            double dcvoltage = ParseResistanceResponse(measurementResponse);
            return dcvoltage;
        }

        public double ReadFrequency()
        {
            ConfigureReadFrequency();
            //visaSession.WriteString("CONF:FREQ", true);
            visaSession.WriteString("READ?", true);
            string measurementResponse = visaSession.ReadString();

            double frequency = ParseFrequencyResponse(measurementResponse);
            return frequency;
        }

        private bool ParseContinuityResponse(string response)
        {
            return response.Trim() == "1";
        }

        private double ParseFrequencyResponse(string response)
        {
            if (double.TryParse(response, out double frequency))
            {
                return frequency;
            }
            else
            {
                throw new Exception("Failed to parse frequency response");
            }
        }

        private double ParseCurrentResponse(string response)
        {
            if (double.TryParse(response, out double current))
            {
                return current;
            }
            else
            {
                throw new Exception("Failed to parse current response");
            }
        }

        private double ParseResistanceResponse(string response)
        {
            if (double.TryParse(response, out double resistance))
            {
                return resistance;
            }
            else
            {
                throw new Exception("Failed to parse resistance response");
            }
        }

        private double ParseTemperatureResponse(string response)
        {
            if (double.TryParse(response, out double temperature))
            {
                return temperature;
            }
            else
            {
                throw new Exception("Failed to parse temperature response");
            }
        }

        private double ParseVoltageResponse(string response)
        {

            if (double.TryParse(response, out double voltage))
            {
                return voltage;
            }
            else
            {
                throw new Exception("Failed to parse voltage response");
            }
        }

        public double SetDMMResistance(double desiredRange, string desiredResolution)
        {
            ConfigureSetDMMResistance(desiredRange, desiredResolution);
            //visaSession.WriteString($"CONF:RES {desiredRange},{desiredResolution}", true);
            visaSession.WriteString("READ?", true);
            string measurementResponse = visaSession.ReadString();
            double resistance = ParseResistanceResponse(measurementResponse);
            return resistance;
        }

        

        public string Connect(string visaAddress)
        {
            visaSession.IO = (IMessage)visaResourceManager.Open(visaAddress, AccessMode.NO_LOCK, 0, "");
            visaSession.IO.Timeout = 10000;
            visaSession.WriteString("*IDN?;", true);
            string response = visaSession.ReadString();
            return response;
        }

       

        public double ReadTemperature()
        {
            ConfigureReadTemperature();
            //visaSession.WriteString("FUNC:TEMP", true);
            visaSession.WriteString("READ?", true);
            string measurementResponse = visaSession.ReadString();

            double temperature = ParseTemperatureResponse(measurementResponse);
            return temperature;
        }
        public void Disconnect()
        {
            visaSession.IO.Close();
        }

        public void ConfigureReadDCVoltage(double desiredRange, string desiredResolution)
        {
            visaSession.WriteString($"CONF:VOLT:DC {desiredRange},{desiredResolution}", true);
        }

        public void ConfigureReadACVoltage(double desiredRange, string desiredResolution)
        {
            visaSession.WriteString($"CONF:VOLT:AC {desiredRange},{desiredResolution}", true);
        }

        public void ConfigureSetDMMResistance(double desiredRange, string desiredResolution)
        {
            visaSession.WriteString($"CONF:RES {desiredRange},{desiredResolution}", true);
        }

        public void ConfigureReadDCCurrent(double desiredRange, string desiredResolution)
        {
            visaSession.WriteString($"CONF:CURR:DC {desiredRange},{desiredResolution}", true);
        }

        public void ConfigureReadACCurrent(double desiredRange, string desiredResolution)
        {
            visaSession.WriteString($"CONF:CURR:AC {desiredRange},{desiredResolution}", true);
        }

        public void ConfigureReadContinuity(double desiredRange, string desiredResolution)
        {
            visaSession.WriteString($"CONF:CONT {desiredRange},{desiredResolution}", true);
        }

        public void ConfigureReadFrequency()
        {
            visaSession.WriteString("CONF:FREQ", true);
        }

        public void ConfigureReadTemperature()
        {
            visaSession.WriteString("FUNC:TEMP", true);
        }
    }
}
