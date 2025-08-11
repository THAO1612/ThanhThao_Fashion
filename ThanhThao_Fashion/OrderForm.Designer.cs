namespace ThanhThao_Fashion
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblCustomer, lblEmployee, lblDate, lblTotal, lblDiscount, lblStatus, lblPayment, lblSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(15, 37);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(760, 250);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);
            // 
            // cboCustomer
            // 
            this.cboCustomer.ForeColor = System.Drawing.Color.Purple;
            this.cboCustomer.Location = new System.Drawing.Point(105, 310);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(250, 24);
            this.cboCustomer.TabIndex = 1;
            // 
            // cboEmployee
            // 
            this.cboEmployee.ForeColor = System.Drawing.Color.Purple;
            this.cboEmployee.Location = new System.Drawing.Point(105, 340);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(250, 24);
            this.cboEmployee.TabIndex = 2;
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.CalendarForeColor = System.Drawing.Color.Purple;
            this.dtpOrderDate.Location = new System.Drawing.Point(105, 370);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(250, 22);
            this.dtpOrderDate.TabIndex = 3;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.ForeColor = System.Drawing.Color.Purple;
            this.txtTotalAmount.Location = new System.Drawing.Point(105, 400);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(250, 22);
            this.txtTotalAmount.TabIndex = 4;
            // 
            // txtDiscount
            // 
            this.txtDiscount.ForeColor = System.Drawing.Color.Purple;
            this.txtDiscount.Location = new System.Drawing.Point(105, 433);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(250, 22);
            this.txtDiscount.TabIndex = 5;
            // 
            // cboStatus
            // 
            this.cboStatus.ForeColor = System.Drawing.Color.Purple;
            this.cboStatus.Location = new System.Drawing.Point(495, 310);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(200, 24);
            this.cboStatus.TabIndex = 6;
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.ForeColor = System.Drawing.Color.Purple;
            this.cboPaymentMethod.Location = new System.Drawing.Point(495, 340);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(200, 24);
            this.cboPaymentMethod.TabIndex = 7;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.ForeColor = System.Drawing.Color.Purple;
            this.txtSearch.Location = new System.Drawing.Point(495, 392);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 22);
            this.txtSearch.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAdd.ForeColor = System.Drawing.Color.Purple;
            this.btnAdd.Location = new System.Drawing.Point(404, 445);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 32);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEdit.ForeColor = System.Drawing.Color.Purple;
            this.btnEdit.Location = new System.Drawing.Point(489, 445);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 32);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Update";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDelete.ForeColor = System.Drawing.Color.Purple;
            this.btnDelete.Location = new System.Drawing.Point(569, 445);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 32);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnViewDetails.ForeColor = System.Drawing.Color.Purple;
            this.btnViewDetails.Location = new System.Drawing.Point(650, 445);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(112, 32);
            this.btnViewDetails.TabIndex = 12;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click_1);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSearch.ForeColor = System.Drawing.Color.Purple;
            this.btnSearch.Location = new System.Drawing.Point(705, 385);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 36);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // lblCustomer
            // 
            this.lblCustomer.ForeColor = System.Drawing.Color.Purple;
            this.lblCustomer.Location = new System.Drawing.Point(17, 313);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(100, 23);
            this.lblCustomer.TabIndex = 14;
            this.lblCustomer.Text = "Customer:";
            // 
            // lblEmployee
            // 
            this.lblEmployee.ForeColor = System.Drawing.Color.Purple;
            this.lblEmployee.Location = new System.Drawing.Point(17, 343);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(100, 23);
            this.lblEmployee.TabIndex = 15;
            this.lblEmployee.Text = "Employee:";
            // 
            // lblDate
            // 
            this.lblDate.ForeColor = System.Drawing.Color.Purple;
            this.lblDate.Location = new System.Drawing.Point(17, 373);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 23);
            this.lblDate.TabIndex = 16;
            this.lblDate.Text = "Order Date:";
            // 
            // lblTotal
            // 
            this.lblTotal.ForeColor = System.Drawing.Color.Purple;
            this.lblTotal.Location = new System.Drawing.Point(17, 403);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "Total Amount:";
            // 
            // lblDiscount
            // 
            this.lblDiscount.ForeColor = System.Drawing.Color.Purple;
            this.lblDiscount.Location = new System.Drawing.Point(17, 433);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(100, 23);
            this.lblDiscount.TabIndex = 18;
            this.lblDiscount.Text = "Discount (%):";
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.Purple;
            this.lblStatus.Location = new System.Drawing.Point(405, 313);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Status:";
            // 
            // lblPayment
            // 
            this.lblPayment.ForeColor = System.Drawing.Color.Purple;
            this.lblPayment.Location = new System.Drawing.Point(405, 343);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(100, 23);
            this.lblPayment.TabIndex = 20;
            this.lblPayment.Text = "Payment Method:";
            // 
            // lblSearch
            // 
            this.lblSearch.ForeColor = System.Drawing.Color.Purple;
            this.lblSearch.Location = new System.Drawing.Point(405, 395);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(100, 23);
            this.lblSearch.TabIndex = 21;
            this.lblSearch.Text = "Search:";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBack.ForeColor = System.Drawing.Color.Purple;
            this.btnBack.Location = new System.Drawing.Point(700, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 29);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // OrderForm
            // 
            this.ClientSize = new System.Drawing.Size(793, 489);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.cboEmployee);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.cboPaymentMethod);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPayment);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnBack);
            this.Name = "OrderForm";
            this.Text = "Order Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
