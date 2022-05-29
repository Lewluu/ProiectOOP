using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace ProiectOOP
{
    public partial class DataPresentation : Form
    {
        private List<SensorValue> _sv_list;
        private PatientCode _selected_patient_code;
        private PumpSensorValues _pump_sv;
        private int _period = 1;
        private bool _update_grid;
        public DataPresentation()
        {
            InitializeComponent();

            _update_grid = false;
            _selected_patient_code = PatientCode.None;
            _sv_list = new List<SensorValue>(); 
            _pump_sv = new PumpSensorValues(_period);

            _pump_sv.StartPumping();
            _pump_sv.newSensorValueEvent += new onNewSensorDelegate(onNewSensorHandler);

        }
        private void onNewSensorHandler(SensorValue sv)
        {
            _sv_list.Insert(_sv_list.Count, sv);
            if(_pump_sv.isPumping())
                this.BeginInvoke(new Action(bindDataGridToListOfValues));
        }
        private void bindDataGridToListOfValues()
        {
            int row_id = this.dataGridView1.Rows.Add();
            SensorValue sv = _sv_list[_sv_list.Count - 1];

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
    }
}
