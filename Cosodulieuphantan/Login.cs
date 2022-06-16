using Grpc.Core;
using Microsoft.SqlServer.Management.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosodulieuphantan
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uid = txt_tk.Text;
            string password = txt_mk.Text;
            DBConnect mysql = new DBConnect(uid,password);
            if (mysql.OpenConnection())
            {
                MessageBox.Show("Kết Nối Với Máy Chủ "+label4.Text+" Thành Công");
                this.Hide();
                ChonKieuPhanTan formPhantan = new ChonKieuPhanTan();
                formPhantan.Show();
                //ChonBang cb = new ChonBang();
                //cb.Show();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bnt_thoat_Click(object sender, EventArgs e)
        {
            //DBConnect mysql = new DBConnect();
            //List<string> list = new List<string>();
            ////if (mysql.OpenConnection())
            ////{
            //    var b = mysql.Select();
            //    string id = b[0].ToString();
            //    //MessageBox.Show("Kết Nối Thành Công");
            //    MessageBox.Show(id);
            ////}
            ////MySql mySql = new MySql();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //DBConnect mysql = new DBConnect();
            //if (mysql.OpenConnection())
            //{               
            //    MessageBox.Show("Kết Nối Thành Công");                
            //}
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
