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
    public partial class Client : Form
    {
        private Authorization authorization;
        public Client(Authorization au)
        {
            InitializeComponent();
            authorization = au;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            authorization.Close();
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            authorization.Show();
        }

        private void clientOrders_Click(object sender, EventArgs e)
        {
            ClientOrders newOrder = new ClientOrders(this);
            newOrder.Show();
            this.Hide();
        }
    }
}
