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

namespace PharmInventory
{
    public partial class PharmD : Form
    {
        public PharmD()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacyDBDataSet.Medicines' table. You can move, or remove it, as needed.
            this.medicinesTableAdapter.Fill(this.pharmacyDBDataSet.Medicines);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private string connectionString => PharmInventory.Properties.Settings.Default.PharmacyDBConnectionString;

        private void button2_Click(object sender, EventArgs e)
        {
            // Search Button (SearchMedicine)
            string searchTerm = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SearchMedicine", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
        }

        private void buttonUpdateStock_Click(object sender, EventArgs e)
        {
            // Update Stock Button (UpdateStock)
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a medicine to update.");
                return;
            }
            
            // Try to get MedicineID from the selected row - handle different column names
            int medicineID;
            var selectedRow = dataGridView1.SelectedRows[0];
            
            try
            {
                // First try the expected column name
                if (dataGridView1.Columns.Contains("MedicineID"))
                {
                    medicineID = Convert.ToInt32(selectedRow.Cells["MedicineID"].Value);
                }
                // If that fails, try the first column (assuming it's the ID)
                else if (selectedRow.Cells[0].Value != null)
                {
                    medicineID = Convert.ToInt32(selectedRow.Cells[0].Value);
                }
                else
                {
                    MessageBox.Show("Unable to find Medicine ID in selected row.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting Medicine ID: " + ex.Message);
                return;
            }
            
            if (!int.TryParse(textNewQuantity.Text.Trim(), out int newQuantity))
            {
                MessageBox.Show("Enter a valid quantity.");
                return;
            }
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateStock", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MedicineID", medicineID);
                cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Stock updated successfully.");
            }
        }

        private void buttonRecordSale_Click(object sender, EventArgs e)
        {
            // Record Sale Button (RecordSale)
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a medicine to record sale.");
                return;
            }
            
            // Try to get MedicineID from the selected row - handle different column names
            int medicineID;
            var selectedRow = dataGridView1.SelectedRows[0];
            
            try
            {
                // First try the expected column name
                if (dataGridView1.Columns.Contains("MedicineID"))
                {
                    medicineID = Convert.ToInt32(selectedRow.Cells["MedicineID"].Value);
                }
                // If that fails, try the first column (assuming it's the ID)
                else if (selectedRow.Cells[0].Value != null)
                {
                    medicineID = Convert.ToInt32(selectedRow.Cells[0].Value);
                }
                else
                {
                    MessageBox.Show("Unable to find Medicine ID in selected row.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting Medicine ID: " + ex.Message);
                return;
            }
            
            if (!int.TryParse(textQuantitySold.Text.Trim(), out int quantitySold))
            {
                MessageBox.Show("Enter a valid quantity.");
                return;
            }
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("RecordSale", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MedicineID", medicineID);
                cmd.Parameters.AddWithValue("@QuantitySold", quantitySold);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sale recorded successfully.");
            }
        }

        private void buttonViewAll_Click(object sender, EventArgs e)
        {
            // View All Button (GetAllMedicines)
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllMedicines", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddMed_Click(object sender, EventArgs e)
        {
            // Add Medicine Button (AddMedicine)
            string name = textBoxName.Text.Trim();
            string category = textBoxCategory.Text.Trim();
            string priceText = textBoxPrice.Text.Trim();
            string quantityText = textBoxQuantity.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(category) ||
                string.IsNullOrWhiteSpace(priceText) ||
                string.IsNullOrWhiteSpace(quantityText))
            {
                MessageBox.Show("Please fill in all medicine details.");
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price) || price < 0)
            {
                MessageBox.Show("Enter a valid price.");
                return;
            }

            if (!int.TryParse(quantityText, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Enter a valid quantity.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddMedicine", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine added successfully.");
            }
        }
    }
}
