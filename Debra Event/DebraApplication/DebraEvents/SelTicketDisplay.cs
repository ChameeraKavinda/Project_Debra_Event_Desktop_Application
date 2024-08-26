using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DebraEvents
{
    public partial class SelTicketDisplay : Form
    {
        public SelTicketDisplay()
        {
            InitializeComponent();
        }

        private void SelTicketDisplay_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string url = "https://localhost:7202/api/SelTicketControlles";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            dgvSelTicketDisplay.DataSource = null;
            dgvSelTicketDisplay.DataSource = (new JavaScriptSerializer()).Deserialize<List<SelTicket>>(json);

            // Hide unwanted columns
            dgvSelTicketDisplay.Columns["Title"].Visible = false;
            dgvSelTicketDisplay.Columns["SelDate"].Visible = false;
        }

        public class SelTicket
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
            public bool IsSold { get; set; }
            public decimal Commision { get; set; }
            public DateTime? SelDate { get; set; }
        }

        private void dgvSelTicketDisplay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
        }

        private void btnTDashboard_Click(object sender, EventArgs e)
        {
            DebraAdminOption debraAdminOption = new DebraAdminOption();
            debraAdminOption.Show();
            this.Hide();
        }
    }
}
