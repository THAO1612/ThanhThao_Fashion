using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;

namespace ThanhThao_Fashion
{
    public partial class ProductForm : Form
    {
        private string connectionString = @"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;";

        public ProductForm()
        {
            InitializeComponent();
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
        }

        private bool IsProductCodeExists(string productCode, int? productIdToExclude = null)
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = "SELECT COUNT(*) FROM Products WHERE ProductCode = @code";
                if (productIdToExclude.HasValue)
                    query += " AND ProductID <> @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code", productCode);
                if (productIdToExclude.HasValue)
                    cmd.Parameters.AddWithValue("@id", productIdToExclude.Value);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cboCategory.Items.Clear();
            cboCategory.Items.AddRange(new string[] { "Shirt", "Pants", "Dress","Shoes", "Handbag" });
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = "SELECT ProductID, ProductCode, Name, Price, CostPrice, Quantity, Category, Size, Color FROM Products";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProducts.DataSource = dt;
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                txtProductCode.Text = dgvProducts.CurrentRow.Cells["ProductCode"].Value.ToString();
                txtProductName.Text = dgvProducts.CurrentRow.Cells["Name"].Value.ToString();
                txtPrice.Text = dgvProducts.CurrentRow.Cells["Price"].Value.ToString();
                txtCostPrice.Text = dgvProducts.CurrentRow.Cells["CostPrice"].Value.ToString();
                txtQuantity.Text = dgvProducts.CurrentRow.Cells["Quantity"].Value.ToString();
                cboCategory.Text = dgvProducts.CurrentRow.Cells["Category"].Value.ToString();
                txtSize.Text = dgvProducts.CurrentRow.Cells["Size"].Value.ToString();
                txtColor.Text = dgvProducts.CurrentRow.Cells["Color"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtProductCode.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtCostPrice.Clear();
            txtQuantity.Clear();
            cboCategory.SelectedIndex = -1;
            txtSize.Clear();
            txtColor.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            string productCode = txtProductCode.Text.Trim();

            if (IsProductCodeExists(productCode))
            {
                MessageBox.Show("ProductCode already exists in another product. Please enter another code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductCode.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = @"INSERT INTO Products (ProductCode, Name, Price, CostPrice, Quantity, Category, Size, Color)
                                 VALUES (@code, @name, @price, @cost, @qty, @category, @size, @color)"
                ;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code", txtProductCode.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtProductName.Text.Trim());
                cmd.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
                cmd.Parameters.AddWithValue("@cost", decimal.Parse(txtCostPrice.Text));
                cmd.Parameters.AddWithValue("@qty", int.Parse(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@category", cboCategory.Text);
                cmd.Parameters.AddWithValue("@size", txtSize.Text.Trim());
                cmd.Parameters.AddWithValue("@color", txtColor.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product added successfully!");

                LoadProducts();
                ClearFields();
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to update.");
                return;
            }

            int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ProductID"].Value);
            string productCode = txtProductCode.Text.Trim();

            if (IsProductCodeExists(productCode, productId))
            {
                MessageBox.Show("ProductCode already exists in another product. Please enter another code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductCode.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = @"UPDATE Products SET
                                 ProductCode = @code,
                                 Name = @name,
                                 Price = @price,
                                 CostPrice = @cost,
                                 Quantity = @qty,
                                 Category = @category,
                                 Size = @size,
                                 Color = @color
                                 WHERE ProductID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.Parameters.AddWithValue("@code", txtProductCode.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtProductName.Text.Trim());
                cmd.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
                cmd.Parameters.AddWithValue("@cost", decimal.Parse(txtCostPrice.Text));
                cmd.Parameters.AddWithValue("@qty", int.Parse(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@category", cboCategory.Text);
                cmd.Parameters.AddWithValue("@size", txtSize.Text.Trim());
                cmd.Parameters.AddWithValue("@color", txtColor.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product updated successfully!");

                LoadProducts();
                ClearFields();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ProductID"].Value);

            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = "DELETE FROM Products WHERE ProductID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", productId);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product deleted.");

                LoadProducts();
                ClearFields();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadProducts();
            }
            else
            {
                SearchProducts(keyword);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchProducts(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = @"SELECT ProductID, ProductCode, Name, Price, CostPrice, Quantity, Category, Size, Color
                         FROM Products
                         WHERE ProductCode LIKE @keyword OR Name LIKE @keyword";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvProducts.DataSource = dt;
            }
        }


        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
