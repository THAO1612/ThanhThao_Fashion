using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ThanhThao_Fashion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Đặt mật khẩu ẩn mặc định
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string connectionString = @"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Employees WHERE Username = @username AND Password = @password AND IsActive = 1";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int empId = Convert.ToInt32(reader["EmpID"]);
                        string fullName = reader["FullName"].ToString();
                        string role = reader["Role"].ToString();

                        MessageBox.Show($"Hello {fullName} ({role})");

                        this.Hide();
                        MainForm main = new MainForm(empId, fullName, role);
                        main.Show();

                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password. Please try again.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❗Error connecting to SQL Server:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❗System error:\n" + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register f = new Register();
            f.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the program?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
