using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace ThanhThao_Fashion
{
    public partial class StatisticForm : Form
    {
        private string connectionString = @"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;";

        public StatisticForm()
        {
            InitializeComponent();
        }

        private void StatisticForm_Load(object sender, EventArgs e)
        {
            // Set auto size for all DGVs
            SetupDataGridView(dgvImported);
            SetupDataGridView(dgvRevenue);
            SetupDataGridView(dgvProfit);
        }

        private void SetupDataGridView(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightPink;
            dgv.EnableHeadersVisualStyles = false;
        }

        private void btnLoadImported_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = @"SELECT p.ProductID, p.Name AS ProductName, SUM(i.Quantity) AS TotalImported
                                 FROM Inventory i
                                 INNER JOIN Products p ON i.ProductID = p.ProductID
                                 WHERE i.Type = 'In'
                                 GROUP BY p.ProductID, p.Name
                                 ORDER BY p.ProductID";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvImported.DataSource = dt;
            }
        }

        private void btnLoadRevenue_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {

                DateTime startDate = dtpStart.Value.Date;
                DateTime endDate = dtpEnd.Value.Date;

                string query = @"SELECT CAST(OrderDate AS DATE) AS OrderDate, 
                                SUM(TotalAmount) AS TotalRevenue
                         FROM Orders
                         WHERE CAST(OrderDate AS DATE) BETWEEN @StartDate AND @EndDate
                         GROUP BY CAST(OrderDate AS DATE)
                         ORDER BY OrderDate";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRevenue.DataSource = dt;

                // --- Cấu hình chart ---
                chartRevenue.Series.Clear();
                chartRevenue.ChartAreas.Clear();

                var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea("ChartArea1");
                chartRevenue.ChartAreas.Add(chartArea);

                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Revenue");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;

                foreach (DataRow row in dt.Rows)
                {
                    DateTime date = Convert.ToDateTime(row["OrderDate"]);
                    double revenue = Convert.ToDouble(row["TotalRevenue"]);
                    series.Points.AddXY(date, revenue);
                }

                chartRevenue.Series.Add(series);
                chartRevenue.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy";
                chartRevenue.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
                chartRevenue.ChartAreas[0].AxisX.Interval = 1;
                chartRevenue.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;

                chartRevenue.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                chartRevenue.ChartAreas[0].AxisY.Title = "Revenue";
            }
        }

        private void btnLoadProfit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-B8M27H71\MSSQLSERVER02;Database=ThanhThaoFashion;Integrated Security=true;"))
            {
                string query = @"SELECT p.ProductID, p.Name AS ProductName, e.FullName AS EmployeeName,
                                        SUM((od.UnitPrice - p.CostPrice) * od.Quantity) AS Profit
                                 FROM Orders o
                                 INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
                                 INNER JOIN Products p ON od.ProductID = p.ProductID
                                 INNER JOIN Employees e ON o.EmpID = e.EmpID
                                 GROUP BY p.ProductID, p.Name, e.FullName
                                 ORDER BY Profit DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProfit.DataSource = dt;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm(1, "Admin", "Admin");
            mainForm.Show();
        }


    }
}
