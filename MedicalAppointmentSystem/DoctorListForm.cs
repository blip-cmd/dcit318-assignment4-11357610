public partial class DoctorListForm : Form
{
    public DoctorListForm()
    {
        InitializeComponent();
        LoadDoctors();
    }

    private void LoadDoctors()
    {
        using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
        {
            string query = "SELECT * FROM Doctors";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgvDoctors.DataSource = dt;
        }
    }
}
