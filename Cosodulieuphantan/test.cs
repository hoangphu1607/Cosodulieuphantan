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
        public test()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
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
        }
    }
}
