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
    public partial class LienKet : Form
    {
        public LienKet()
        {
            InitializeComponent();
        }

        private void LienKet_Load(object sender, EventArgs e)
        {
            DBConnect mysql = new DBConnect();
            mysql.OpenConnection();
            table_lk.DisplayMember = "Tables_in_quanlyhaisan";
            table_lk.ValueMember = "Tables_in_quanlyhaisan";
            table_lk.DataSource = mysql.LoadComboBox("SHOW tables");
            mysql.CloseConnection();

            mysql.OpenConnection();
            table_clk.DisplayMember = "Tables_in_quanlyhaisan";
            table_clk.ValueMember = "Tables_in_quanlyhaisan";
            table_clk.DataSource = mysql.LoadComboBox("SHOW tables");
            mysql.CloseConnection();

            string table_LK = table_lk.SelectedValue.ToString();
            string table_CLK = table_clk.SelectedValue.ToString();

            mysql.OpenConnection();
            column_lk.DisplayMember = "Field";
            column_lk.ValueMember = "Field";
            column_lk.DataSource = mysql.LoadComboBox("DESCRIBE " + table_LK + "");
            mysql.CloseConnection();

            mysql.OpenConnection();
            column_clk.DisplayMember = "Field";
            column_clk.ValueMember = "Field";
            column_clk.DataSource = mysql.LoadComboBox("DESCRIBE " + table_CLK + "");
            mysql.CloseConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string table1 = table_lk.SelectedValue.ToString() + "." + column_lk.SelectedValue.ToString();
            string table2 = table_clk.SelectedValue.ToString() + "." + column_clk.SelectedValue.ToString();

            this.dataGridView2.Rows.Add(table1, table2);
        }

        private void table_lk_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table = table_lk.SelectedValue.ToString();

            DBConnect mysql = new DBConnect();
            mysql.OpenConnection();
            column_lk.DisplayMember = "Field";
            column_lk.ValueMember = "Field";
            column_lk.DataSource = mysql.LoadComboBox("DESCRIBE " + table + "");
            mysql.CloseConnection();
        }

        private void table_clk_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table = table_clk.SelectedValue.ToString();

            DBConnect mysql = new DBConnect();
            mysql.OpenConnection();
            column_clk.DisplayMember = "Field";
            column_clk.ValueMember = "Field";
            column_clk.DataSource = mysql.LoadComboBox("DESCRIBE " + table + "");
            mysql.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Connection con = new Connection();
                DBConnect connect = new DBConnect();
                con.openConn();
                con.executeUpdate(PhanTanNgang.query);
                con.closeConn();
                string value = "",que = "";
                List<string> list = new List<string>();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        value = cell.Value.ToString();
                        string[] arrListStr = value.Split('.');
                        list.Add(arrListStr[0]);
                        list.Add(arrListStr[1]);
                    }
                    //Lấy cột của bảng cần phân tán thành list
                    connect.OpenConnection();
                    DataTable dataTable= connect.LoadComboBox("DESCRIBE " + list[2] + "");
                    List<string> data = new List<string>();
                    data = dataTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("Field")).ToList();
                    //ép các cột của bảng thành string
                    string select_table = "";
                    for(int i =0; i< dataTable.Rows.Count; i++)
                    {
                        if(i == dataTable.Rows.Count - 1)
                        {
                            select_table += list[2] + "." + data[i];
                        }else
                        select_table += list[2] + "." + data[i]+",";
                    }
                    connect.CloseConnection();
                    que = "select "+ select_table + " into " + list[2] +" from OPENQUERY(ConnectLan, " +
                        "'SELECT * FROM quanlyhaisan."+list[2]+ "') " + list[2] + "," + list[0] + " where " + list[0]+"."+ list[1] + " = "+list[2]+ "." + list[3] + "";
                    
                    con.openConn();
                    con.executeUpdate(que);
                    con.closeConn();
                    list.Clear();
                }
                MessageBox.Show("Phân Tán Thành Công");
            }
            catch
            {
                Connection con = new Connection();
                con.openConn();
                con.executeUpdate("EXEC sp_MSforeachtable @command1 = 'DROP TABLE ? ''");
                con.closeConn();
                
                MessageBox.Show("Phân Tán Thất Bại");
            }
        }
    }
}
