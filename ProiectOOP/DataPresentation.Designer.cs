using System.Collections.Generic;

namespace ProiectOOP
{
    partial class DataPresentation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._patient_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._sensor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._timp_stamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1.DataSource = System.Enum.GetValues(typeof(PatientCode));
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._patient_code,
            this._sensor,
            this._timp_stamp,
            this._value});
            this.dataGridView1.Location = new System.Drawing.Point(32, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 407);
            this.dataGridView1.TabIndex = 1;
            // 
            // _patient_code
            // 
            this._patient_code.HeaderText = "PatientCode";
            this._patient_code.Name = "_patient_code";
            // 
            // _sensor
            // 
            this._sensor.HeaderText = "Sensor";
            this._sensor.Name = "_sensor";
            // 
            // _timp_stamp
            // 
            this._timp_stamp.HeaderText = "TimeStamp";
            this._timp_stamp.Name = "_timp_stamp";
            // 
            // _value
            // 
            this._value.HeaderText = "Value";
            this._value.Name = "_value";
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(532, 139);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(532, 202);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(704, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 83);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start Monitoring";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DataPresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 606);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DataPresentation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virtual Sensor Project";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _patient_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn _sensor;
        private System.Windows.Forms.DataGridViewTextBoxColumn _timp_stamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn _value;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

