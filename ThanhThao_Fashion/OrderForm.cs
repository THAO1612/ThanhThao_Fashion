using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ThanhThao_Fashion
{
    public partial class OrderForm : Form
    {
        private string connectionString = @"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;";

        public OrderForm()
        {
            InitializeComponent();
            LoadCombos();
            LoadOrders();
            dgvOrders.CellClick += DgvOrders_CellClick;
            txtTotalAmount.TextChanged += CalculateFinalAmount;
            txtDiscount.TextChanged += CalculateFinalAmount;
        }

        private void LoadCombos()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                conn.Open();

                // Load Customers
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT CustomerID, Name FROM Customers", conn);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                cboCustomer.DataSource = dt1;
                cboCustomer.DisplayMember = "Name";
                cboCustomer.ValueMember = "CustomerID";

                // Load Employees
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT EmpID, FullName FROM Employees", conn);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                cboEmployee.DataSource = dt2;
                cboEmployee.DisplayMember = "FullName";
                cboEmployee.ValueMember = "EmpID";

                // Load Status
                cboStatus.Items.AddRange(new object[] { "Pending", "Completed", "Cancelled" });

                // Load Payment Methods
                cboPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Bank Transfer" });
            }
        }

        private void LoadOrders(string search = "", DateTime? date = null, string paymentMethod = "")
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = @"
                    SELECT o.OrderID, c.Name AS CustomerName, e.FullName AS EmployeeName, 
                           o.OrderDate, o.TotalAmount, o.Discount, o.FinalAmount, o.Status, o.PaymentMethod
                    FROM Orders o
                    JOIN Customers c ON o.CustomerID = c.CustomerID
                    JOIN Employees e ON o.EmpID = e.EmpID
                    WHERE (@search = '' OR c.Name LIKE '%' + @search + '%' OR o.Status LIKE '%' + @search + '%')
                      AND (@date IS NULL OR CAST(o.OrderDate AS DATE) = @date)
                      AND (@paymentMethod = '' OR o.PaymentMethod = @paymentMethod)
                    ORDER BY o.OrderDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@search", search);
                da.SelectCommand.Parameters.AddWithValue("@date", (object)date ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvOrders.DataSource = dt;

                if (dgvOrders.Columns.Contains("Discount"))
                    dgvOrders.Columns["Discount"].DefaultCellStyle.Format = "0'%'";
            }
        }

        private void DgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrders.CurrentRow != null)
            {
                DataGridViewRow row = dgvOrders.CurrentRow;

                // Lấy OrderID để có thể xử lý nếu cần
                int orderId = Convert.ToInt32(row.Cells["OrderID"].Value);

                // Gán giá trị cho các controls
                cboCustomer.SelectedValue = GetCustomerIdByName(row.Cells["CustomerName"].Value?.ToString());
                cboEmployee.SelectedValue = GetEmployeeIdByName(row.Cells["EmployeeName"].Value?.ToString());

                if (row.Cells["OrderDate"].Value != null)
                    dtpOrderDate.Value = Convert.ToDateTime(row.Cells["OrderDate"].Value);

                txtTotalAmount.Text = row.Cells["TotalAmount"].Value?.ToString();
                txtDiscount.Text = row.Cells["Discount"].Value?.ToString();
                cboStatus.Text = row.Cells["Status"].Value?.ToString();
                cboPaymentMethod.Text = row.Cells["PaymentMethod"].Value?.ToString();
            }
        }

        private int GetCustomerIdByName(string customerName)
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CustomerID FROM Customers WHERE Name = @Name", conn);
                cmd.Parameters.AddWithValue("@Name", customerName);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private int GetEmployeeIdByName(string employeeName)
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT EmpID FROM Employees WHERE FullName = @FullName", conn);
                cmd.Parameters.AddWithValue("@FullName", employeeName);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private void CalculateFinalAmount(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTotalAmount.Text, out decimal total) &&
                decimal.TryParse(txtDiscount.Text, out decimal discount))
            {
                decimal finalAmount = total * (1 - discount / 100);
                this.Text = $"Order Management - Final: {finalAmount:N0} VND";
            }
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                conn.Open();
                string query = @"INSERT INTO Orders(CustomerID, EmpID, OrderDate, TotalAmount, Discount, Status, PaymentMethod)
                         OUTPUT INSERTED.OrderID
                         VALUES(@CustomerID, @EmpID, @OrderDate, @TotalAmount, @Discount, @Status, @PaymentMethod)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", cboCustomer.SelectedValue);
                cmd.Parameters.AddWithValue("@EmpID", cboEmployee.SelectedValue);
                cmd.Parameters.AddWithValue("@OrderDate", dtpOrderDate.Value);
                cmd.Parameters.AddWithValue("@TotalAmount", decimal.Parse(txtTotalAmount.Text));
                cmd.Parameters.AddWithValue("@Discount", decimal.Parse(txtDiscount.Text));
                cmd.Parameters.AddWithValue("@Status", cboStatus.Text);
                cmd.Parameters.AddWithValue("@PaymentMethod", cboPaymentMethod.Text);
                cmd.Parameters.AddWithValue("@Discount", int.Parse(txtDiscount.Text));

                int newOrderId = Convert.ToInt32(cmd.ExecuteScalar());

                // Mở OrderDetailsForm để thêm sản phẩm
                OrderDetailsForm frm = new OrderDetailsForm(newOrderId, connectionString);
                frm.ShowDialog();

                LoadOrders();
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;
            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderID"].Value);

            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                conn.Open();
                string query = @"UPDATE Orders
                                 SET CustomerID=@CustomerID, EmpID=@EmpID, OrderDate=@OrderDate,
                                     TotalAmount=@TotalAmount, Discount=@Discount,
                                     Status=@Status, PaymentMethod=@PaymentMethod
                                 WHERE OrderID=@OrderID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", cboCustomer.SelectedValue);
                cmd.Parameters.AddWithValue("@EmpID", cboEmployee.SelectedValue);
                cmd.Parameters.AddWithValue("@OrderDate", dtpOrderDate.Value);
                cmd.Parameters.AddWithValue("@TotalAmount", decimal.Parse(txtTotalAmount.Text));
                cmd.Parameters.AddWithValue("@Discount", decimal.Parse(txtDiscount.Text));
                cmd.Parameters.AddWithValue("@Status", cboStatus.Text);
                cmd.Parameters.AddWithValue("@PaymentMethod", cboPaymentMethod.Text);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@Discount", int.Parse(txtDiscount.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Order updated successfully!");
                LoadOrders();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;
            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderID"].Value);

            if (MessageBox.Show("Are you sure you want to delete this order?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))

                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Orders WHERE OrderID=@OrderID", conn);
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order deleted successfully!");
                    LoadOrders();
                }
            }
        }

        private void btnViewDetails_Click_1(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;
            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderID"].Value);
            OrderDetailsForm frm = new OrderDetailsForm(orderId, connectionString);
            frm.DataChanged += () => LoadOrders();
            frm.ShowDialog();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadOrders(txtSearch.Text, dtpOrderDate.Value, cboPaymentMethod.Text);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

    }
}
