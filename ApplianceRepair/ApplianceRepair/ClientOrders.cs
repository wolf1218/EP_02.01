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
    public partial class ClientOrders : Form
    {
        private Client client;
        int b;
        public ClientOrders(Client cl)
        {
            InitializeComponent();
            client = cl;
        }

        private void ClientOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != 0)
            {
                pictureBox1.Image = Image.FromFile(comboBox1.Text);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void ClientOrders_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void Order_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                b = 0;
            }
            else
            {
                b = 1;
            }
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-8FID4AN\SQLEXPRESS;Database=Goncharov_419/5_17;Trusted_Connection=True;"))
            {
                try
                {
                    connection.Open();
                    int getKey;
                    SqlCommand command = new SqlCommand
                        ($"INSERT INTO Products VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}'," +
                        $" '{dateTimePicker1.Value}', '{comboBox1.Text}')", connection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand
                        ($"SELECT ProductKey FROM Products WHERE Name = '{textBox1.Text}' AND Company = '{textBox2.Text}' AND " +
                        $" Model = '{textBox3.Text}' AND Specifications = '{textBox4.Text}'", connection);
                    command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    getKey = (int)reader[0];
                    reader.Close();
                    command = new SqlCommand
                        ($"INSERT INTO Orders VALUES ({getKey}, '{textBox5.Text}', {b}, '{dateTimePicker2.Value}')", connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Ожидайте подтверждения заказ", "Заявка оформлена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
