using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplianceRepair
{
    public partial class User : Form
    {
        private Authorization authorization;
        public User(Authorization au)
        {
            InitializeComponent();
            this.authorization = au;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            authorization.Close();
        }

        private void employeesExecutions_Click(object sender, EventArgs e)
        {
            Executions updateExecutions = new Executions(this);
            updateExecutions.Show();
            this.Hide();
        }

        private void User_FormClosed(object sender, FormClosedEventArgs e)
        {
            authorization.Show();
        }
    }
}
