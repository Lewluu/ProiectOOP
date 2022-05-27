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
        private int _period;
        public DataPresentation()
        {
            InitializeComponent();

            _selected_patient_code = PatientCode.None;
            _sv_list = new List<SensorValue>(); 
            _pump_sv = new PumpSensorValues(1);

            _pump_sv.StartPumping();
            _pump_sv.newSensorValueEvent += new onNewSensorDelegate(onNewSensorHandler);

        }
        private void onNewSensorHandler(SensorValue sv)
        {
            _sv_list.Insert(_sv_list.Count, sv);
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

/*            if (_selected_patient_code != PatientCode.None)
            {
                if (sv.PatientCode == _selected_patient_code)
                {
                    this.dataGridView1.Rows[row_id].Visible = true;
                }
                else
                {
                    this.dataGridView1.Rows[row_id].Visible = false;
                }
            }*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selected_patient_code = (PatientCode)comboBox1.SelectedIndex;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _period = Convert.ToInt32(this.textBox1.Text);
            Console.WriteLine(this.textBox1.Text);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("hello");

            _pump_sv.resetPeriod(_period);

            for (int i = 0; i < this.dataGridView1.RowCount - 1; i++)
            {
                if (_selected_patient_code == PatientCode.None)
                {
                    this.dataGridView1.Rows[i].Visible = true;
                }
                else if (this.dataGridView1.Rows[i].Cells[0].Value.ToString() != _selected_patient_code.ToString())
                    this.dataGridView1.Rows[i].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(_period);

            _pump_sv.resetPeriod(_period);

            for (int i = 0; i < this.dataGridView1.RowCount - 1; i++)
            {
                if (_selected_patient_code == PatientCode.None)
                {
                    this.dataGridView1.Rows[i].Visible = true;
                }
                else if (this.dataGridView1.Rows[i].Cells[0].Value.ToString() != _selected_patient_code.ToString())
                    this.dataGridView1.Rows[i].Visible = false;
            }
        }
    }
}
