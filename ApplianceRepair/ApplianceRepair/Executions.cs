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
    public partial class Executions : Form
    {
        private Admin admin;
        private User user;
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet ds;
        SqlCommandBuilder commBuild;
        DataView dv;
        int b = 0;
        System.Windows.Forms.ComboBox id1 = new System.Windows.Forms.ComboBox();
        System.Windows.Forms.ComboBox id2 = new System.Windows.Forms.ComboBox();
        public Executions(Admin ad)
        {
            InitializeComponent();
            admin = ad;
        }
        public Executions(User us)
        {
            InitializeComponent();
            user = us;
        }

        private void Executions_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Server=DESKTOP-8FID4AN\SQLEXPRESS;Database=Goncharov_419/5_17;Trusted_Connection=True;");
                connection.Open();
                adapter = new SqlDataAdapter("SELECT * FROM Executions", connection);
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
                this.Controls.Add(id1);
                this.Controls.Add(id2);
                id1.Location = new Point(90, 312);
                id1.Size = new Size(175, 21);
                id2.Location = new Point(90, 339);
                id2.Size = new Size(175, 21);
                SqlCommand command = new SqlCommand("SELECT OrderKey FROM Orders", connection);
                SqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    id1.Items.Add(reader.GetInt32(0));
                    i++;
                }
                reader.Close();
                id1.SelectedIndex = 0;
                command = new SqlCommand("SELECT EmployeeKey FROM Employees", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id2.Items.Add(reader.GetInt32(0));
                    i++;
                }
                id2.SelectedIndex = 0;
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Executions_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (admin != null)
            {
                admin.Show();
            }
            else
            {
                user.Show();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            try
            {
                ds.Tables[0].Rows.Add(1, id1.Text, id2.Text, dateTimePicker1.Value, b, dateTimePicker2.Value, textBox1.Text, numericUpDown1.Value, numericUpDown2.Value);
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
                updateRow[1] = id1.Text;
                updateRow[2] = id2.Text;
                updateRow[3] = dateTimePicker1.Value;
                updateRow[4] = b;
                updateRow[5] = dateTimePicker2.Value;
                updateRow[6] = textBox1.Text;
                updateRow[7] = numericUpDown1.Value;
                updateRow[8] = numericUpDown2.Value;
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

        private void buttonChange_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables[0];
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
