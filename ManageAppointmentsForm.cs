using System;
using System.Data;
using System.Windows.Forms;

namespace dcit318_assignment4_11357610
{
    public partial class ManageAppointmentsForm : Form
    {
        public ManageAppointmentsForm()
        {
            InitializeComponent();
            this.dataGridViewAppointments.CellValueChanged += dataGridViewAppointments_CellValueChanged;
            this.dataGridViewAppointments.CurrentCellDirtyStateChanged += dataGridViewAppointments_CurrentCellDirtyStateChanged;
            this.dataGridViewAppointments.DataError += dataGridViewAppointments_DataError;
        }

        private void ManageAppointmentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Load data into the 'medicalDBDataSet1.Appointments' table
                this.appointmentsTableAdapter.Fill(this.medicalDBDataSet1.Appointments);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Set all columns except AppointmentDate and Notes to ReadOnly
            foreach (DataGridViewColumn col in dataGridViewAppointments.Columns)
            {
                if (col.Name != "appointmentDateDataGridViewTextBoxColumn" && col.Name != "notesDataGridViewTextBoxColumn")
                {
                    col.ReadOnly = true;
                }
                else
                {
                    col.ReadOnly = false;
                }
            }
        }

        private void dataGridViewAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewAppointments_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Only save if the edited column is AppointmentDate or Notes
            if (e.RowIndex >= 0 && (dataGridViewAppointments.Columns[e.ColumnIndex].Name == "appointmentDateDataGridViewTextBoxColumn" || dataGridViewAppointments.Columns[e.ColumnIndex].Name == "notesDataGridViewTextBoxColumn"))
            {
                try
                {
                    this.Validate();
                    this.appointmentsBindingSource.EndEdit();
                    try
                    {
                        this.appointmentsTableAdapter.Update(this.medicalDBDataSet1.Appointments);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("unavailable") || ex.Message.Contains("constraint") || ex.Message.Contains("conflict"))
                        {
                            MessageBox.Show("The selected appointment date and time is unavailable. Please choose a different date and time.", "Date Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Error saving changes: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }
                    try
                    {
                        this.medicalDBDataSet1.Appointments.Clear();
                        this.appointmentsTableAdapter.Fill(this.medicalDBDataSet1.Appointments);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error refreshing appointments: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    MessageBox.Show("Changes saved and refreshed.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error validating or saving changes: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewAppointments_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Commit cell value immediately when editing ends (for checkboxes, etc.)
            if (dataGridViewAppointments.IsCurrentCellDirty)
            {
                dataGridViewAppointments.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewAppointments.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridViewAppointments.SelectedCells[0].RowIndex;
                var row = dataGridViewAppointments.Rows[rowIndex];
                var rowView = row.DataBoundItem as DataRowView;
                var result = MessageBox.Show("Are you sure you want to delete the selected appointment?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (rowView != null)
                    {
                        try
                        {
                            rowView.Row.Delete();
                            this.appointmentsBindingSource.EndEdit();
                            try
                            {
                                this.appointmentsTableAdapter.Update(this.medicalDBDataSet1.Appointments);
                           
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error deleting appointment: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            try
                            {
                                this.medicalDBDataSet1.Appointments.Clear();
                                this.appointmentsTableAdapter.Fill(this.medicalDBDataSet1.Appointments);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error refreshing appointments: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            MessageBox.Show("Appointment deleted successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while deleting the appointment:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Could not delete the selected appointment.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment cell to delete.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridViewAppointments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                MessageBox.Show("Invalid date/time format. Please enter the date and time as: M/d/yyyy h:mm tt (e.g., 8/29/2025 5:18 PM)", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                MessageBox.Show("An error occurred: " + e.Exception.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
