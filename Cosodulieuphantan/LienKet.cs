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
            table_lk.DataSource = mysql.LoadComboBox("SHOW TABLES");
            mysql.CloseConnection();

            mysql.OpenConnection();
            table_clk.DisplayMember = "Tables_in_quanlyhaisan";
            table_clk.ValueMember = "Tables_in_quanlyhaisan";
            table_clk.DataSource = mysql.LoadComboBox("SHOW TABLES");
            mysql.CloseConnection();

            //string table_LK = table_lk.Text;
            //string table_CLK = table_clk.Text;
            //MessageBox.Show(table_LK);
            //MessageBox.Show(table_CLK);
            //mysql.OpenConnection();
            //column_lk.DisplayMember = "Field";
            //column_lk.ValueMember = "Field";
            //column_lk.DataSource = mysql.LoadComboBox("DESCRIBE " + table_LK + "");
            //mysql.CloseConnection();

            //mysql.OpenConnection();
            //column_clk.DisplayMember = "Field";
            //column_clk.ValueMember = "Field";
            //column_clk.DataSource = mysql.LoadComboBox("DESCRIBE " + table_CLK + "");
            //mysql.CloseConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string table1 = table_lk.SelectedValue.ToString() + "." + column_lk.SelectedValue.ToString();
            string table2 = table_clk.SelectedValue.ToString() + "." + column_clk.SelectedValue.ToString();

            this.dataGridView2.Rows.Add(table1, table2,"");
        }

        private void table_lk_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table = table_lk.SelectedValue.ToString();
            //MessageBox.Show(table);
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
            //MessageBox.Show(table);
            DBConnect mysql = new DBConnect();
            mysql.OpenConnection();
            column_clk.DisplayMember = "Field";
            column_clk.ValueMember = "Field";
            column_clk.DataSource = mysql.LoadComboBox("DESCRIBE " + table + "");
            mysql.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                Connection con = new Connection();
                DBConnect connect = new DBConnect();
                con.openConn();
                con.executeUpdate(PhanTanNgang.query);
                con.closeConn();

                string findKey1 = "select DISTINCT COLUMN_NAME, CONSTRAINT_NAME, REFERENCED_COLUMN_NAME, REFERENCED_TABLE_NAME " +
                       "from information_schema.KEY_COLUMN_USAGE " +
                       "where TABLE_NAME = '" + PhanTanNgang.GetTable + "'; ";
                //tạo mảng có giá trị là cột của table được chọn phân tán
                connect.OpenConnection();
                DataTable TableFirst = connect.LoadComboBox(findKey1);
                List<string> data_TableFirst = new List<string>();
                data_TableFirst = TableFirst.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("COLUMN_NAME")).ToList();
                connect.CloseConnection();
                //tạo mảng có giá trị là khóa của table được chọn phân tán (PRIMARY,...)
                connect.OpenConnection();
                DataTable FirstKeyofTable = connect.LoadComboBox(findKey1);
                List<string> data_FirstKeyofTable = new List<string>();
                data_FirstKeyofTable = FirstKeyofTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("CONSTRAINT_NAME")).ToList();
                connect.CloseConnection();
                //tạo khóa chính
                int index1 = data_FirstKeyofTable.LastIndexOf("PRIMARY"); // tìm vị trí cuối cùng của primary key trong mảng các cột 
                string primaryKey1 = "";
                for (int i = 0; i <= index1; i++)
                {
                    if (i == index1 && i != 0)
                    {
                        primaryKey1 += ", " + data_TableFirst[i];
                    }
                    else
                    {
                        primaryKey1 += data_TableFirst[i];
                    }
                }
                //con.openConn();
                //con.executeUpdate("ALTER TABLE " + PhanTanNgang.GetTable + " alter column " + primaryKey1 + " int not null");
                //con.closeConn();
                //con.openConn();
                //con.executeUpdate("ALTER TABLE " + PhanTanNgang.GetTable + " ADD PRIMARY KEY (" + primaryKey1 + ")");
                //con.closeConn();
                string value = "",que = "";
                List<string> list = new List<string>();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                int k = 1;
                string where = "";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if(k == 3) // cột điều kiện
                        {
                            where = cell.Value.ToString();
                    }
                        else
                        {
                            value = cell.Value.ToString();
                            string[] arrListStr = value.Split('.');
                            list.Add(arrListStr[0]);
                            list.Add(arrListStr[1]);
                            k++;
                        }                        
                    }
                    //Lấy cột của bảng cần phân tán thành list
                    connect.OpenConnection();
                    DataTable dataTable= connect.LoadComboBox("DESCRIBE " + list[2] + "");
                    List<string> data = new List<string>();
                    data = dataTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("Field")).ToList();
                    connect.CloseConnection();

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
                if (where.Equals(""))
                {
                    que = "SELECT DISTINCT " + select_table + " into " + list[2] + " from OPENQUERY(ConnectLan, " +
                    "'SELECT * FROM quanlyhaisan." + list[2] + "') " + list[2] + "," + list[0] + " where " + list[0] + "." + list[1] + " = " + list[2] + "." + list[3] + "";

                }
                else
                {
                    que = "SELECT DISTINCT " + select_table + " into " + list[2] + " from OPENQUERY(ConnectLan, " +
                    "'SELECT * FROM quanlyhaisan." + list[2] + "') " + list[2] + "," + list[0] + " where " + list[0] + "." + list[1] + " = " + list[2] + "." + list[3] + " AND " + where +"";
                }
                //list[2] = bang duoc phan tan
                //list[0] = bang dieu kien khi where
                //list[1] = cột khóa chính của list[0]
                //list[3] = cột khóa chính của list[2]
                con.openConn();
                    con.executeUpdate(que);
                    con.closeConn();

                    //string findKey = "select DISTINCT COLUMN_NAME, CONSTRAINT_NAME, REFERENCED_COLUMN_NAME, REFERENCED_TABLE_NAME " +
                    //    "from information_schema.KEY_COLUMN_USAGE " +
                    //    "where TABLE_NAME = '"+ list[2] + "';";
                    ////tạo mảng có giá trị là cột của table được chọn phân tán
                    //connect.OpenConnection();
                    //DataTable ListTable = connect.LoadComboBox(findKey);
                    //List<string> data_ListTable = new List<string>();
                    //data_ListTable = ListTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("COLUMN_NAME")).ToList();
                    //connect.CloseConnection();
                    ////tạo mảng có giá trị là khóa của table được chọn phân tán (PRIMARY,...)
                    //connect.OpenConnection();
                    //DataTable ListKey = connect.LoadComboBox(findKey);
                    //List<string> data_ListKey = new List<string>();
                    //data_ListKey = ListKey.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("CONSTRAINT_NAME")).ToList();
                    //connect.CloseConnection();
                    ////tạo khóa chính
                    //int index = data_ListKey.LastIndexOf("PRIMARY"); // tìm vị trí cuối cùng của primary key trong mảng các cột 
                    //string primaryKey = "";
                    //for (int i = 0; i <= index; i++)
                    //{
                    //    if(i == index && i != 0)
                    //    {
                    //        primaryKey += ", "+data_ListTable[i];
                    //    }
                    //    else
                    //    {
                    //        primaryKey += data_ListTable[i];
                    //    }
                    //    con.openConn();
                    //    con.executeUpdate("ALTER TABLE " + list[2] + " alter column " + data_ListTable[i] + " int not null");
                    //    con.closeConn();
                    //}
                    //    con.openConn();
                    //    con.executeUpdate("ALTER TABLE " + list[2] +" ADD PRIMARY KEY ("+primaryKey+")");
                    //    con.closeConn();
                    //    //MessageBox.Show(que);                      
                list.Clear();
                }
            //lấy các bảng đã có trong sql server
            string BangTrongSQL = "SELECT TABLE_NAME FROM " + ChonKieuPhanTan.database + ".INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
            con.openConn();
            DataTable BangCoTrongSQL = con.loadDataTable(BangTrongSQL);
            List<string> data_BangTrongSQL = new List<string>();
            data_BangTrongSQL = BangCoTrongSQL.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("TABLE_NAME")).ToList();
            con.closeConn();
            //lấy all bảng trong mysql
            string BangTrongMySql = "SHOW TABLES";
            connect.OpenConnection();
            DataTable data_TableInMySQl = connect.LoadComboBox(BangTrongMySql);
            connect.CloseConnection();

            foreach (DataRow row in data_TableInMySQl.Rows)
            {
                int index = data_BangTrongSQL.LastIndexOf(row["Tables_in_quanlyhaisan"].ToString());
                if (index == -1)
                {
                    con.openConn();
                    con.executeUpdate("SELECT DISTINCT * INTO " + row["Tables_in_quanlyhaisan"].ToString() + " FROM OPENQUERY(ConnectLan, 'SELECT * FROM quanlyhaisan." + row["Tables_in_quanlyhaisan"].ToString() + "')");
                    con.closeConn();
                }
            }
            //tạo not null
            string PrimaryKey = "SELECT TABLE_NAME,COLUMN_NAME,COLUMN_KEY FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'quanlyhaisan'  and COLUMN_KEY = 'PRI'";
            connect.OpenConnection();
            DataTable Pri = connect.LoadComboBox(PrimaryKey);
            List<string> data_ListKey = new List<string>();
            data_ListKey = Pri.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("TABLE_NAME")).ToList();
            connect.CloseConnection();
            string checkColumn = "";
            foreach (DataRow row in Pri.Rows)
            {
                try
                {
                    con.openConn();
                    con.executeUpdate("ALTER TABLE " + row["TABLE_NAME"] + " alter column " + row["COLUMN_NAME"] + " int not null");
                    con.closeConn();

                }
                catch
                {
                }
            }
            //tạo khóa chính

            string allTable = "SHOW TABLES";
            connect.OpenConnection();
            DataTable tableInMySql = connect.LoadComboBox(allTable);
            connect.CloseConnection();
            try
            {
                foreach (DataRow row in tableInMySql.Rows)
                {
                    //string findKey = "select DISTINCT COLUMN_NAME, CONSTRAINT_NAME, REFERENCED_COLUMN_NAME, REFERENCED_TABLE_NAME " +
                    //"from information_schema.KEY_COLUMN_USAGE " +
                    //"where TABLE_NAME = '" + row["Tables_in_quanlyhaisan"].ToString() + "';";

                    //string question = "SELECT TABLE_NAME,COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'quanlyhaisan' and COLUMN_KEY = 'PRI' AND TABLE_NAME = '" + row["Tables_in_quanlyhaisan"].ToString() + "';";
                    //connect.OpenConnection();
                    //DataTable tableInMySQLKey = connect.LoadComboBox(question);
                    //connect.CloseConnection();

                    //string columnPrimary = "";
                    //int number = 1;
                    //foreach (DataRow rw in tableInMySQLKey.Rows)
                    //{
                    //    if (number == 1)
                    //    {
                    //        columnPrimary += rw["COLUMN_NAME"].ToString();
                    //        number++;
                    //    }
                    //    else
                    //    {
                    //        columnPrimary += ", " + rw["COLUMN_NAME"].ToString();
                    //        number++;
                    //    }
                    //}
                    //con.openConn();
                    //con.executeUpdate("ALTER TABLE " + row["Tables_in_quanlyhaisan"].ToString() + " ADD PRIMARY KEY (" + columnPrimary + ")");
                    //con.closeConn();
                    string findKey = "select DISTINCT COLUMN_NAME, CONSTRAINT_NAME, REFERENCED_COLUMN_NAME, REFERENCED_TABLE_NAME " +
                    "from information_schema.KEY_COLUMN_USAGE " +
                    "where TABLE_NAME = '" + row["Tables_in_quanlyhaisan"].ToString() + "';";
                    //tạo mảng có giá trị là cột của table được chọn phân tán
                    connect.OpenConnection();
                    DataTable ListTable = connect.LoadComboBox(findKey);
                    List<string> data_ListTable = new List<string>();
                    data_ListTable = ListTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("COLUMN_NAME")).ToList();
                    connect.CloseConnection();
                    //tạo mảng có giá trị là khóa của table được chọn phân tán (PRIMARY,...)
                    connect.OpenConnection();
                    DataTable ListKey = connect.LoadComboBox(findKey);
                    List<string> CONSTRAINT_NAME = new List<string>();
                    CONSTRAINT_NAME = ListKey.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("CONSTRAINT_NAME")).ToList();
                    connect.CloseConnection();
                    //tạo khóa chính
                    int index = CONSTRAINT_NAME.LastIndexOf("PRIMARY"); // tìm vị trí cuối cùng của primary key trong mảng các cột 
                    string primaryKey = "";
                    for (int i = 0; i <= index; i++)
                    {
                        if (i == index && i != 0)
                        {
                            primaryKey += ", " + data_ListTable[i];
                        }
                        else
                        {
                            primaryKey += data_ListTable[i];
                        }
                    }
                    con.openConn();
                    con.executeUpdate("ALTER TABLE " + row["Tables_in_quanlyhaisan"].ToString() + " ADD PRIMARY KEY (" + primaryKey + ")");
                    con.closeConn();
                }
            }
            catch
            {
                //MessageBox.Show("Đã Có Lỗi");
            }
            string  comboForeignKey = "SELECT TABLE_NAME,COLUMN_NAME,CONSTRAINT_NAME, REFERENCED_TABLE_NAME,REFERENCED_COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
                "WHERE REFERENCED_TABLE_SCHEMA = 'quanlyhaisan' ";
            connect.OpenConnection();
            DataTable dt = connect.LoadComboBox(comboForeignKey);
            connect.CloseConnection();
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    string Fokey = "ALTER TABLE " + row["TABLE_NAME"].ToString() + " ADD FOREIGN KEY (" + row["COLUMN_NAME"].ToString() + ") REFERENCES " + row["REFERENCED_TABLE_NAME"] + "(" + row["REFERENCED_COLUMN_NAME"].ToString() + "); ";
                    //MessageBox.Show(Fokey);
                    con.openConn();
                    con.executeUpdate(Fokey);
                    con.closeConn();
                }
                catch
                {
                }                
            }
            MessageBox.Show("Phân Tán Thành Công");
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT TABLE_NAME,COLUMN_NAME,CONSTRAINT_NAME, REFERENCED_TABLE_NAME,REFERENCED_COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE REFERENCED_TABLE_SCHEMA = 'quanlyhaisan'";
            DBConnect mysql = new DBConnect();
            mysql.OpenConnection();
            DataTable tb = mysql.LoadComboBox(query);
            //TABLE_NAME
            List<string> TABLE_NAME = new List<string>();
            TABLE_NAME = tb.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("TABLE_NAME")).ToList();
            //COLUMN_NAME
            List<string> COLUMN_NAME = new List<string>();
            COLUMN_NAME = tb.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("COLUMN_NAME")).ToList();
            //REFERENCED_TABLE_NAME
            List<string> REFERENCED_TABLE_NAME = new List<string>();
            REFERENCED_TABLE_NAME = tb.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("REFERENCED_TABLE_NAME")).ToList();
            //REFERENCED_COLUMN_NAME 
            List<string> REFERENCED_COLUMN_NAME = new List<string>();
            REFERENCED_COLUMN_NAME = tb.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("REFERENCED_COLUMN_NAME")).ToList();
            mysql.CloseConnection();

            //lấy vị trí phần tử
            string table = PhanTanNgang.GetTable;
            while(TABLE_NAME.Count > 0)
            {
                int index = REFERENCED_TABLE_NAME.IndexOf(table);
                int find = 1;
                if (index == -1)
                {
                    index = TABLE_NAME.IndexOf(table);
                    find = 0;
                }
                if(find == 1)
                {
                    dataGridView2.Rows.Add(REFERENCED_TABLE_NAME[index] + "." + REFERENCED_COLUMN_NAME[index],
                        TABLE_NAME[index] + "." + COLUMN_NAME[index]);
                    //tìm tiếp coi còn cột đó ko
                    int findnext = REFERENCED_TABLE_NAME.IndexOf(table);
                    if (findnext == -1)
                    {
                        table = COLUMN_NAME[index].ToString();
                    }
                }
                else
                {
                    dataGridView2.Rows.Add( TABLE_NAME[index] + "." +  COLUMN_NAME[index],
                        REFERENCED_TABLE_NAME[index] + "." + REFERENCED_COLUMN_NAME[index]);
                    //tìm tiếp coi còn cột đó ko

                    int findnext = TABLE_NAME.IndexOf(table);
                    if (findnext == -1)
                    {
                        table = REFERENCED_TABLE_NAME[index].ToString();
                    }
                }

                TABLE_NAME.RemoveAt(index);
                COLUMN_NAME.RemoveAt(index);
                REFERENCED_TABLE_NAME.RemoveAt(index);
                REFERENCED_COLUMN_NAME.RemoveAt(index);
            }
            
            //MessageBox.Show("Vị Trí "+ table + ": "+ index);


        }

        private void column_clk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
