public partial class ManageAppointmentsForm : Form
{
    public ManageAppointmentsForm()
    {
        InitializeComponent();
        LoadAppointments();
        dgvAppointments.SelectionChanged += DgvAppointments_SelectionChanged;
        btnUpdate.Click += BtnUpdate_Click;
        btnDelete.Click += BtnDelete_Click;
    }

    private void LoadAppointments()
    {
        using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Appointments", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dgvAppointments.DataSource = ds.Tables[0];
        }
    }

    private void DgvAppointments_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvAppointments.CurrentRow != null)
        {
            txtNotes.Text = dgvAppointments.CurrentRow.Cells["Notes"].Value.ToString();
            dtpDate.Value = Convert.ToDateTime(dgvAppointments.CurrentRow.Cells["AppointmentDate"].Value);
        }
    }

    private void BtnUpdate_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["AppointmentID"].Value);
        using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE Appointments SET AppointmentDate=@Date, Notes=@Notes WHERE AppointmentID=@ID", conn);
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
            cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);
            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Appointment updated.");
            LoadAppointments();
        }
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["AppointmentID"].Value);
        using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Appointments WHERE AppointmentID=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Appointment deleted.");
            LoadAppointments();
        }
    }
}
