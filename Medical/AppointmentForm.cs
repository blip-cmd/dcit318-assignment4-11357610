using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dcit318_assignment4_11357610.MedicalDBDataSet1;

namespace dcit318_assignment4_11357610
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            dateTimePickerAppointment.Format = DateTimePickerFormat.Custom;
            dateTimePickerAppointment.CustomFormat = "dd/MM/yyyy hh:mm tt";
            dateTimePickerAppointment.MinDate = DateTime.Now;
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            // Validate input fields
            DateTime appointmentDate = dateTimePickerAppointment.Value;
            // Compare up to the minute (ignore seconds/milliseconds)
            DateTime now = DateTime.Now;
            now = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
            appointmentDate = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, appointmentDate.Hour, appointmentDate.Minute, 0);
            if (appointmentDate <= now)
            {
                MessageBox.Show("Appointment date must be in the future (at least one minute ahead).", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxDoctors.SelectedItem == null)
            {
                MessageBox.Show("Please select a doctor.");
                return;
            }
            if (comboBoxPatients.SelectedItem == null)
            {
                MessageBox.Show("Please select a patient.");
                return;
            }

            var doctorRow = comboBoxDoctors.SelectedItem as DataRowView;
            var patientRow = comboBoxPatients.SelectedItem as DataRowView;

            int doctorId = doctorRow != null ? Convert.ToInt32(doctorRow["DoctorID"]) : 0;
            int patientId = patientRow != null ? Convert.ToInt32(patientRow["PatientID"]) : 0;
            string notes = textBoxNotes.Text;

            // Check for appointment availability (example: check if doctor has an appointment at this time)
            string connectionString = dcit318_assignment4_11357610.Properties.Settings.Default.MedicalDBConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check for existing appointment
                string checkQuery = "SELECT COUNT(*) FROM Appointments WHERE DoctorID = @DoctorID AND AppointmentDate = @AppointmentDate";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@DoctorID", doctorId);
                    checkCmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("This doctor already has an appointment at the selected time.");
                        return;
                    }
                }

                // Insert new appointment
                string insertQuery = "INSERT INTO Appointments (DoctorID, PatientID, AppointmentDate, Notes) VALUES (@DoctorID, @PatientID, @AppointmentDate, @Notes)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add("@DoctorID", SqlDbType.Int).Direction = ParameterDirection.Input;
                    cmd.Parameters["@DoctorID"].Value = doctorId;

                    cmd.Parameters.Add("@PatientID", SqlDbType.Int).Direction = ParameterDirection.Input;
                    cmd.Parameters["@PatientID"].Value = patientId;

                    cmd.Parameters.Add("@AppointmentDate", SqlDbType.DateTime).Direction = ParameterDirection.Input;
                    cmd.Parameters["@AppointmentDate"].Value = appointmentDate;

                    cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Direction = ParameterDirection.Input;
                    cmd.Parameters["@Notes"].Value = notes;

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Appointment booked successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to book appointment.");
                    }
                }
            }
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'medicalDBDataSet1.Patients' table. You can move, or remove it, as needed.
            this.patientsTableAdapter.Fill(this.medicalDBDataSet1.Patients);
            // TODO: This line of code loads data into the 'medicalDBDataSet.Doctors' table. You can move, or remove it, as needed.
            this.doctorsTableAdapter.Fill(this.medicalDBDataSet.Doctors);

        }

        private void comboBoxDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPatients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
