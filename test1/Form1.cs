using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace test1
{
    public partial class Form1 : Form
    {
        DataBase db = new DataBase();
        DataTable dataTable = new DataTable();
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            db.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Catalog", db.GetConnection());
            dataTable.Clear();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            db.closeConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = SearchTextBox.Text;
            DataView db = dataTable.DefaultView;
            string b = string.Join(" OR ", dataTable.Columns.Cast<DataColumn>()
                             .Select(c => $"CONVERT([{c.ColumnName}], System.String) " +
                             $"LIKE '%{a}%'"));
            db.RowFilter = b;
            dataGridView1.DataSource = db.ToTable();
        }

        private void add_Click(object sender, EventArgs e)
        {

        }
    }
}
