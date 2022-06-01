namespace Cosodulieuphantan
{
    partial class ChonKieuPhanTan
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_test_conn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_mk = new System.Windows.Forms.TextBox();
            this.txt_tk = new System.Windows.Forms.TextBox();
            this.kieu_phan_tan = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.kieu_phan_tan.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_test_conn);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_mk);
            this.groupBox2.Controls.Add(this.txt_tk);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(94, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 247);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Phân Tán";
            // 
            // btn_test_conn
            // 
            this.btn_test_conn.Location = new System.Drawing.Point(204, 192);
            this.btn_test_conn.Name = "btn_test_conn";
            this.btn_test_conn.Size = new System.Drawing.Size(130, 36);
            this.btn_test_conn.TabIndex = 2;
            this.btn_test_conn.Text = "Kết Nối";
            this.btn_test_conn.UseVisualStyleBackColor = true;
            this.btn_test_conn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "TÊN SERVER Ở ĐÂY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Mật Khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tài Khoản";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tên Server";
            // 
            // txt_mk
            // 
            this.txt_mk.Location = new System.Drawing.Point(186, 143);
            this.txt_mk.Name = "txt_mk";
            this.txt_mk.Size = new System.Drawing.Size(353, 30);
            this.txt_mk.TabIndex = 10;
            this.txt_mk.UseSystemPasswordChar = true;
            // 
            // txt_tk
            // 
            this.txt_tk.Location = new System.Drawing.Point(186, 100);
            this.txt_tk.Name = "txt_tk";
            this.txt_tk.Size = new System.Drawing.Size(353, 30);
            this.txt_tk.TabIndex = 9;
            // 
            // kieu_phan_tan
            // 
            this.kieu_phan_tan.Controls.Add(this.button3);
            this.kieu_phan_tan.Controls.Add(this.button2);
            this.kieu_phan_tan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kieu_phan_tan.Location = new System.Drawing.Point(94, 288);
            this.kieu_phan_tan.Name = "kieu_phan_tan";
            this.kieu_phan_tan.Size = new System.Drawing.Size(570, 100);
            this.kieu_phan_tan.TabIndex = 2;
            this.kieu_phan_tan.TabStop = false;
            this.kieu_phan_tan.Text = "Kiểu Phân Tán";
            this.kieu_phan_tan.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(328, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(175, 46);
            this.button3.TabIndex = 1;
            this.button3.Text = "Phân Tán Dọc";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(45, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(211, 46);
            this.button2.TabIndex = 0;
            this.button2.Text = "Phân Tán Ngang";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ChonKieuPhanTan
            // 
            this.AcceptButton = this.btn_test_conn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 450);
            this.Controls.Add(this.kieu_phan_tan);
            this.Controls.Add(this.groupBox2);
            this.Name = "ChonKieuPhanTan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChonKieuPhanTan";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.kieu_phan_tan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_mk;
        private System.Windows.Forms.TextBox txt_tk;
        private System.Windows.Forms.Button btn_test_conn;
        private System.Windows.Forms.GroupBox kieu_phan_tan;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}