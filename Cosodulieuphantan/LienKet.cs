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
                con.openConn();
                con.executeUpdate("ALTER TABLE " + PhanTanNgang.GetTable + " alter column " + primaryKey1 + " int not null");
                con.closeConn();
                con.openConn();
                con.executeUpdate("ALTER TABLE " + PhanTanNgang.GetTable + " ADD PRIMARY KEY (" + primaryKey1 + ")");
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

                    que = "SELECT DISTINCT " + select_table + " into " + list[2] +" from OPENQUERY(ConnectLan, " +
                        "'SELECT * FROM quanlyhaisan." + list[2]+ "') " + list[2] + "," + list[0] + " where " + list[0]+"."+ list[1] + " = "+list[2]+ "." + list[3] + "";
                    //list[2] = bang duoc phan tan
                    //list[0] = bang dieu kien khi where
                    //list[1] = cột khóa chính của list[0]
                    //list[3] = cột khóa chính của list[2]
                    con.openConn();
                    con.executeUpdate(que);
                    con.closeConn();

                    string findKey = "select DISTINCT COLUMN_NAME, CONSTRAINT_NAME, REFERENCED_COLUMN_NAME, REFERENCED_TABLE_NAME " +
                        "from information_schema.KEY_COLUMN_USAGE " +
                        "where TABLE_NAME = '"+ list[2] + "'; ";
                    //tạo mảng có giá trị là cột của table được chọn phân tán
                    connect.OpenConnection();
                    DataTable ListTable = connect.LoadComboBox(findKey);
                    List<string> data_ListTable = new List<string>();
                    data_ListTable = ListTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("COLUMN_NAME")).ToList();
                    connect.CloseConnection();
                    //tạo mảng có giá trị là khóa của table được chọn phân tán (PRIMARY,...)
                    connect.OpenConnection();
                    DataTable ListKey = connect.LoadComboBox(findKey);
                    List<string> data_ListKey = new List<string>();
                    data_ListKey = ListKey.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("CONSTRAINT_NAME")).ToList();
                    connect.CloseConnection();
                    //tạo khóa chính
                    int index = data_ListKey.LastIndexOf("PRIMARY"); // tìm vị trí cuối cùng của primary key trong mảng các cột 
                    string primaryKey = "";
                    for (int i = 0; i <= index; i++)
                    {
                        if(i == index && i != 0)
                        {
                            primaryKey += ", "+data_ListTable[i];
                        }
                        else
                        {
                            primaryKey += data_ListTable[i];
                        }
                    con.openConn();
                    con.executeUpdate("ALTER TABLE " + list[2] + " alter column " + data_ListTable[i] + " int not null");
                    con.closeConn();
                }
                    con.openConn();
                    con.executeUpdate("ALTER TABLE " + list[2] +" ADD PRIMARY KEY ("+primaryKey+")");
                    con.closeConn();
                    //MessageBox.Show(que);
                    list.Clear();
                }
                    string combo_table = "SELECT TABLE_NAME " +
                                "FROM QLHS.INFORMATION_SCHEMA.TABLES " +
                                "WHERE TABLE_TYPE = 'BASE TABLE'";
                    con.openConn();
                    DataTable ListTableInSQL = con.loadDataTable(combo_table);
                    List<string> data_ListTableInSQL = new List<string>();
                    data_ListTableInSQL = ListTableInSQL.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("TABLE_NAME")).ToList();
                    con.closeConn();
                    
                    for(int i =0;i< data_ListTableInSQL.Count; i++)
                    {
                        //column
                        connect.OpenConnection();
                        DataTable ListTableInMYSQL = connect.LoadComboBox("select DISTINCT COLUMN_NAME, CONSTRAINT_NAME, REFERENCED_COLUMN_NAME, REFERENCED_TABLE_NAME from information_schema.KEY_COLUMN_USAGE where TABLE_NAME = '" + data_ListTableInSQL[i] + "';");
                        List<string> data_ListTableInMySQL = new List<string>();
                        data_ListTableInMySQL = ListTableInMYSQL.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("COLUMN_NAME")).ToList();
                        connect.CloseConnection();
                        //key
                        connect.OpenConnection();
                        DataTable ListKeyInMYSQL = connect.LoadComboBox("select DISTINCT COLUMN_NAME, CONSTRAINT_NAME, REFERENCED_COLUMN_NAME, REFERENCED_TABLE_NAME from information_schema.KEY_COLUMN_USAGE where TABLE_NAME = '" + data_ListTableInSQL[i] + "';");
                        List<string> data_ListKeyTableInMySQL = new List<string>();
                        data_ListKeyTableInMySQL = ListKeyInMYSQL.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("CONSTRAINT_NAME")).ToList();
                        connect.CloseConnection();
                        //cot khoa ngoai
                        connect.OpenConnection();
                        DataTable REFERENCED_COLUMN_NAME = connect.LoadComboBox("select DISTINCT COLUMN_NAME, CONSTRAINT_NAME, REFERENCED_COLUMN_NAME, REFERENCED_TABLE_NAME from information_schema.KEY_COLUMN_USAGE where TABLE_NAME = '" + data_ListTableInSQL[i] + "';");
                        List<string> data_REFERENCED_COLUMN_NAME = new List<string>();
                        data_REFERENCED_COLUMN_NAME = REFERENCED_COLUMN_NAME.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("REFERENCED_COLUMN_NAME")).ToList();
                        connect.CloseConnection();
                        //bang chua khoa ngoai
                        connect.OpenConnection();
                        DataTable REFERENCED_TABLE_NAME = connect.LoadComboBox("select DISTINCT COLUMN_NAME, CONSTRAINT_NAME, REFERENCED_COLUMN_NAME, REFERENCED_TABLE_NAME from information_schema.KEY_COLUMN_USAGE where TABLE_NAME = '" + data_ListTableInSQL[i] + "';");
                        List<string> data_REFERENCED_TABLE_NAME = new List<string>();
                        data_REFERENCED_TABLE_NAME = REFERENCED_TABLE_NAME.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("REFERENCED_TABLE_NAME")).ToList();
                        connect.CloseConnection();
                        int vitri = data_ListKeyTableInMySQL.LastIndexOf("PRIMARY");
                if(vitri != data_ListKeyTableInMySQL.Count - 1)
                {
                    for (int j = vitri + 1; j < data_ListKeyTableInMySQL.Count; j++)
                    {
                        con.openConn();
                        con.executeUpdate("ALTER TABLE " + list[2] + " add foreign key (" + data_ListTableInMySQL[j] + ") references "+ data_REFERENCED_TABLE_NAME[j] + "("+ data_REFERENCED_COLUMN_NAME[j] + ")");
                        con.closeConn();
                    }
                }
                        
                        
                    }
            MessageBox.Show("Phân Tán Thành Công");
        //}
        //    catch (Exception ex)
        //    {
                
        //        MessageBox.Show("Phân Tán Thất Bại");
        //        string combo_table = "SELECT TABLE_NAME " +
        //            "FROM QLHS.INFORMATION_SCHEMA.TABLES " +
        //            "WHERE TABLE_TYPE = 'BASE TABLE'";
        //        Connection con = new Connection();
        //        con.openConn();
        //        DataTable ListTable = con.loadDataTable(combo_table);
        //        List<string> data_ListTable = new List<string>();
        //        data_ListTable = ListTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("TABLE_NAME")).ToList();
        //        con.closeConn();
        //        for(int i = 0;i < data_ListTable.Count; i++)
        //        {
        //            string alter = "DROP TABLE " + data_ListTable[i] +"";
        //        }
        //    }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
