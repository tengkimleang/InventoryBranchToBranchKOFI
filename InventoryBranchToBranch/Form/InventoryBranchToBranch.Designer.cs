namespace InventoryBranchToBranch
{
    partial class InventoryBranchToBranch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDocDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cboSeriesGoodReceipt = new System.Windows.Forms.ComboBox();
            this.txtRefGoodReceipt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocNumGoodReceipt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUploadExcelFile = new System.Windows.Forms.Button();
            this.cboSeries = new System.Windows.Forms.ComboBox();
            this.txtRefGoodIssue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaxNumberGoodIssue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.cboPriceList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboGoodReceiptBranch = new System.Windows.Forms.ComboBox();
            this.cboGoodIssueBranch = new System.Windows.Forms.ComboBox();
            this.txtWhsTo = new System.Windows.Forms.TextBox();
            this.txtWhsFrom = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtWhsTo);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dtpDocDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboSeriesGoodReceipt);
            this.groupBox1.Controls.Add(this.cboGoodReceiptBranch);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtRefGoodReceipt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDocNumGoodReceipt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(445, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(405, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Good Receipt";
            // 
            // dtpDocDate
            // 
            this.dtpDocDate.CustomFormat = "dd.MM.yyyy";
            this.dtpDocDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDocDate.Location = new System.Drawing.Point(158, 88);
            this.dtpDocDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDocDate.Name = "dtpDocDate";
            this.dtpDocDate.Size = new System.Drawing.Size(240, 26);
            this.dtpDocDate.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 91);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 18);
            this.label11.TabIndex = 15;
            this.label11.Text = "Document Date";
            // 
            // cboSeriesGoodReceipt
            // 
            this.cboSeriesGoodReceipt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeriesGoodReceipt.FormattingEnabled = true;
            this.cboSeriesGoodReceipt.Location = new System.Drawing.Point(158, 26);
            this.cboSeriesGoodReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.cboSeriesGoodReceipt.Name = "cboSeriesGoodReceipt";
            this.cboSeriesGoodReceipt.Size = new System.Drawing.Size(240, 26);
            this.cboSeriesGoodReceipt.TabIndex = 14;
            // 
            // txtRefGoodReceipt
            // 
            this.txtRefGoodReceipt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefGoodReceipt.Location = new System.Drawing.Point(158, 176);
            this.txtRefGoodReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.txtRefGoodReceipt.Name = "txtRefGoodReceipt";
            this.txtRefGoodReceipt.Size = new System.Drawing.Size(240, 26);
            this.txtRefGoodReceipt.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 179);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ref2";
            // 
            // txtDocNumGoodReceipt
            // 
            this.txtDocNumGoodReceipt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocNumGoodReceipt.Location = new System.Drawing.Point(158, 56);
            this.txtDocNumGoodReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.txtDocNumGoodReceipt.Name = "txtDocNumGoodReceipt";
            this.txtDocNumGoodReceipt.Size = new System.Drawing.Size(240, 26);
            this.txtDocNumGoodReceipt.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Series";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUploadExcelFile);
            this.groupBox2.Controls.Add(this.txtWhsFrom);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cboSeries);
            this.groupBox2.Controls.Add(this.cboGoodIssueBranch);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtRefGoodIssue);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboPriceList);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtMaxNumberGoodIssue);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(9, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(417, 251);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Good Issue";
            // 
            // btnUploadExcelFile
            // 
            this.btnUploadExcelFile.Location = new System.Drawing.Point(290, 210);
            this.btnUploadExcelFile.Name = "btnUploadExcelFile";
            this.btnUploadExcelFile.Size = new System.Drawing.Size(112, 31);
            this.btnUploadExcelFile.TabIndex = 21;
            this.btnUploadExcelFile.Text = "Upload Excel File";
            this.btnUploadExcelFile.UseVisualStyleBackColor = true;
            this.btnUploadExcelFile.Click += new System.EventHandler(this.btnUploadExcelFile_Click);
            // 
            // cboSeries
            // 
            this.cboSeries.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeries.FormattingEnabled = true;
            this.cboSeries.Location = new System.Drawing.Point(163, 26);
            this.cboSeries.Margin = new System.Windows.Forms.Padding(2);
            this.cboSeries.Name = "cboSeries";
            this.cboSeries.Size = new System.Drawing.Size(240, 26);
            this.cboSeries.TabIndex = 12;
            // 
            // txtRefGoodIssue
            // 
            this.txtRefGoodIssue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefGoodIssue.Location = new System.Drawing.Point(163, 179);
            this.txtRefGoodIssue.Margin = new System.Windows.Forms.Padding(2);
            this.txtRefGoodIssue.Name = "txtRefGoodIssue";
            this.txtRefGoodIssue.Size = new System.Drawing.Size(240, 26);
            this.txtRefGoodIssue.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 181);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ref2";
            // 
            // txtMaxNumberGoodIssue
            // 
            this.txtMaxNumberGoodIssue.Enabled = false;
            this.txtMaxNumberGoodIssue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxNumberGoodIssue.Location = new System.Drawing.Point(163, 56);
            this.txtMaxNumberGoodIssue.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaxNumberGoodIssue.Name = "txtMaxNumberGoodIssue";
            this.txtMaxNumberGoodIssue.Size = new System.Drawing.Size(240, 26);
            this.txtMaxNumberGoodIssue.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 58);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "Series";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 278);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(839, 283);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(9, 570);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboPriceList
            // 
            this.cboPriceList.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPriceList.FormattingEnabled = true;
            this.cboPriceList.Location = new System.Drawing.Point(163, 85);
            this.cboPriceList.Margin = new System.Windows.Forms.Padding(2);
            this.cboPriceList.Name = "cboPriceList";
            this.cboPriceList.Size = new System.Drawing.Size(240, 26);
            this.cboPriceList.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 88);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "PriceList";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 119);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "From Branch";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 152);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 18);
            this.label13.TabIndex = 19;
            this.label13.Text = "WhsCode From";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 119);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 18);
            this.label10.TabIndex = 12;
            this.label10.Text = "From Branch";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 150);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 18);
            this.label12.TabIndex = 17;
            this.label12.Text = "WhsCode To";
            // 
            // cboGoodReceiptBranch
            // 
            this.cboGoodReceiptBranch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGoodReceiptBranch.FormattingEnabled = true;
            this.cboGoodReceiptBranch.Location = new System.Drawing.Point(158, 117);
            this.cboGoodReceiptBranch.Margin = new System.Windows.Forms.Padding(2);
            this.cboGoodReceiptBranch.Name = "cboGoodReceiptBranch";
            this.cboGoodReceiptBranch.Size = new System.Drawing.Size(240, 26);
            this.cboGoodReceiptBranch.TabIndex = 13;
            this.cboGoodReceiptBranch.SelectedValueChanged += new System.EventHandler(this.cboGoodReceiptBranch_SelectedValueChanged);
            // 
            // cboGoodIssueBranch
            // 
            this.cboGoodIssueBranch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGoodIssueBranch.FormattingEnabled = true;
            this.cboGoodIssueBranch.Location = new System.Drawing.Point(163, 117);
            this.cboGoodIssueBranch.Margin = new System.Windows.Forms.Padding(2);
            this.cboGoodIssueBranch.Name = "cboGoodIssueBranch";
            this.cboGoodIssueBranch.Size = new System.Drawing.Size(240, 26);
            this.cboGoodIssueBranch.TabIndex = 11;
            this.cboGoodIssueBranch.SelectedValueChanged += new System.EventHandler(this.cboGoodIssueBranch_SelectedValueChanged);
            // 
            // txtWhsTo
            // 
            this.txtWhsTo.Enabled = false;
            this.txtWhsTo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWhsTo.Location = new System.Drawing.Point(158, 147);
            this.txtWhsTo.Margin = new System.Windows.Forms.Padding(2);
            this.txtWhsTo.Name = "txtWhsTo";
            this.txtWhsTo.Size = new System.Drawing.Size(240, 26);
            this.txtWhsTo.TabIndex = 18;
            // 
            // txtWhsFrom
            // 
            this.txtWhsFrom.Enabled = false;
            this.txtWhsFrom.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWhsFrom.Location = new System.Drawing.Point(163, 150);
            this.txtWhsFrom.Margin = new System.Windows.Forms.Padding(2);
            this.txtWhsFrom.Name = "txtWhsFrom";
            this.txtWhsFrom.Size = new System.Drawing.Size(240, 26);
            this.txtWhsFrom.TabIndex = 20;
            // 
            // InventoryBranchToBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(859, 609);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "InventoryBranchToBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InventoryBranchToBranch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDocNumGoodReceipt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRefGoodReceipt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRefGoodIssue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaxNumberGoodIssue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboSeriesGoodReceipt;
        private System.Windows.Forms.ComboBox cboSeries;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpDocDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUploadExcelFile;
        private System.Windows.Forms.TextBox txtWhsTo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboGoodReceiptBranch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtWhsFrom;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboGoodIssueBranch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboPriceList;
        private System.Windows.Forms.Label label6;
    }
}