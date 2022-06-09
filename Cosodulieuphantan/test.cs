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
    public partial class test : Form
    {
        public string start_query = "SELECT * INTO ";
        public string mid_query = " FROM OPENQUERY(ConnectLan, 'SELECT ";
        public string end_query = " FROM quanlyhaisan.";
        public string column_select = "";
        public string end = "')";
        public static string conten_cell;
        public test()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
            this.dataGridView2.Rows.Add(conten_cell);
                
        }

        private void test_Load(object sender, EventArgs e)
        {
            DBConnect mysql = new DBConnect();

            mysql.OpenConnection();
            combo_table.DisplayMember = "Tables_in_quanlyhaisan";
            combo_table.ValueMember = "Tables_in_quanlyhaisan";
            combo_table.DataSource = mysql.LoadComboBox("SHOW tables");
            mysql.CloseConnection();

            string table = combo_table.SelectedValue.ToString();
            DataTable dataTable = mysql.LoadComboBox("DESCRIBE " + table + "");
            dataGridView1.DataSource = dataTable;
            this.dataGridView1.Columns["Type"].Visible = false;
            this.dataGridView1.Columns["Null"].Visible = false;
            this.dataGridView1.Columns["Key"].Visible = false;
            this.dataGridView1.Columns["Default"].Visible = false;
            this.dataGridView1.Columns["Extra"].Visible = false;

            //txt_query.Text = start_query + table + mid_query + end_query + table + end;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void combo_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnect mysql = new DBConnect();
            string table = combo_table.SelectedValue.ToString();
            DataTable dataTable = mysql.LoadComboBox("DESCRIBE " + table + "");
            dataGridView1.DataSource = dataTable;
            this.dataGridView1.Columns["Type"].Visible = false;
            this.dataGridView1.Columns["Null"].Visible = false;
            this.dataGridView1.Columns["Key"].Visible = false;
            this.dataGridView1.Columns["Default"].Visible = false;
            this.dataGridView1.Columns["Extra"].Visible = false;

            this.dataGridView2.Rows.Clear();
            //txt_query.Text = start_query + table + mid_query + end_query +table+ end;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                conten_cell = row.Cells[0].Value.ToString();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                conten_cell = row.Cells[0].Value.ToString();
                this.dataGridView2.Rows.Add(conten_cell);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            DBConnect connect = new DBConnect();
            string value = "";
            List<string> list = new List<string>();
            string select_table = "";
            string table = combo_table.SelectedValue.ToString();
            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        value = cell.Value.ToString();
            //        list.Add(value);
            //    }
            //    //Lấy cột của bảng cần phân tán thành list
            //    //connect.OpenConnection();
            //    //DataTable dataTable = connect.LoadComboBox("DESCRIBE " + list[0] + "");
            //    //List<string> data = new List<string>();
            //    //data = dataTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("Field")).ToList();
            //    //for (int i = 0; i < dataTable.Rows.Count; i++)
            //    //{
            //    //    select_table += data[i];
            //    //}
            //    list.Clear();
            //}
            DataTable dataTable = connect.LoadComboBox("DESCRIBE " + table + "");
            List<string> get_key = new List<string>();
            get_key = dataTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("Key")).ToList();
            connect.CloseConnection();

            connect.OpenConnection();
            DataTable dataTableKey = connect.LoadComboBox("DESCRIBE " + table + "");
            List<string> get_column_key = new List<string>();
            get_column_key = dataTableKey.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("Field")).ToList();
            connect.CloseConnection();

            string key = "";
            for (int i = 0; i < get_key.Count; i++)
            {
                if (i == dataTable.Rows.Count - 1)
                {
                    key += get_key[i] +" _end";
                }
                else
                    key += get_key[i] + " , ";

            }
            MessageBox.Show(get_column_key[0]);
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string content = "";
                //Lưu lại dòng dữ liệu vừa kích chọn
                for(int i =0; i< dataGridView2.Rows.Count; i++)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[i];
                    content += row.Cells[0].Value.ToString() +", ";
                }
                column_select = content.Remove(content.Length - 2);
            }
            string table = combo_table.SelectedValue.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string table = combo_table.SelectedValue.ToString();
            Connection con = new Connection();
            DBConnect connect = new DBConnect();
            string value = "";
            List<string> list = new List<string>();
            string select_table = "";
            
            DataTable dataTable = connect.LoadComboBox("DESCRIBE " + table + "");
            List<string> get_key = new List<string>();
            get_key = dataTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("Key")).ToList();
            connect.CloseConnection();

            connect.OpenConnection();
            DataTable dataTableKey = connect.LoadComboBox("DESCRIBE " + table + "");
            List<string> get_column_key = new List<string>();
            get_column_key = dataTableKey.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("Field")).ToList();
            connect.CloseConnection();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    value = cell.Value.ToString();
                    list.Add(value);
                }
            }
            int index = get_key.LastIndexOf("PRI");
            for (int i = 0; i <= index; i++)
            {
                int isExist = list.IndexOf(get_column_key[i].ToString());
                if (isExist == -1)
                {
                    column_select += ", "+get_column_key[i].ToString();
                }
            }
            MessageBox.Show(column_select);
            dataGridView3.Rows.Add(table, column_select);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Connection con = new Connection();
                DBConnect connect = new DBConnect();

                string value = "", que = "", table = "";
                List<string> list = new List<string>();
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    int index = 1;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (index != 1)
                        {
                            value = cell.Value.ToString();
                            con.openConn();
                            con.executeUpdate("SELECT DISTINCT * INTO " + table + " FROM OPENQUERY(ConnectLan, 'SELECT " + value + " FROM quanlyhaisan." + table + "')");
                            con.closeConn();
                        }
                        else
                        {
                            table = cell.Value.ToString();
                            index++;
                        }
                    }
                    list.Clear();
                }
                MessageBox.Show("Phân Tán Thành Công Rồi");

            }
            catch
            {
                Connection con = new Connection();
                con.openConn();
                con.executeUpdate("EXEC sp_MSforeachtable @command1 = 'DROP TABLE ? ''");
                con.closeConn();
                MessageBox.Show("Phân Tán Thất Bại Rồi");
            }

        }
    }
}
