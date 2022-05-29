using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProiectOOP
{
    public delegate void onNewSensorDelegate(SensorValue sensorBaseArg);
    internal class PumpSensorValues
    {
        public event onNewSensorDelegate newSensorValueEvent;
        private Timer _timer_base;
        private Random _random;
        private PatientCode _patient_code = PatientCode.None;
        private PumpSensorValues() { }
        public PumpSensorValues(int periodSecondsBetweenValues)
        {
            _random = new Random();
            _timer_base = new Timer();

            _timer_base.Interval = periodSecondsBetweenValues * 1000;
            _timer_base.Elapsed += new ElapsedEventHandler(_timerBaseElapsed);
        }
        public void StartPumping()
        {
            Console.WriteLine("Started pumping ...");
            _timer_base.Start();
        }
        public void StopPumping()
        {
            Console.WriteLine("Stoped pumping ...");
            _timer_base.Stop();
        }
        public void resetPeriod(int periodSecondsBetweenValues)
        {
            _timer_base.Interval = periodSecondsBetweenValues * 1000;
        }
        public void setPatient(PatientCode patientCode)
        {
            _patient_code = patientCode;
        }
        private void _timerBaseElapsed(Object sender, ElapsedEventArgs e)
        {
            int min_number, max_number;
            double value_random;

            int max_sensor_type = System.Enum.GetValues(typeof(SensorType)).GetUpperBound(0);
            int type_random = _random.Next(1, max_sensor_type + 1);

            SensorType sensor_type_random = (SensorType)type_random;

            switch (sensor_type_random)
            {
                case SensorType.SkinTemperature:
                    min_number = 36;
                    max_number = 40;

                    value_random = _random.Next(min_number * 10, (max_number + 1) * 10) / 10.0;

                    break;

                case SensorType.BloodGlucose:
                    min_number = 80;
                    max_number = 300;

                    value_random = _random.Next(min_number, max_number + 4);

                    break;

                case SensorType.HeartRate:
                    min_number = 30;
                    max_number = 200;

                    value_random = _random.Next(min_number, max_number + 1);

                    break;

                default:
                    value_random = 0;

                    break;
            }

            PatientCode new_patient_code;

            if (_patient_code == PatientCode.None)
            {
                // getting a random patient code
                int max_patient_code = System.Enum.GetValues(typeof(PatientCode)).GetUpperBound(0);
                int patient_random = _random.Next(1, max_patient_code + 1);

                new_patient_code = (PatientCode)patient_random;
            }
            else
                new_patient_code = _patient_code;

            SensorValue sensor_random = new SensorValue(new_patient_code, sensor_type_random, value_random, DateTime.Now);

            // logging to console
            /*VirtualSensorProgram.DisplaySensorValues("New sensor value: ", sensor_random);*/

            if (newSensorValueEvent != null)
                newSensorValueEvent(sensor_random);
        }
    }
}
