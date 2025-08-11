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
    public partial class Register : Form
    {
        string connectionString = @"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;";
        private object txtConfirmPasswordd;
        private object txtConfirmPasssword;

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            cbRole.SelectedIndex = 1; // Mặc định chọn "Sales"
        }


        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            string fullname = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string role = cbRole.SelectedItem?.ToString();

            // 1. Kiểm tra dữ liệu hợp lệ
            if (fullname == "" || username == "" || password == "" || confirmPassword == "" || role == null)
            {
                MessageBox.Show("Please enter complete information.");
                return;
            }

            // 2. Kiểm tra mật khẩu xác nhận
            if (password != confirmPassword)
            {
                MessageBox.Show("The confirmation password does not match.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 3. Sinh mã nhân viên ngẫu nhiên (ví dụ: EMP6582912)
                    string newEmpCode = "EMP" + DateTime.Now.Ticks.ToString().Substring(10);

                    string position = role == "Admin" ? "Manager"
                                   : role == "Sales" ? "Salesperson"
                                   : "Warehouse Staff";

                    // 4. Câu lệnh thêm vào bảng Employees
                    string query = @"INSERT INTO Employees 
                    (EmployeeCode, Username, Password, FullName, Position, Role, Email, Phone, IsActive) 
                    VALUES 
                    (@code, @username, @password, @fullname, @position, @role, NULL, NULL, 1)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@code", newEmpCode);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@position", position);
                    cmd.Parameters.AddWithValue("@role", role);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Registration successful!");
                        this.Close(); // đóng form sau khi đăng ký thành công
                    }
                    else
                    {
                        MessageBox.Show("Registration failed!");
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) // lỗi trùng username
                {
                    MessageBox.Show("Account name already exists. Please choose another name.");
                }
                else
                {
                    MessageBox.Show("SQL Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System error: " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool showPassword = checkBox1.Checked;

            txtPassword.PasswordChar = showPassword ? '\0' : '*';
            txtConfirmPassword.PasswordChar = showPassword ? '\0' : '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

    }
}
