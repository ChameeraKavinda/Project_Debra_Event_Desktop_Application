using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nancy.Json;
using static DebraEvents.Login;
using System.Net.Http;

namespace DebraEvents
{
    public partial class EventOption : Form
    {
        public int eventNid;
        public int PartnerId;
        int id = 0;


        public List<EventOption> events = new List<EventOption>();
        public EventOption(int eventNid)
        {
            InitializeComponent();
            id = eventNid;
            txtEPartnerID.Text = eventNid.ToString();
            loadEventOption(id);
        }
        public EventOption()
        {
            InitializeComponent();
        }

        public void loadEventOption(int id)
        {
             string url = "https://localhost:7202/api/CreateEvent/partner/" + id;
             using (HttpClient httpClient = new HttpClient())
             {
                 var responce = httpClient.GetStringAsync(url).Result;
                 if(!string.IsNullOrEmpty(responce))
                 {
                     var eventOption = new JavaScriptSerializer().Deserialize<List<CreateEvent>>(responce);
                     dgvEvent.DataSource = eventOption;
                 }
                else
                { 
                    dgvEvent.DataSource = null; 
                }
                
             }
        }
        private void EventOption_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string url = "https://localhost:7202/api/CreateEvent/partner/" +id;
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            dgvEvent.DataSource = null;
            dgvEvent.DataSource = (new JavaScriptSerializer()).Deserialize<List<CreateEvent>>(json);
            
        }

        public class CreateEvent
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Location { get; set; }
            public DateTime? Date { get; set; }

            public int PartnerId { get; set; }
        }

        private void btnEAdd_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/CreateEvent?partnerId=" + id;
            HttpClient httpclient = new HttpClient();
            CreateEvent createEvent = new CreateEvent();
            createEvent.Name = txtEName.Text;
            createEvent.Description=txtEDescription.Text;
            createEvent.Location = txtELocation.Text;
            createEvent.Date = DateTime.Now;

           // MessageBox.Show("Successfully Event Added");

            string data = (new JavaScriptSerializer()).Serialize(createEvent);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpclient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Event Added");
                LoadData();
                TicketOption ticketOption = new TicketOption(id);
                ticketOption.Show();
                this.Hide();
               
            }
            else
                MessageBox.Show("Failed to Event Added");
        }

        private void dgvEvent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row=e.RowIndex;
            int col=e.ColumnIndex;
            if(col==0)
            {
                txtEID.Text = dgvEvent.Rows[row].Cells[1].Value.ToString();
                txtEName.Text = dgvEvent.Rows[row].Cells[2].Value.ToString();
                txtEDescription.Text = dgvEvent.Rows[row].Cells[3].Value.ToString();
                txtELocation.Text = dgvEvent.Rows[row].Cells[4].Value.ToString();
                txtEDate.Text = dgvEvent.Rows[row].Cells[5].Value.ToString();
                txtEPartnerID.Text = dgvEvent.Rows[row].Cells[6].Value.ToString();

                id =Convert.ToInt32(dgvEvent.Rows[row].Cells[1].Value.ToString());
            }
        }

        private void btnEUpdate_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/CreateEvent/"+id;
            HttpClient httpclient = new HttpClient();
            CreateEvent createEvent = new CreateEvent();
            createEvent.Id = id;
            createEvent.Name = txtEName.Text;
            createEvent.Description = txtEDescription.Text;
            createEvent.Location = txtELocation.Text;
            createEvent.Date = DateTime.Now;
           

            string data = (new JavaScriptSerializer()).Serialize(createEvent);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpclient.PutAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Event Updated");
                LoadData();

            }
            else
                MessageBox.Show("Failed to Event Updated");
        }

        private void btnEDelete_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/CreateEvent/" + id;
            HttpClient httpclient = new HttpClient();
            CreateEvent createEvent = new CreateEvent();
            DialogResult result=MessageBox.Show("Are you want to delete","Delete Event",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var res= httpclient.DeleteAsync(url).Result;
                if(res.IsSuccessStatusCode)
                {
                    LoadData();
                    txtEID.Clear();
                    txtEName.Clear();
                    txtEDescription.Clear();
                    txtELocation.Clear();
                    txtEDate.Clear();
                    
                }

            }
            
        }

        private void btnEDashboard_Click(object sender, EventArgs e)
        {
            DebraDashboard debraDashboard = new DebraDashboard(PartnerId);
           debraDashboard.Show();
            this.Hide();


        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtEPartnerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
