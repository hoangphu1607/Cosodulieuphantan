using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosodulieuphantan
{
    public partial class ChonKieuPhanTan : Form
    {
        public static string database;
        public ChonKieuPhanTan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            PhanTanNgang formPhantan = new PhanTanNgang();
            formPhantan.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            test formPhantan = new test();
            formPhantan.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txt_tk.Text;
            string pass = txt_mk.Text;
            Connection conn = new Connection(user, pass);
            if (conn.openConn())
            {
                MessageBox.Show("Kết Nối Thành Công");
                listDB.Visible = true;
                conn.openConn();
                listDB.DisplayMember = "name";
                listDB.ValueMember = "name";
                listDB.DataSource =  conn.loadDataTable("SELECT name FROM sys.databases;");
                conn.closeConn();
                label5.Visible = true;
                button4.Visible = true;
            }
            else
            {
                MessageBox.Show("Kết Nối Thất Bại");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormData formData = new FormData();
            formData.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            connect.openConn();
            DataTable dataTable = connect.loadDataTable("SELECT name FROM sys.databases;");
            List<string> data = new List<string>();
            data = dataTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("name")).ToList();
            connect.closeConn();

            int index = data.LastIndexOf(listDB.Text);
            if (index == -1)
            {
                try
                {
                    kieu_phan_tan.Visible = true;
                    database = listDB.Text;
                    connect.openConn();
                    connect.executeUpdate("CREATE DATABASE "+database+"");
                    connect.closeConn();
                    MessageBox.Show("Tạo database " + database + " thành công");
                }
                catch
                {
                    MessageBox.Show("Chọn Database Thất Bại");
                }
                
            }
            else
            {
                try
                {
                    kieu_phan_tan.Visible = true;
                    database = listDB.Text;
                }
                catch
                {
                    MessageBox.Show("Chọn Database Thất Bại");
                }
            }
        }

        private void ChonKieuPhanTan_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
