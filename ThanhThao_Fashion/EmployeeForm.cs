using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ThanhThao_Fashion
{
    public partial class EmployeeForm : Form
    {
        private string connectionString = @"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;";

        public EmployeeForm()
        {
            InitializeComponent();
            this.dgvEmployees.SelectionChanged += new System.EventHandler(this.dgvEmployees_SelectionChanged);

        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();

            cboRole.Items.Clear();
            cboRole.Items.AddRange(new string[] { "Admin", "Sales", "Warehouse" });
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadEmployees()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = "SELECT EmpID, FullName, Username, Email, Phone, Position, Role FROM Employees WHERE IsActive = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEmployees.DataSource = dt;
            }
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow != null)
            {
                txtFullName.Text = dgvEmployees.CurrentRow.Cells["FullName"].Value.ToString();
                txtUsername.Text = dgvEmployees.CurrentRow.Cells["Username"].Value.ToString();
                txtEmail.Text = dgvEmployees.CurrentRow.Cells["Email"].Value.ToString();
                txtPhone.Text = dgvEmployees.CurrentRow.Cells["Phone"].Value.ToString();
                txtPosition.Text = dgvEmployees.CurrentRow.Cells["Position"].Value.ToString();
                cboRole.Text = dgvEmployees.CurrentRow.Cells["Role"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtPosition.Clear();
            cboRole.SelectedIndex = -1;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (txtFullName.Text == "" || txtUsername.Text == "" || cboRole.Text == "")
            {
                MessageBox.Show("Please fill in required fields.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = @"INSERT INTO Employees (EmployeeCode, FullName, Username, Password, Email, Phone, Position, Role, IsActive) 
                                 VALUES (@code, @name, @user, @pass, @email, @phone, @pos, @role, 1)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code", "EMP" + Guid.NewGuid().ToString("N").Substring(0, 5).ToUpper());
                cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", "123"); // mặc định
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@pos", txtPosition.Text.Trim());
                cmd.Parameters.AddWithValue("@role", cboRole.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee added successfully!");

                LoadEmployees();
                ClearFields();
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("Please select an employee to update.");
                return;
            }

            int empId = Convert.ToInt32(dgvEmployees.CurrentRow.Cells["EmpID"].Value);

            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = @"UPDATE Employees SET 
                                 FullName = @name, 
                                 Username = @user, 
                                 Email = @email, 
                                 Phone = @phone,
                                 Position = @pos, 
                                 Role = @role 
                                 WHERE EmpID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", empId);
                cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@pos", txtPosition.Text.Trim());
                cmd.Parameters.AddWithValue("@role", cboRole.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee updated successfully!");

                LoadEmployees();
                ClearFields();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("Please select an employee to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            int empId = Convert.ToInt32(dgvEmployees.CurrentRow.Cells["EmpID"].Value);

            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = "UPDATE Employees SET IsActive = 0 WHERE EmpID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", empId);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee removed.");

                LoadEmployees();
                ClearFields();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }


    }
}
