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

namespace ApplianceRepair
{
    public partial class Employees : Form
    {
        private Admin ad;
        public Employees(Admin admin)
        {
            InitializeComponent();
            this.ad = admin;
        }
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet ds;
        SqlCommandBuilder commBuild;
        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                commBuild = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                MessageBox.Show("Бaза данных обновлена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Server=DESKTOP-8FID4AN\SQLEXPRESS;Database=Goncharov_419/5_17;Trusted_Connection=True;");
                adapter = new SqlDataAdapter("SELECT * FROM Employees", connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Employees_FormClosed(object sender, FormClosedEventArgs e)
        {
            ad.Show();
        }
    }
}
