using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebraEvents
{
    public partial class DebraAdminOption : Form
    {
        public DebraAdminOption()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DebraAdminRegister debraAdminRegister = new DebraAdminRegister();
            debraAdminRegister.Show();
            this.Hide();
        }

        private void btnSellTicket_Click(object sender, EventArgs e)
        {
            SelTicketDisplay selTicketDisplay = new SelTicketDisplay();
            selTicketDisplay.Show();
            this.Hide();
        }

        private void btnVTicket_Click(object sender, EventArgs e)
        {
            DebraAdminTicketOption debraAdminTicketOption = new DebraAdminTicketOption();
            debraAdminTicketOption.Show();
            this.Hide();
        }

        private void btnAView_Click(object sender, EventArgs e)
        {
            DebraAdminEventOption debraAdminEventOption = new DebraAdminEventOption();
            debraAdminEventOption.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();    
        }

        private void btnPartnerMnage_Click(object sender, EventArgs e)
        {
            ManagePartner managePartner = new ManagePartner();
            managePartner.Show();
            this.Hide();
        }
    }
}
