using System;
using System.Windows.Forms;
using ThanhThaoFashionApp;

namespace ThanhThao_Fashion
{
    public partial class MainForm : Form
    {
        private int empId;
        private string fullName;
        private string role;


        public MainForm(int empId, string fullName, string role)
        {
            InitializeComponent();
            this.empId = empId;
            this.fullName = fullName;
            this.role = role;

            // Phân quyền theo vai trò
            if (role == "Admin")
            {
                btnEmployee.Visible = true;
                btnCustomer.Visible = true;
                btnProduct.Visible = true;
                btnOrder.Visible = true;
                btnInventory.Visible = true;
                btnStatistic.Visible = true;
            }
            else if (role == "Sales")
            {
                btnEmployee.Visible = false;
                btnCustomer.Visible = true;
                btnProduct.Visible = true;
                btnOrder.Visible = true;
                btnInventory.Visible = true;
                btnStatistic.Visible = false;
            }
            else if (role == "Warehouse")
            {
                btnEmployee.Visible = false;
                btnCustomer.Visible = false;
                btnProduct.Visible = true;
                btnOrder.Visible = false;
                btnInventory.Visible = true;
                btnStatistic.Visible = false; // Warehouse không cần thống kê
            }
            else
            {
                MessageBox.Show("Unknown role. Access restricted.");
                Application.Exit();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login loginForm = new Login();
                loginForm.Show();
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            EmployeeForm empForm = new EmployeeForm();
            empForm.FormClosed += (s, args) => this.Show(); 
            empForm.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerForm customerForm = new CustomerForm();
            customerForm.FormClosed += (s, args) => this.Show();
            customerForm.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm productForm = new ProductForm();
            productForm.FormClosed += (s, args) => this.Show();
            productForm.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderForm orderForm = new OrderForm();
            orderForm.FormClosed += (s, args) => this.Show();
            orderForm.Show();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryForm inventoryForm = new InventoryForm();
            inventoryForm.FormClosed += (s, args) => this.Show();
            inventoryForm.Show();
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            this.Hide();

            StatisticForm statisticForm = new StatisticForm();
            statisticForm.FormClosed += (s, args) => this.Show();

            statisticForm.Show();
        }

    }
}
