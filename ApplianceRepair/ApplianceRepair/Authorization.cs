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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = maskedTextBox1.Text;
            string password = maskedTextBox2.Text;
            int commNum = 0;
            if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Server=DESKTOP-8FID4AN\SQLEXPRESS;Database=Goncharov_419/5_17;Trusted_Connection=True;");
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM [Users] WHERE [Login] = {login} and [Password] = {password} ", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    string getRole = (string)reader.GetValue(2);
                    reader.Close();
                    string sqlCurrentTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fff");
                    try
                    {
                        command = new SqlCommand($"INSERT INTO [LogInHistory] VALUES ({login}, '{sqlCurrentTime}')", connection);
                        commNum = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (getRole == "Admin")
                    {
                        this.Hide();
                        Admin admin = new Admin(this);
                        admin.Show();
                    }
                    else if (getRole == "User")
                    {
                         this.Hide();
                         User user = new User(this);
                         user.Show();
                    }
                    else if (getRole == "Client")
                    {
                         this.Hide();
                         Client client = new Client(this);
                         client.Show();
                    }
                    else
                    {
                        MessageBox.Show("Вы не зарегистрированы, обратитесь к администратору");
                    }
                }
                else
                {
                    MessageBox.Show("Введенные данные неверны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    maskedTextBox1.Clear();
                    maskedTextBox2.Clear();
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля для авторизации!");
            }
        }
    }
}
