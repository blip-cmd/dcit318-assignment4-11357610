public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        btnDoctors.Click += BtnDoctors_Click;
        btnBook.Click += BtnBook_Click;
        btnManage.Click += BtnManage_Click;
    }

    private void BtnDoctors_Click(object sender, EventArgs e)
    {
        new DoctorListForm().Show();
    }

    private void BtnBook_Click(object sender, EventArgs e)
    {
        new AppointmentForm().Show();
    }

    private void BtnManage_Click(object sender, EventArgs e)
    {
        new ManageAppointmentsForm().Show();
    }
}
