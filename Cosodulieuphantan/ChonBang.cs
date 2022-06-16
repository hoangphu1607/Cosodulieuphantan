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
    public partial class ChonBang : Form
    {
        public static TreeNode root = new TreeNode();
        public static string[] listdt;
        public ChonBang()
        {
            InitializeComponent();
        }

        private void ChonBang_Load(object sender, EventArgs e)
        {
            DBConnect mysql = new DBConnect();
            mysql.OpenConnection();
            DataTable tb = mysql.LoadComboBox("SHOW tables");
            List<string> listTB = new List<string>();
            listTB = tb.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("Tables_in_quanlyhaisan")).ToList();
            mysql.CloseConnection();

            int count = listTB.Count;
            int i = 0;
            root.Text = "Table";
            TreeNode[] item = new TreeNode[count];
            while (i < count)
            {
                item[i] = new TreeNode();
                item[i].Text = listTB[i].ToString();

                root.Nodes.Add(item[i]);
                i++;
            }
            treeView1.Nodes.Add(root);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int j = 0;
            listdt = new string[treeView1.Nodes[0].Nodes.Count];
            for(int i=0;i< treeView1.Nodes[0].Nodes.Count; i++)
            {
                if (treeView1.Nodes[0].Nodes[i].Checked == true)
                {
                    listdt[j] = treeView1.Nodes[0].Nodes[i].Text;
                    j++;
                }
            }
            PhanTanNgang phanTanNgang = new PhanTanNgang();
            phanTanNgang.Show();
        }
    }
}
