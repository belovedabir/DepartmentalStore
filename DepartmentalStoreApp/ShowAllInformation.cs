using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartmentalStoreApp
{
    public partial class ShowAllInformation : Form
    {
        public ShowAllInformation()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source = DESKTOP-T099P76\SQLEXPRESS; Initial Catalog = DepartmentalStoreDB;Integrated Security=True";
        private void showAllButton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from ProductItem", conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        dataGridView.DataSource = dt;
                    }
                }
            }
        }

        private void mainFormButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DepartmentalUI departmentalUI = new DepartmentalUI();
            departmentalUI.Show();
        }
    }
}
