
namespace Cosodulieuphantan
{
    partial class Login
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
            this.txt_tk = new System.Windows.Forms.TextBox();
            this.txt_mk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.bnt_thoat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_tk
            // 
            this.txt_tk.Location = new System.Drawing.Point(240, 116);
            this.txt_tk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_tk.Name = "txt_tk";
            this.txt_tk.Size = new System.Drawing.Size(242, 30);
            this.txt_tk.TabIndex = 1;
            // 
            // txt_mk
            // 
            this.txt_mk.Location = new System.Drawing.Point(240, 188);
            this.txt_mk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_mk.Name = "txt_mk";
            this.txt_mk.Size = new System.Drawing.Size(242, 30);
            this.txt_mk.TabIndex = 2;
            this.txt_mk.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "MÁY CHỦ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "TÀI KHOẢN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 188);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "MẬT KHẨU";
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.Location = new System.Drawing.Point(107, 266);
            this.btn_dangnhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(176, 59);
            this.btn_dangnhap.TabIndex = 6;
            this.btn_dangnhap.Text = "KẾT NỐI";
            this.btn_dangnhap.UseVisualStyleBackColor = true;
            this.btn_dangnhap.Click += new System.EventHandler(this.button1_Click);
            // 
            // bnt_thoat
            // 
            this.bnt_thoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnt_thoat.Location = new System.Drawing.Point(336, 266);
            this.bnt_thoat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnt_thoat.Name = "bnt_thoat";
            this.bnt_thoat.Size = new System.Drawing.Size(146, 59);
            this.bnt_thoat.TabIndex = 7;
            this.bnt_thoat.Text = "THOÁT";
            this.bnt_thoat.UseVisualStyleBackColor = true;
            this.bnt_thoat.Click += new System.EventHandler(this.bnt_thoat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(236, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "25.7.45.184 | quanlyhaisan";
            // 
            // Login
            // 
            this.AcceptButton = this.btn_dangnhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnt_thoat;
            this.ClientSize = new System.Drawing.Size(592, 409);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bnt_thoat);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_mk);
            this.Controls.Add(this.txt_tk);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_tk;
        private System.Windows.Forms.TextBox txt_mk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.Button bnt_thoat;
        private System.Windows.Forms.Label label4;
    }
}

