using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dcit318_assignment4_11357610
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Header.Links.Add(0, Header.Text.Length, "https://github.com/blip-cmd/dcit318-assignment4-11357610/tree/master");

        }

        private void Header_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the link in the default browser
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });

            // Optional: mark the link as visited
            Header.LinkVisited = true;

        }

        private void buttonViewDoctors_Click(object sender, EventArgs e)
        {
            // Open Doctors Form
            var doctorListForm = new DoctorListForm();
            doctorListForm.ShowDialog();
        }

        private void buttonManageAppointments_Click(object sender, EventArgs e)
        {
            //Opens ManageAppointmentsForm
            var ManageAppointmentsForm = new ManageAppointmentsForm();
            ManageAppointmentsForm.ShowDialog();
        }

        private void buttonBookAppointment_Click(object sender, EventArgs e)
        {
            // Open Appointment Form
            var appointmentForm = new AppointmentForm();
            appointmentForm.ShowDialog();
        }
    }
}
