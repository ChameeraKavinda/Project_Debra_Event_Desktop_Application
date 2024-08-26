using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebraEvents
{ 
    public partial class DebraDashboard : Form
    {
       
        public int PartnerID;
        public int eventNid;
        public DebraDashboard(int id)
        {
            InitializeComponent();
            PartnerID = id;
            eventNid = id;
        }

        public DebraDashboard()
        {
            InitializeComponent();

        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            EventOption eventOption = new EventOption(PartnerID);
            eventOption.Show();
            this.Hide();
        }

        private void btnSellTecket_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to Sell Ticket", "Sell Ticket",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                MessageBox.Show("Event Add First");
                /*EventOption eventOption = new EventOption();
                eventOption.Show();
                this.Hide();*/

            }

        }

        private void DebraDashboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
