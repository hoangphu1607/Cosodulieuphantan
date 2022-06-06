namespace Cosodulieuphantan
{
    partial class PhanTanNgang
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_values = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bieuthuc = new System.Windows.Forms.ComboBox();
            this.columns = new System.Windows.Forms.ComboBox();
            this.combo_table = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_query = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Bảng Phân Tán";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cột";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(537, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 44);
            this.button1.TabIndex = 5;
            this.button1.Text = "Thêm Điều Kiện";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_values);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bieuthuc);
            this.groupBox1.Controls.Add(this.columns);
            this.groupBox1.Controls.Add(this.combo_table);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(839, 308);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phân Tán Theo Chiều Ngang";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(300, 232);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 37);
            this.button3.TabIndex = 16;
            this.button3.Text = "test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(586, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 29);
            this.label5.TabIndex = 15;
            this.label5.Text = "Giá Trị";
            // 
            // txt_values
            // 
            this.txt_values.Location = new System.Drawing.Point(467, 135);
            this.txt_values.Multiline = true;
            this.txt_values.Name = "txt_values";
            this.txt_values.Size = new System.Drawing.Size(340, 100);
            this.txt_values.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Điều Kiện";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // bieuthuc
            // 
            this.bieuthuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bieuthuc.FormattingEnabled = true;
            this.bieuthuc.Items.AddRange(new object[] {
            ">",
            "<",
            ">=",
            "<=",
            "="});
            this.bieuthuc.Location = new System.Drawing.Point(275, 167);
            this.bieuthuc.Name = "bieuthuc";
            this.bieuthuc.Size = new System.Drawing.Size(121, 37);
            this.bieuthuc.TabIndex = 12;
            // 
            // columns
            // 
            this.columns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columns.FormattingEnabled = true;
            this.columns.Location = new System.Drawing.Point(9, 167);
            this.columns.Name = "columns";
            this.columns.Size = new System.Drawing.Size(242, 37);
            this.columns.TabIndex = 11;
            this.columns.SelectedIndexChanged += new System.EventHandler(this.columns_SelectedIndexChanged);
            // 
            // combo_table
            // 
            this.combo_table.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_table.FormattingEnabled = true;
            this.combo_table.Location = new System.Drawing.Point(352, 55);
            this.combo_table.Name = "combo_table";
            this.combo_table.Size = new System.Drawing.Size(212, 37);
            this.combo_table.TabIndex = 10;
            this.combo_table.SelectedIndexChanged += new System.EventHandler(this.combo_table_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column,
            this.Bt,
            this.value});
            this.dataGridView1.Location = new System.Drawing.Point(30, 343);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(839, 150);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.AllowUserToAddRowsChanged += new System.EventHandler(this.dataGridView1_AllowUserToAddRowsChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // column
            // 
            this.column.HeaderText = "Cột";
            this.column.MinimumWidth = 6;
            this.column.Name = "column";
            // 
            // Bt
            // 
            this.Bt.HeaderText = "Biểu Thức";
            this.Bt.MinimumWidth = 6;
            this.Bt.Name = "Bt";
            // 
            // value
            // 
            this.value.HeaderText = "Giá Trị";
            this.value.MinimumWidth = 6;
            this.value.Name = "value";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(931, 553);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(220, 44);
            this.button2.TabIndex = 14;
            this.button2.Text = "CHỌN LIÊN KẾT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_query);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(892, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 518);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Câu Lệnh";
            // 
            // txt_query
            // 
            this.txt_query.Location = new System.Drawing.Point(6, 26);
            this.txt_query.Multiline = true;
            this.txt_query.Name = "txt_query";
            this.txt_query.Size = new System.Drawing.Size(274, 486);
            this.txt_query.TabIndex = 15;
            // 
            // PhanTanNgang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 645);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PhanTanNgang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân Tán Theo Chiều Ngang";
            this.Load += new System.EventHandler(this.PhanTanNgang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox combo_table;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox bieuthuc;
        private System.Windows.Forms.ComboBox columns;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_values;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bt;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_query;
    }
}