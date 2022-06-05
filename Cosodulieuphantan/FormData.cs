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
    public partial class FormData : Form
    {
        public FormData()
        {
            InitializeComponent();
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            try
            {
                Connection conn = new Connection();
                conn.openConn();
                combo_table.DisplayMember = "TABLE_NAME";
                combo_table.ValueMember = "TABLE_NAME";
                string sql = "SELECT TABLE_NAME FROM QLHS.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
                combo_table.DataSource = conn.loadDataTable(sql);
                conn.closeConn();

                conn.openConn();
                string table_select = combo_table.Text;
                string query = "SELECT * FROM " + table_select;
                dataGridView1.DataSource = conn.loadDataTable(query);
                conn.closeConn();
            }
            catch
            {

            }
            
        }

        private void combo_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection conn = new Connection();
                conn.openConn();
                string table_select = combo_table.Text;
                string query = "SELECT * FROM " + table_select;
                dataGridView1.DataSource = conn.loadDataTable(query);
                conn.closeConn();
            }
            catch
            {

            }
            
        }
    }
}
