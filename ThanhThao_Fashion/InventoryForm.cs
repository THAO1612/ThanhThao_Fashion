using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ThanhThaoFashionApp
{
    public partial class InventoryForm : Form
    {
        private string connectionString = @"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;";

        public InventoryForm()
        {
            InitializeComponent();
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadEmployees();
            LoadInventory();
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ProductID, Name FROM Products", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboProduct.DataSource = dt;
                cboProduct.DisplayMember = "Name";
                cboProduct.ValueMember = "ProductID";
            }
        }

        private void LoadEmployees()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT EmpID,FullName FROM Employees", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboEmployee.DataSource = dt;
                cboEmployee.DisplayMember = "Name";
                cboEmployee.ValueMember = "EmpID";
            }
        }

        private void LoadInventory(string search = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT i.InventoryID, p.Name AS ProductName, e.FullName AS EmployeeName, 
                                        i.Quantity, i.Type, i.Date
                                 FROM Inventory i
                                 JOIN Products p ON i.ProductID = p.ProductID
                                 JOIN Employees e ON i.EmpID = e.EmpID";

                if (!string.IsNullOrEmpty(search))
                    query += " WHERE p.Name LIKE @search";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (!string.IsNullOrEmpty(search))
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvInventory.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid quantity!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Inventory (ProductID, EmpID, Quantity, Type, Date)
                      VALUES (@pid, @eid, @qty, @type, @date)", conn);

                cmd.Parameters.AddWithValue("@pid", cboProduct.SelectedValue);
                cmd.Parameters.AddWithValue("@eid", cboEmployee.SelectedValue);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@type", cboType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@date", dtpDate.Value);
                cmd.ExecuteNonQuery();
            }
            LoadInventory();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null) return;
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid quantity!");
                return;
            }

            int id = Convert.ToInt32(dgvInventory.CurrentRow.Cells["InventoryID"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Inventory 
                      SET ProductID=@pid, EmpID=@eid, Quantity=@qty, Type=@type, Date=@date 
                      WHERE InventoryID=@id", conn);

                cmd.Parameters.AddWithValue("@pid", cboProduct.SelectedValue);
                cmd.Parameters.AddWithValue("@eid", cboEmployee.SelectedValue);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@type", cboType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@date", dtpDate.Value);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            LoadInventory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvInventory.CurrentRow.Cells["InventoryID"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Inventory WHERE InventoryID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            LoadInventory();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInventory(txtSearch.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cboProduct.Text = dgvInventory.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                cboEmployee.Text = dgvInventory.Rows[e.RowIndex].Cells["EmployeeName"].Value.ToString();
                txtQuantity.Text = dgvInventory.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                cboType.Text = dgvInventory.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                dtpDate.Value = Convert.ToDateTime(dgvInventory.Rows[e.RowIndex].Cells["Date"].Value);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
