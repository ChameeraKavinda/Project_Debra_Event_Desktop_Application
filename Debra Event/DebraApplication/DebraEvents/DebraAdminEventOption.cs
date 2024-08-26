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
    public partial class DebraAdminEventOption : Form
    {
        int id =0;
        public DebraAdminEventOption()
        {
            InitializeComponent();
        }

        private void DebraAdminEventOption_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string url = "https://localhost:7202/api/CreateEvent";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            dgvAdminEventO.DataSource = null;
            dgvAdminEventO.DataSource = (new JavaScriptSerializer()).Deserialize<List<CreateEvent>>(json);
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

        private void btnEDashboard_Click(object sender, EventArgs e)
        {
            DebraAdminOption debraAdminOption = new DebraAdminOption();
            debraAdminOption.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/CreateEvent/" + id;
            HttpClient httpclient = new HttpClient();
            CreateEvent createEvent = new CreateEvent();
            DialogResult result = MessageBox.Show("Are you want to remove", "Remove Event",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var res = httpclient.DeleteAsync(url).Result;
                if (res.IsSuccessStatusCode)
                {
                    LoadData();
                    txtAEventID.Clear();
                    txtAEName.Clear();
                    txtAEventType.Clear();
                    txtALocation.Clear();
                    txtAEDate.Clear();

                }

            }
        }

        private void dgvAdminEventO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col == 0)
            {
                txtAEventID.Text = dgvAdminEventO.Rows[row].Cells[1].Value.ToString();
                txtAEName.Text = dgvAdminEventO.Rows[row].Cells[2].Value.ToString();
                txtAEventType.Text = dgvAdminEventO.Rows[row].Cells[3].Value.ToString();
                txtALocation.Text = dgvAdminEventO.Rows[row].Cells[4].Value.ToString();
                txtAEDate.Text = dgvAdminEventO.Rows[row].Cells[5].Value.ToString();
                txtAPartnerID.Text = dgvAdminEventO.Rows[row].Cells[6].Value.ToString();

                id = Convert.ToInt32(dgvAdminEventO.Rows[row].Cells[1].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/CreateEvent/" +id;
            HttpClient httpclient = new HttpClient();
            CreateEvent createEvent = new CreateEvent();
            createEvent.Id = id;
            createEvent.Name = txtAEName.Text;
            createEvent.Description = txtAEventType.Text;
            createEvent.Location = txtALocation.Text;
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
    }
}
