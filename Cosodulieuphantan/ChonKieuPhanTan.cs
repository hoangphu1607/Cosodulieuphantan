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
            }
            else
            {
                MessageBox.Show("Kết Nối Thất Bại");
            }
        }
    }
}
