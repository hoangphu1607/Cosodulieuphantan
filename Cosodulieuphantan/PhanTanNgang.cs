using MySql.Data.MySqlClient;
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
    public partial class PhanTanNgang : Form
    {
        public static string query;
        public static string GetTable;
        public static string GetColumn;
        public static string first_text_query = "SELECT  * INTO ";
        public static string end_text_query = " FROM OPENQUERY(ConnectLan, 'SELECT * FROM quanlyhaisan.";
        public PhanTanNgang()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get select column
            string Column = columns.Text;
            //get select bieu thuc
            string Bieuthuc = bieuthuc.SelectedItem.ToString();
            //get values
            string values = txt_values.Text;
            this.dataGridView1.Rows.Add(Column, Bieuthuc, values);

            int count = dataGridView1.Rows.Count;
            string value = "";
            string table = combo_table.SelectedValue.ToString();
            GetTable = table;
            GetColumn = Column;
            txt_query.Text = first_text_query + table + end_text_query + table +" WHERE ";  
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    value += " "+cell.Value.ToString();
                }
                if (count > 1)
                {
                    value += " AND ";                    
                }
            }
            if(count > 1)
                value = value.Remove(value.Length - 4);
            txt_query.Text += value + "')";           
            
        }

        private void columns_SelectedIndexChanged(object sender, EventArgs e)
        {
            bieuthuc.Items.Clear();
            string value_column = columns.SelectedValue.ToString();
            if (value_column.Equals("varchar(100)") || value_column.Equals("char(10)"))
            {
                bieuthuc.Items.Add("=");
            }
            else
            {
                bieuthuc.Items.Add("=");
                bieuthuc.Items.Add(">");
                bieuthuc.Items.Add(">=");
                bieuthuc.Items.Add("<");
                bieuthuc.Items.Add("<=");
                bieuthuc.Items.Add("<>");
            }
        }

        private void PhanTanNgang_Load(object sender, EventArgs e)
        {
            DBConnect mysql = new DBConnect();

            mysql.OpenConnection();
            combo_table.DisplayMember = "Tables_in_quanlyhaisan";
            combo_table.ValueMember = "Tables_in_quanlyhaisan";
            combo_table.DataSource = mysql.LoadComboBox("SHOW TABLES");

            mysql.CloseConnection();


            //string table = combo_table.SelectedValue.ToString();

            //mysql.OpenConnection();
            //columns.DisplayMember = "Field";
            //columns.ValueMember = "Type";
            //columns.DataSource = mysql.LoadComboBox("DESCRIBE "+table+"");           
            //mysql.CloseConnection();

            //txt_query.Text = first_text_query +table +end_text_query+ table+"')";

            //bieuthuc.Items.Clear();
            //string value_column = columns.SelectedValue.ToString();
            //if (value_column.Equals("varchar(100)") || value_column.Equals("char(10)"))
            //{
            //    bieuthuc.Items.Add("=");
            //}
            //else
            //{
            //    bieuthuc.Items.Add("=");
            //    bieuthuc.Items.Add(">");
            //    bieuthuc.Items.Add(">=");
            //    bieuthuc.Items.Add("<");
            //    bieuthuc.Items.Add("<=");
            //    bieuthuc.Items.Add("<>");
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }

        private void combo_table_SelectedIndexChanged(object sender, EventArgs e)
        {

            string table = combo_table.SelectedValue.ToString();
            txt_query.Text = first_text_query + table + end_text_query+table+"')";

            DBConnect mysql = new DBConnect();
            mysql.OpenConnection();
            columns.DisplayMember = "Field";
            columns.ValueMember = "Type";
            columns.DataSource = mysql.LoadComboBox("DESCRIBE " + table + "");
            mysql.CloseConnection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            query = txt_query.Text;
            LienKet lienKet = new LienKet();
            lienKet.Show();

            //Connection con = new Connection();
            //con.openConn();
            //con.executeUpdate(txt_query.Text);
            //con.closeConn();
            //MessageBox.Show("Phân Tán Thành Công");


            //con.openConn();
            //string conver = "select * into sp_cs FROM OPENQUERY(ConnectLan, 'SELECT * FROM quanlyhaisan.sp_cs WHERE quanlyhaisan.sp_cs.ID_COSO IN (SELECT ID_COSO FROM quanlyhaisan.coso)";
            //con.executeUpdate(conver);
            //con.closeConn();
            //}
            //catch
            //{
            //    MessageBox.Show("Phân Tán Thất Bại");
            //}

        }

        private void button5_Click(object sender, EventArgs e)
        {            
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void table_lk_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void column_clk_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void bieuthuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
