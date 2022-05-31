using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataStore;

namespace ProiectOOP
{
    public partial class DataPresentation : Form
    {
        private List<SensorInput.SensorValue> _sv_list;
        private PatientCode _selected_patient_code;
        private SensorInput.PumpSensorValues _pump_sv;
        private int _period = 1;
        private MonthCalendar _month_calendar;
        public DataPresentation()
        {
            InitializeComponent();
            setNumberDecimalSeparator();

            _selected_patient_code = PatientCode.None;
            _sv_list = new List<SensorInput.SensorValue>(); 
            _pump_sv = new SensorInput.PumpSensorValues(_period);

            _pump_sv.StartPumping();
            _pump_sv.newSensorValueEvent += new SensorInput.onNewSensorDelegate(onNewSensorHandler);

        }
        private void onNewSensorHandler(SensorInput.SensorValue sv)
        {
            _sv_list.Insert(_sv_list.Count, sv);
            if(_pump_sv.isPumping())
                this.BeginInvoke(new Action(bindDataGridToListOfValues));

            // add data to db
            DataStore.MySQL_DataStore.addToDB(sv);
        }
        private void bindDataGridToListOfValues()
        {
            int row_id = this.dataGridView1.Rows.Add();
            SensorInput.SensorValue sv = _sv_list[_sv_list.Count - 1];

            this.dataGridView1.Rows[row_id].Cells[0].Value = sv.PatientCode.ToString();
            this.dataGridView1.Rows[row_id].Cells[1].Value = sv.Type.ToString();
            this.dataGridView1.Rows[row_id].Cells[2].Value = sv.TimeStampString.ToString();
            this.dataGridView1.Rows[row_id].Cells[3].Value = sv.Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selected_patient_code = (PatientCode)comboBox1.SelectedIndex;
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                _period = Convert.ToInt32(this.textBox1.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _pump_sv.resetPeriod(_period);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            _pump_sv.setPatient(_selected_patient_code);

            if (!_pump_sv.isPumping())
                _pump_sv.StartPumping();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _pump_sv.StopPumping();
        }
        private void setNumberDecimalSeparator()
        {
            System.Globalization.CultureInfo culture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            _month_calendar = this.monthCalendar1;
            // Console.WriteLine(this.monthCalendar1.SelectionStart.ToShortDateString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySQL_DataStore.getSensorValues(_month_calendar.SelectionStart.ToShortDateString());
        }
    }
}
