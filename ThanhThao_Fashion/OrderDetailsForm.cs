using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ThanhThao_Fashion
{
    public partial class OrderDetailsForm : Form
    {
        private int orderId;
        private string connectionString;
        public event Action DataChanged;

        public OrderDetailsForm(int orderId, string connectionString)
        {
            InitializeComponent();
            this.orderId = orderId;
            this.connectionString = connectionString;

            LoadProducts();
            LoadOrderDetails();
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))

            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ProductID, Name FROM Products", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboProduct.DataSource = dt;
                cboProduct.DisplayMember = "Name";
                cboProduct.ValueMember = "ProductID";
            }
        }

        private void LoadOrderDetails()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))

            {
                conn.Open();
                string query = @"
                    SELECT od.OrderDetailID, 
                           p.Name AS ProductName, 
                           od.Quantity, 
                           od.UnitPrice, 
                           od.Discount,
                           (od.Quantity * od.UnitPrice * (1 - od.Discount / 100.0)) AS TotalPrice
                    FROM OrderDetails od
                    JOIN Products p ON od.ProductID = p.ProductID
                    WHERE od.OrderID = @OrderID";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@OrderID", orderId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvOrderDetails.DataSource = dt;

                if (dgvOrderDetails.Columns.Contains("Discount"))
                    dgvOrderDetails.Columns["Discount"].DefaultCellStyle.Format = "0'%'";
            }
        }

        private void UpdateOrderTotal()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    UPDATE Orders
                    SET TotalAmount = ISNULL(
                        (SELECT SUM(od.Quantity * od.UnitPrice * (1 - od.Discount / 100.0)) 
                         FROM OrderDetails od 
                         WHERE od.OrderID = @OrderID), 0)
                    WHERE OrderID = @OrderID", conn);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.ExecuteNonQuery();
            }
        }

        private bool HasSufficientStock(int productId, int requestedQty)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Quantity FROM Products WHERE ProductID = @pid", conn);
                cmd.Parameters.AddWithValue("@pid", productId);
                int currentQty = Convert.ToInt32(cmd.ExecuteScalar());

                if (requestedQty > currentQty)
                {
                    MessageBox.Show("Not enough stock available for this product!", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            int productId = Convert.ToInt32(cboProduct.SelectedValue);
            int quantity = int.Parse(txtQuantity.Text);

            if (!HasSufficientStock(productId, quantity))
                return;


            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))

            {
                conn.Open();
                string query = @"INSERT INTO OrderDetails(OrderID, ProductID, Quantity, UnitPrice, Discount)
                         VALUES(@OrderID, @ProductID, @Quantity, @UnitPrice, @Discount)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@UnitPrice", decimal.Parse(txtUnitPrice.Text));

                decimal discount = 0;
                decimal.TryParse(txtDiscount.Text, out discount);
                cmd.Parameters.AddWithValue("@Discount", discount);

                cmd.ExecuteNonQuery();
            }
            LoadOrderDetails();
            UpdateOrderTotal();
            DataChanged?.Invoke();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.CurrentRow == null) return;
            int detailId = Convert.ToInt32(dgvOrderDetails.CurrentRow.Cells["OrderDetailID"].Value);
            int productId = Convert.ToInt32(cboProduct.SelectedValue);
            int quantity = int.Parse(txtQuantity.Text);

            if (!HasSufficientStock(productId, quantity))
                return;

            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))

            {
                conn.Open();
                string query = @"UPDATE OrderDetails
                         SET ProductID=@ProductID, Quantity=@Quantity, UnitPrice=@UnitPrice, Discount=@Discount
                         WHERE OrderDetailID=@OrderDetailID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@UnitPrice", decimal.Parse(txtUnitPrice.Text));

                decimal discount = 0;
                decimal.TryParse(txtDiscount.Text, out discount);
                cmd.Parameters.AddWithValue("@Discount", discount);

                cmd.Parameters.AddWithValue("@OrderDetailID", detailId);

                cmd.ExecuteNonQuery();
            }
            LoadOrderDetails();
            UpdateOrderTotal();
            DataChanged?.Invoke();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.CurrentRow == null) return;
            int detailId = Convert.ToInt32(dgvOrderDetails.CurrentRow.Cells["OrderDetailID"].Value);

            if (MessageBox.Show("Delete this product from order?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))

                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM OrderDetails WHERE OrderDetailID=@ID", conn);
                    cmd.Parameters.AddWithValue("@ID", detailId);
                    cmd.ExecuteNonQuery();
                }
                LoadOrderDetails();
                UpdateOrderTotal();
                DataChanged?.Invoke();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrderDetails.CurrentRow != null)
            {
                cboProduct.Text = dgvOrderDetails.CurrentRow.Cells["ProductName"].Value.ToString();
                txtQuantity.Text = dgvOrderDetails.CurrentRow.Cells["Quantity"].Value.ToString();
                txtUnitPrice.Text = dgvOrderDetails.CurrentRow.Cells["UnitPrice"].Value.ToString();
                txtDiscount.Text = dgvOrderDetails.CurrentRow.Cells["Discount"].Value.ToString();
            }
        }
    }
}
