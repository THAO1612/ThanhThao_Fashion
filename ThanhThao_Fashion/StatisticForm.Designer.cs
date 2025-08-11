namespace ThanhThao_Fashion
{
    partial class StatisticForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRevenue;
        private System.Windows.Forms.TabPage tabImportedProducts;
        private System.Windows.Forms.TabPage tabProfit;
        private System.Windows.Forms.DataGridView dgvRevenue;
        private System.Windows.Forms.DataGridView dgvImported;
        private System.Windows.Forms.DataGridView dgvProfit;
        private System.Windows.Forms.Button btnLoadRevenue;
        private System.Windows.Forms.Button btnLoadImported;
        private System.Windows.Forms.Button btnLoadProfit;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabRevenue = new System.Windows.Forms.TabPage();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnLoadRevenue = new System.Windows.Forms.Button();
            this.dgvRevenue = new System.Windows.Forms.DataGridView();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabImportedProducts = new System.Windows.Forms.TabPage();
            this.btnLoadImported = new System.Windows.Forms.Button();
            this.dgvImported = new System.Windows.Forms.DataGridView();
            this.tabProfit = new System.Windows.Forms.TabPage();
            this.btnLoadProfit = new System.Windows.Forms.Button();
            this.dgvProfit = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.tabImportedProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImported)).BeginInit();
            this.tabProfit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfit)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabRevenue);
            this.tabControl.Controls.Add(this.tabImportedProducts);
            this.tabControl.Controls.Add(this.tabProfit);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 600);
            this.tabControl.TabIndex = 0;
            // 
            // tabRevenue
            // 
            this.tabRevenue.Controls.Add(this.btnBack);
            this.tabRevenue.Controls.Add(this.lblStartDate);
            this.tabRevenue.Controls.Add(this.dtpStart);
            this.tabRevenue.Controls.Add(this.lblEndDate);
            this.tabRevenue.Controls.Add(this.dtpEnd);
            this.tabRevenue.Controls.Add(this.btnLoadRevenue);
            this.tabRevenue.Controls.Add(this.dgvRevenue);
            this.tabRevenue.Controls.Add(this.chartRevenue);
            this.tabRevenue.Location = new System.Drawing.Point(4, 29);
            this.tabRevenue.Name = "tabRevenue";
            this.tabRevenue.Size = new System.Drawing.Size(992, 567);
            this.tabRevenue.TabIndex = 0;
            this.tabRevenue.Text = "Revenue Statistics";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Purple;
            this.btnBack.Location = new System.Drawing.Point(860, 521);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.ForeColor = System.Drawing.Color.Purple;
            this.lblStartDate.Location = new System.Drawing.Point(216, 20);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(85, 21);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date:";
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarForeColor = System.Drawing.Color.Purple;
            this.dtpStart.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(320, 13);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 28);
            this.dtpStart.TabIndex = 1;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.ForeColor = System.Drawing.Color.Purple;
            this.lblEndDate.Location = new System.Drawing.Point(542, 15);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(77, 21);
            this.lblEndDate.TabIndex = 2;
            this.lblEndDate.Text = "End Date:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(636, 10);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 28);
            this.dtpEnd.TabIndex = 3;
            // 
            // btnLoadRevenue
            // 
            this.btnLoadRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadRevenue.ForeColor = System.Drawing.Color.Purple;
            this.btnLoadRevenue.Location = new System.Drawing.Point(20, 15);
            this.btnLoadRevenue.Name = "btnLoadRevenue";
            this.btnLoadRevenue.Size = new System.Drawing.Size(130, 31);
            this.btnLoadRevenue.TabIndex = 4;
            this.btnLoadRevenue.Text = "Load Revenue";
            this.btnLoadRevenue.UseVisualStyleBackColor = false;
            this.btnLoadRevenue.Click += new System.EventHandler(this.btnLoadRevenue_Click);
            // 
            // dgvRevenue
            // 
            this.dgvRevenue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRevenue.ColumnHeadersHeight = 29;
            this.dgvRevenue.Location = new System.Drawing.Point(20, 60);
            this.dgvRevenue.Name = "dgvRevenue";
            this.dgvRevenue.RowHeadersWidth = 51;
            this.dgvRevenue.Size = new System.Drawing.Size(450, 400);
            this.dgvRevenue.TabIndex = 5;
            // 
            // chartRevenue
            // 
            this.chartRevenue.Location = new System.Drawing.Point(500, 60);
            this.chartRevenue.Name = "chartRevenue";
            this.chartRevenue.Size = new System.Drawing.Size(460, 400);
            this.chartRevenue.TabIndex = 6;
            // 
            // tabImportedProducts
            // 
            this.tabImportedProducts.Controls.Add(this.btnLoadImported);
            this.tabImportedProducts.Controls.Add(this.dgvImported);
            this.tabImportedProducts.Location = new System.Drawing.Point(4, 29);
            this.tabImportedProducts.Name = "tabImportedProducts";
            this.tabImportedProducts.Size = new System.Drawing.Size(992, 567);
            this.tabImportedProducts.TabIndex = 1;
            this.tabImportedProducts.Text = "Imported Products";
            // 
            // btnLoadImported
            // 
            this.btnLoadImported.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadImported.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImported.ForeColor = System.Drawing.Color.Purple;
            this.btnLoadImported.Location = new System.Drawing.Point(20, 10);
            this.btnLoadImported.Name = "btnLoadImported";
            this.btnLoadImported.Size = new System.Drawing.Size(130, 32);
            this.btnLoadImported.TabIndex = 4;
            this.btnLoadImported.Text = "Load Products";
            this.btnLoadImported.UseCompatibleTextRendering = true;
            this.btnLoadImported.UseVisualStyleBackColor = false;
            this.btnLoadImported.Click += new System.EventHandler(this.btnLoadImported_Click);
            // 
            // dgvImported
            // 
            this.dgvImported.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvImported.ColumnHeadersHeight = 29;
            this.dgvImported.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvImported.Location = new System.Drawing.Point(0, 67);
            this.dgvImported.Name = "dgvImported";
            this.dgvImported.RowHeadersWidth = 51;
            this.dgvImported.Size = new System.Drawing.Size(992, 500);
            this.dgvImported.TabIndex = 1;
            this.dgvImported.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImported_CellContentClick);
            // 
            // tabProfit
            // 
            this.tabProfit.Controls.Add(this.btnLoadProfit);
            this.tabProfit.Controls.Add(this.dgvProfit);
            this.tabProfit.Location = new System.Drawing.Point(4, 29);
            this.tabProfit.Name = "tabProfit";
            this.tabProfit.Size = new System.Drawing.Size(992, 567);
            this.tabProfit.TabIndex = 2;
            this.tabProfit.Text = "Profit Statistics";
            // 
            // btnLoadProfit
            // 
            this.btnLoadProfit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadProfit.ForeColor = System.Drawing.Color.Purple;
            this.btnLoadProfit.Location = new System.Drawing.Point(17, 12);
            this.btnLoadProfit.Name = "btnLoadProfit";
            this.btnLoadProfit.Size = new System.Drawing.Size(130, 34);
            this.btnLoadProfit.TabIndex = 0;
            this.btnLoadProfit.Text = "Load Profit";
            this.btnLoadProfit.UseVisualStyleBackColor = false;
            this.btnLoadProfit.Click += new System.EventHandler(this.btnLoadProfit_Click);
            // 
            // dgvProfit
            // 
            this.dgvProfit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProfit.ColumnHeadersHeight = 29;
            this.dgvProfit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProfit.Location = new System.Drawing.Point(0, 67);
            this.dgvProfit.Name = "dgvProfit";
            this.dgvProfit.RowHeadersWidth = 51;
            this.dgvProfit.Size = new System.Drawing.Size(992, 500);
            this.dgvProfit.TabIndex = 1;
            // 
            // StatisticForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl);
            this.Name = "StatisticForm";
            this.Text = "Statistics";
            this.tabControl.ResumeLayout(false);
            this.tabRevenue.ResumeLayout(false);
            this.tabRevenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.tabImportedProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImported)).EndInit();
            this.tabProfit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfit)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
