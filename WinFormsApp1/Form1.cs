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

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\alexdow\source\repos\WinFormsApp1\WinFormsApp1\bd.mdf;Integrated Security=True;Connect Timeout=30";

        DataTable dataTable = new DataTable();

        public void GetTable(string query)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataTable = dataSet.Tables[0];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string query = @"select * from Anketa";
            GetTable(query);
            dataGridAnketa.DataSource = dataTable;
            dataGridAnketa.Columns[0].HeaderText = "№";
            dataGridAnketa.Columns[1].HeaderText = "ФИО";
            dataGridAnketa.Columns[2].HeaderText = "Курс";
            dataGridAnketa.Columns[3].HeaderText = "Cпециальность";
            dataGridAnketa.Columns[4].HeaderText = "Группа";
        }


    }
}
