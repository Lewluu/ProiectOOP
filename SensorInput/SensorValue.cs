using System;
using System.Globalization;

public enum SensorType
{
    None,
    SkinTemperature,
    HeartRate,
    BloodGlucose,
}

public enum PatientCode
{
    None,
    Patient_1,
    Patient_2,
    Patient_3,
    Patient_4,
    Patient_5,
    Patient_6,
}

namespace SensorInput
{
    public class SensorValue
    {
        private SensorType _sensor_type;
        private double _value;
        private DateTime _timestamp;
        private PatientCode _patient_code;

        #region proprieties
        public SensorType Type
        {
            get { return _sensor_type; }
            set { _sensor_type = value; }
        }
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }
        public string TimeStampString
        {
            get { return _timestamp.ToString("dd/MM/yy HH:mm:ss"); }
            set { _timestamp = DateTime.ParseExact(value, "dd/MM/yy HH:mm:ss", CultureInfo.InvariantCulture); }
        }
        public PatientCode PatientCode
        {
            get { return _patient_code; }
            set { _patient_code = value; }
        }
        #endregion

        #region constructors
        public SensorValue()
        {
            _sensor_type = SensorType.None;
            _patient_code = PatientCode.None;
        }
        public SensorValue(PatientCode patientCode, SensorType type, double value, DateTime timestamp)
        {
            _patient_code = patientCode;
            _sensor_type = type;
            _value = value;
            _timestamp = timestamp;
        }
        public SensorValue(PatientCode patientCode, SensorType type, double value, string timestamp)
        {
            _patient_code = patientCode;
            _sensor_type = type;
            _value = value;
            this.TimeStampString = timestamp;
        }
        #endregion
    }
}
