using Nancy.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DebraEvents.EventOption;

namespace DebraEvents
{
    public partial class TicketOption : Form
    {
        int id = 0;
        public int eventNid;
        public TicketOption(int eventNid)
        {
            InitializeComponent();
            loadEventOption(id);
        }
        public void loadEventOption(int id)
        {
            string url = "https://localhost:7202/api/SelTicketControlles/event/" + id;
            using (HttpClient httpClient = new HttpClient())
            {
                var responce = httpClient.GetStringAsync(url).Result;
                if (!string.IsNullOrEmpty(responce))
                {
                    var eventOption = new JavaScriptSerializer().Deserialize<List<SelTicket>>(responce);
                    dgvTicket.DataSource = eventOption;
                }
                else
                {
                    dgvTicket.DataSource = null;
                }

            }
        }
        public TicketOption()
        {
            InitializeComponent();

        }

        private void TicketOption_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string url = "https://localhost:7202/api/SelTicketControlles/event/" + id;
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            dgvTicket.DataSource = null;
            dgvTicket.DataSource = (new JavaScriptSerializer()).Deserialize<List<SelTicket>>(json);

        }
        public class SelTicket
        {

            public int Id { get; set; }


            public string Title { get; set; }
            public decimal Price { get; set; }
            public bool IsSold { get; set; }
            //public decimal Commision { get; set; }
            public DateTime? SelDate { get; set; }
            //public int EventId { get; set; }


        }

        private void btnTAdd_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/SelTicketControlles?eventId=" + id;
            HttpClient httpclient = new HttpClient();
            SelTicket selTicket = new SelTicket();
            selTicket.Title = txtTTitle.Text;
            selTicket.Price = Convert.ToDecimal(txtTPrice.Text);
            selTicket.IsSold = true;
            selTicket.IsSold = false;
            //selTicket.Commision = Convert.ToDecimal(txtTCommision.Text); ;
            selTicket.SelDate = DateTime.Now;

            string data = (new JavaScriptSerializer()).Serialize(selTicket);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpclient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Ticket Added");
                LoadData();

            }
            else
                MessageBox.Show("Failed to Ticket Added");
        }

        private void dgvTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col == 0)
            {
                txtTID.Text = dgvTicket.Rows[row].Cells[1].Value.ToString();
                txtTTitle.Text = dgvTicket.Rows[row].Cells[2].Value.ToString();
                txtTPrice.Text = dgvTicket.Rows[row].Cells[3].Value.ToString();
                txtTIsSold.Text = dgvTicket.Rows[row].Cells[4].Value.ToString();
                //txtTCommision.Text = dgvTicket.Rows[row].Cells[5].Value.ToString();
                txtTDate.Text = dgvTicket.Rows[row].Cells[5].Value.ToString();
               // txtEventID.Text = dgvTicket.Rows[row].Cells[6].Value.ToString();

                id = Convert.ToInt32(dgvTicket.Rows[row].Cells[1].Value.ToString());
            }
        }

        
        private void btnTDashboard_Click(object sender, EventArgs e)
        {
            DebraDashboard debraDashboard = new DebraDashboard();
            debraDashboard.Show();
            this.Hide();
        }

        private void btnTSellTicket_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you");
            /*SelTicketDisplay selTicketDisplay = new SelTicketDisplay();
            selTicketDisplay.Show();
            this.Hide(); */

            string url = "https://localhost:7202/api/SelTicketControlles/" + id;
            HttpClient httpclient = new HttpClient();
            SelTicket selTicket = new SelTicket();
            selTicket.Id = id;
            selTicket.IsSold = true;


            string data = (new JavaScriptSerializer()).Serialize(selTicket);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpclient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Ticket Sold");
                LoadData();

            }
            else
                MessageBox.Show("Failed to Ticket Sold Out");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            EventOption eventOption = new EventOption();
            eventOption.Show();
            this.Hide();
        }
    }
}
