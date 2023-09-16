using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplianceRepair
{
    public partial class Admin : Form
    {
        private Authorization authorization;

        public Admin(Authorization au)
        {
            InitializeComponent();
            authorization = au;
        }

        private void employeesUpdate_Click(object sender, EventArgs e)
        {
            Employees updateEmployees = new Employees(this);
            updateEmployees.Show();
            this.Hide();
        }

        private void productsUpdate_Click(object sender, EventArgs e)
        {
            Products updateProducts = new Products(this);
            updateProducts.Show();
            this.Hide();
        }

        private void executionsUpdate_Click(object sender, EventArgs e)
        {
            Executions updateExecutions = new Executions(this);
            updateExecutions.Show();
            this.Hide();
        }

        private void ordersUpdate_Click(object sender, EventArgs e)
        {
            Orders updateOrders = new Orders(this);
            updateOrders.Show();
            this.Hide();
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            authorization.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
