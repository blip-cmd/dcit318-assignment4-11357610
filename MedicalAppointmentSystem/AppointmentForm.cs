public partial class AppointmentForm : Form
{
    public AppointmentForm()
    {
        InitializeComponent();
        LoadDoctors();
        LoadPatients();
        btnBook.Click += BtnBook_Click;
    }

    private void LoadDoctors()
    {
        using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT DoctorID, FullName FROM Doctors WHERE Availability = 1", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            cmbDoctor.DataSource = dt;
            cmbDoctor.DisplayMember = "FullName";
            cmbDoctor.ValueMember = "DoctorID";
        }
    }

    private void LoadPatients()
    {
        using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT PatientID, FullName FROM Patients", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            cmbPatient.DataSource = dt;
            cmbPatient.DisplayMember = "FullName";
            cmbPatient.ValueMember = "PatientID";
        }
    }

    private void BtnBook_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
        {
            string query = "INSERT INTO Appointments (DoctorID, PatientID, AppointmentDate, Notes) VALUES (@DoctorID, @PatientID, @Date, @Notes)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DoctorID", cmbDoctor.SelectedValue);
            cmd.Parameters.AddWithValue("@PatientID", cmbPatient.SelectedValue);
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
            cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Appointment booked successfully!");
        }
    }
}
