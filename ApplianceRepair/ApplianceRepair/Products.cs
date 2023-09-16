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
    public partial class Products : Form
    {
        private Admin admin;
        public Products(Admin ad)
        {
            InitializeComponent();
            admin = ad;
        }
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet ds;
        SqlCommandBuilder commBuild;
        DataView dv;
        private void Products_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Server=DESKTOP-8FID4AN\SQLEXPRESS;Database=Goncharov_419/5_17;Trusted_Connection=True;");
                adapter = new SqlDataAdapter("SELECT * FROM Products", connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = ds.Tables[0];
                foreach (ComboBox cb in this.Controls.OfType<ComboBox>())
                {
                    foreach (DataColumn column in ds.Tables[0].Columns)
                    {
                        cb.Items.Add(column.ColumnName);
                    }
                }
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            try
            {
                ds.Tables[0].Rows.Add(1, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value, textBox5.Text);
                commBuild = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            
            try
            {
                var curruentRow = dataGridView1.CurrentCell.RowIndex;
                DataRow updateRow = ds.Tables[0].Rows[curruentRow];
                updateRow[1] = textBox1.Text;
                updateRow[2] = textBox2.Text;
                updateRow[3] = textBox3.Text;
                updateRow[4] = textBox4.Text;
                updateRow[5] = dateTimePicker1.Value;
                updateRow[6] = textBox5.Text;
                commBuild = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var curruentRow = dataGridView1.CurrentCell.RowIndex;
                ds.Tables[0].Rows[curruentRow].Delete();
                commBuild = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dv = ds.Tables[0].AsDataView();
                if (textBox6.Text == "")
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    dv.RowFilter = $"{comboBox1.Text} = '{textBox6.Text}'";
                    dataGridView1.DataSource = dv;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, comboBox1.SelectedText, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    ds.Tables[0].DefaultView.Sort = $"{comboBox2.Text} DESC, {comboBox3.Text} DESC";
                }
                else
                {
                    ds.Tables[0].DefaultView.Sort = $"{comboBox2.Text} ASC, {comboBox3.Text} ASC";
                }
                DataTable dt = ds.Tables[0].DefaultView.ToTable();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, comboBox1.SelectedText, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Products_FormClosed(object sender, FormClosedEventArgs e)
        {
            admin.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
