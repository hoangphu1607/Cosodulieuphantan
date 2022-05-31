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

            txt_query.Text = start_query + table + mid_query + end_query + table + end;
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

            txt_query.Text = start_query + table + mid_query + end_query +table+ end;
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
            MessageBox.Show(column_select);
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string content = "";
                //Lưu lại dòng dữ liệu vừa kích chọn
                for(int i =0; i< dataGridView2.Rows.Count; i++)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[i];
                    content += row.Cells[0].Value.ToString() +", ";
                }
                column_select = content.Remove(content.Length - 2);
            }
            string table = combo_table.SelectedValue.ToString();
            txt_query.Text = start_query + table + mid_query +column_select+ end_query + table + end;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.openConn();
                con.executeUpdate(txt_query.Text);
                con.closeConn();
                MessageBox.Show("Phân Tán Thành Công");
            }
            catch
            {
                MessageBox.Show("Phân Tán Thất Bại");
            }
        }
    }
}
