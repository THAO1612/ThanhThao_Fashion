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

namespace ThanhThao_Fashion
{
    public partial class CustomerForm : Form
    {
        private string connectionString = @"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;";

        public CustomerForm()
        {
            InitializeComponent();
            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))

            {
                string query = "SELECT CustomerID, Name, Email, Phone, Address FROM Customers"; 
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomers.DataSource = dt;

                dgvCustomers.Columns["Address"].Width = 240;
                dgvCustomers.Columns["CustomerID"].Width = 70;
                dgvCustomers.Columns["Phone"].Width = 80;

            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                txtFullName.Text = dgvCustomers.CurrentRow.Cells["Name"].Value.ToString();
                txtEmail.Text = dgvCustomers.CurrentRow.Cells["Email"].Value.ToString();
                txtPhone.Text = dgvCustomers.CurrentRow.Cells["Phone"].Value.ToString();
                txtAddress.Text = dgvCustomers.CurrentRow.Cells["Address"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Please enter required fields (Full Name, Phone).");
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))

            {
                string query = @"INSERT INTO Customers (Name, Email, Phone, Address)
                                 VALUES (@name, @email, @phone, @address)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer added successfully!");

                LoadCustomers();
                ClearFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            int custId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["CustomerID"].Value);

            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))

            {
                string query = @"UPDATE Customers SET
                                 Name = @name,
                                 Email = @email,
                                 Phone = @phone,
                                 Address = @address
                                 WHERE CustomerID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", custId);
                cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer updated successfully!");

                LoadCustomers();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            int custId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["CustomerID"].Value);

            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))

            {
                string query = "DELETE FROM Customers WHERE CustomerID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", custId);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer deleted successfully.");

                LoadCustomers();
                ClearFields();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                conn.Open();

                string query = @"SELECT * FROM Customers WHERE 
                            Name LIKE @keyword OR 
                            Email LIKE @keyword OR 
                            Phone LIKE @keyword";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvCustomers.DataSource = dt;

                conn.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
