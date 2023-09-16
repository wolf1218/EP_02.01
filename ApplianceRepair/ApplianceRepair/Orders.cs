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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ApplianceRepair
{
    public partial class Orders : Form
    {
        private Admin admin;
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet ds;
        SqlCommandBuilder commBuild;
        DataView dv;
        int b = 0;
        System.Windows.Forms.ComboBox id = new System.Windows.Forms.ComboBox();
        public Orders(Admin ad)
        {
            InitializeComponent();
            admin = ad;
        }
        
        private void Orders_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Server=DESKTOP-8FID4AN\SQLEXPRESS;Database=Goncharov_419/5_17;Trusted_Connection=True;");
                connection.Open();
                adapter = new SqlDataAdapter("SELECT * FROM Orders", connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = ds.Tables[0];
                foreach (System.Windows.Forms.ComboBox cb in this.Controls.OfType<System.Windows.Forms.ComboBox>())
                {
                    foreach (DataColumn column in ds.Tables[0].Columns)
                    {
                        cb.Items.Add(column.ColumnName);
                    }
                }
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                this.Controls.Add(id);
                id.Location = new Point(80, 312);
                id.Size = new Size(175, 21);
                SqlCommand command = new SqlCommand("SELECT ProductKey FROM Products", connection);
                SqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    id.Items.Add(reader.GetInt32(0));
                    i++;
                }
                id.SelectedIndex = 0;
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Orders_FormClosed(object sender, FormClosedEventArgs e)
        {
            admin.Show();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            try
            {
                ds.Tables[0].Rows.Add(1, id.Text, textBox1.Text, b, dateTimePicker1.Value);
                commBuild = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                b = 1;
            }
            else
            {
                b = 0;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var curruentRow = dataGridView1.CurrentCell.RowIndex;
                DataRow updateRow = ds.Tables[0].Rows[curruentRow];
                updateRow[1] = id.Text;
                updateRow[2] = textBox1.Text;
                updateRow[3] = b;
                updateRow[4] = dateTimePicker1.Value;
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
    }
}
