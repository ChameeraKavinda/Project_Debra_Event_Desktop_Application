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

namespace DebraEvents
{
    public partial class DebraAdminTicketOption : Form
    {
        int id = 0;
        public DebraAdminTicketOption()
        {
            InitializeComponent();
        }

        private void btnTDashboard_Click(object sender, EventArgs e)
        {
            DebraAdminOption debraAdminOption = new DebraAdminOption();
            debraAdminOption.Show();
            this.Hide();
        }

        private void DebraAdminTicketOption_Load(object sender, EventArgs e)
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
            dgvAdminTicketO.DataSource = null;
            dgvAdminTicketO.DataSource = (new JavaScriptSerializer()).Deserialize<List<SelTicket>>(json);
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

        private void dgvAdminTicketO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col == 0)
            {
                txtATicketID.Text = dgvAdminTicketO.Rows[row].Cells[1].Value.ToString();
                txtAENme.Text = dgvAdminTicketO.Rows[row].Cells[2].Value.ToString();
                txtAPrice.Text = dgvAdminTicketO.Rows[row].Cells[3].Value.ToString();
                txtAIsSold.Text = dgvAdminTicketO.Rows[row].Cells[4].Value.ToString();
                txtACommision.Text = dgvAdminTicketO.Rows[row].Cells[5].Value.ToString();
                txtAEveneTDate.Text = dgvAdminTicketO.Rows[row].Cells[6].Value.ToString();
                id = Convert.ToInt32(dgvAdminTicketO.Rows[row].Cells[1].Value.ToString());
            }
        }

        private void btnAUpdate_Click(object sender, EventArgs e)
        {

            string url = "https://localhost:7202/api/SelTicketControlles/" + id;
            HttpClient httpclient = new HttpClient();
            SelTicket selTicket = new SelTicket();
            selTicket.Title = txtAENme.Text;
            selTicket.Price = Convert.ToDecimal(txtAPrice.Text);
            selTicket.IsSold = true;
            selTicket.IsSold = false;
            selTicket.Commision = Convert.ToDecimal(txtACommision.Text); ;
            selTicket.SelDate = DateTime.Now;

            string data = (new JavaScriptSerializer()).Serialize(selTicket);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            //var res = httpclient.PutAsync(url, connect).Result;

            DialogResult result = MessageBox.Show("Are You want to Update This", "Update Ticket",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                var res = httpclient.PutAsync(url, connect).Result;
                if (res.IsSuccessStatusCode)
                {
                    //MessageBox.Show("Successfully Tecket Updated");
                    LoadData();

                }
                else
                    MessageBox.Show("Failed to Ticket Updated");
            }
            

        }

        private void btnADelete_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/SelTicketControlles/" + id;
            HttpClient httpclient = new HttpClient();
            SelTicket selTicket = new SelTicket();
            DialogResult result = MessageBox.Show("Are you want to remove", "Remove Ticket",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var res = httpclient.DeleteAsync(url).Result;
                if (res.IsSuccessStatusCode)
                {
                    LoadData();
                    txtATicketID.Clear();
                    txtAENme.Clear();
                    txtAPrice.Clear();
                    txtAIsSold.Clear();
                    txtACommision.Clear();
                    txtAEveneTDate.Clear();
                }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DebraAdminEventOption debraAdminEventOption = new DebraAdminEventOption();
            debraAdminEventOption.Show();
            this.Hide();
        }

        private void txtAEventID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
