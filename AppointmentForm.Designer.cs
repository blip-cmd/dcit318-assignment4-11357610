namespace dcit318_assignment4_11357610
{
    partial class AppointmentForm
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
            this.components = new System.ComponentModel.Container();
            this.comboBoxDoctors = new System.Windows.Forms.ComboBox();
            this.doctorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medicalDBDataSet = new dcit318_assignment4_11357610.MedicalDBDataSet();
            this.dateTimePickerAppointment = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPatients = new System.Windows.Forms.ComboBox();
            this.patientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medicalDBDataSet1 = new dcit318_assignment4_11357610.MedicalDBDataSet1();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.buttonBook = new System.Windows.Forms.Button();
            this.doctorsTableAdapter = new dcit318_assignment4_11357610.MedicalDBDataSetTableAdapters.DoctorsTableAdapter();
            this.doctorsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.patientsTableAdapter = new dcit318_assignment4_11357610.MedicalDBDataSet1TableAdapters.PatientsTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.doctorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicalDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicalDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doctorsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDoctors
            // 
            this.comboBoxDoctors.DataSource = this.doctorsBindingSource;
            this.comboBoxDoctors.DisplayMember = "FullName";
            this.comboBoxDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDoctors.FormattingEnabled = true;
            this.comboBoxDoctors.Location = new System.Drawing.Point(12, 29);
            this.comboBoxDoctors.Name = "comboBoxDoctors";
            this.comboBoxDoctors.Size = new System.Drawing.Size(171, 24);
            this.comboBoxDoctors.TabIndex = 0;
            this.comboBoxDoctors.ValueMember = "DoctorID";
            this.comboBoxDoctors.SelectedIndexChanged += new System.EventHandler(this.comboBoxDoctors_SelectedIndexChanged);
            // 
            // doctorsBindingSource
            // 
            this.doctorsBindingSource.DataMember = "Doctors";
            this.doctorsBindingSource.DataSource = this.medicalDBDataSet;
            // 
            // medicalDBDataSet
            // 
            this.medicalDBDataSet.DataSetName = "MedicalDBDataSet";
            this.medicalDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateTimePickerAppointment
            // 
            this.dateTimePickerAppointment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAppointment.Location = new System.Drawing.Point(492, 27);
            this.dateTimePickerAppointment.Name = "dateTimePickerAppointment";
            this.dateTimePickerAppointment.Size = new System.Drawing.Size(255, 22);
            this.dateTimePickerAppointment.TabIndex = 1;
            this.dateTimePickerAppointment.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // comboBoxPatients
            // 
            this.comboBoxPatients.DataSource = this.patientsBindingSource;
            this.comboBoxPatients.DisplayMember = "FullName";
            this.comboBoxPatients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPatients.FormattingEnabled = true;
            this.comboBoxPatients.Location = new System.Drawing.Point(283, 29);
            this.comboBoxPatients.Name = "comboBoxPatients";
            this.comboBoxPatients.Size = new System.Drawing.Size(151, 24);
            this.comboBoxPatients.TabIndex = 2;
            this.comboBoxPatients.ValueMember = "PatientID";
            this.comboBoxPatients.SelectedIndexChanged += new System.EventHandler(this.comboBoxPatients_SelectedIndexChanged);
            // 
            // patientsBindingSource
            // 
            this.patientsBindingSource.DataMember = "Patients";
            this.patientsBindingSource.DataSource = this.medicalDBDataSet1;
            // 
            // medicalDBDataSet1
            // 
            this.medicalDBDataSet1.DataSetName = "MedicalDBDataSet1";
            this.medicalDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(12, 59);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(735, 77);
            this.textBoxNotes.TabIndex = 3;
            this.textBoxNotes.Text = "Notes";
            // 
            // buttonBook
            // 
            this.buttonBook.AutoSize = true;
            this.buttonBook.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonBook.Location = new System.Drawing.Point(0, 144);
            this.buttonBook.Name = "buttonBook";
            this.buttonBook.Size = new System.Drawing.Size(753, 26);
            this.buttonBook.TabIndex = 4;
            this.buttonBook.Text = "Book Appointment";
            this.buttonBook.UseVisualStyleBackColor = true;
            this.buttonBook.Click += new System.EventHandler(this.buttonBook_Click);
            // 
            // doctorsTableAdapter
            // 
            this.doctorsTableAdapter.ClearBeforeFill = true;
            // 
            // doctorsBindingSource1
            // 
            this.doctorsBindingSource1.DataMember = "Doctors";
            this.doctorsBindingSource1.DataSource = this.medicalDBDataSet;
            // 
            // patientsTableAdapter
            // 
            this.patientsTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Doctor";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Patient";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date and Time";
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(753, 170);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBook);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.comboBoxPatients);
            this.Controls.Add(this.dateTimePickerAppointment);
            this.Controls.Add(this.comboBoxDoctors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.doctorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicalDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicalDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doctorsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDoctors;
        private System.Windows.Forms.DateTimePicker dateTimePickerAppointment;
        private System.Windows.Forms.ComboBox comboBoxPatients;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Button buttonBook;
        private MedicalDBDataSet medicalDBDataSet;
        private System.Windows.Forms.BindingSource doctorsBindingSource;
        private MedicalDBDataSetTableAdapters.DoctorsTableAdapter doctorsTableAdapter;
        private System.Windows.Forms.BindingSource doctorsBindingSource1;
        private MedicalDBDataSet1 medicalDBDataSet1;
        private System.Windows.Forms.BindingSource patientsBindingSource;
        private MedicalDBDataSet1TableAdapters.PatientsTableAdapter patientsTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}