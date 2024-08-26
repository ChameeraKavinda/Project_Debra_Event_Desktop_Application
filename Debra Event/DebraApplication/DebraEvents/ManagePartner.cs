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
    public partial class ManagePartner : Form
    {
        int id = 0;
        public ManagePartner()
        {
            InitializeComponent();
        }

        private void ManagePartner_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string url = "https://localhost:7202/api/Partner";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            dgvPartner.DataSource = null;
            dgvPartner.DataSource = (new JavaScriptSerializer()).Deserialize<List<Partner>>(json);
        }

        public class Partner
        {
            public int Id { get; set; }
            

            public string Name { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Password { get; set; } = string.Empty;

        }

        private void btnAdminAdd_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAdminUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDeleteAdmin_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DebraAdminOption debraAdminOption = new DebraAdminOption();
            debraAdminOption.Show();
            this.Hide();
        }

        private void btnUpdatePartner_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/Partner/" + id;
            HttpClient httpclient = new HttpClient();
            Partner partner = new Partner();
            partner.Id = id;
            partner.Name = txtPartnerName.Text;
            partner.Address = txtPartnerAddress.Text;
            partner.Email = txtPartnerEmail.Text;
            partner.PhoneNumber = txtPartnerPhoneNumber.Text;
            partner.Password = txtPartnerPassword.Text;


            string data = (new JavaScriptSerializer()).Serialize(partner);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpclient.PutAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Partner Details Updated");
                LoadData();

            }
            else
                MessageBox.Show("Failed to AdmPartner Details Updated");
        }

        private void btnDeletePartner_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/Partner/" + id;
            HttpClient httpclient = new HttpClient();
            Partner partner = new Partner();
            DialogResult result = MessageBox.Show("Are you want to delete", "Delete Partner Details",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var res = httpclient.DeleteAsync(url).Result;
                if (res.IsSuccessStatusCode)
                {
                    LoadData();
                    txtPartnerID.Clear();
                    txtPartnerName.Clear();
                    txtPartnerAddress.Clear();
                    txtPartnerEmail.Clear();
                    txtPartnerPhoneNumber.Clear();
                    txtPartnerPassword.Clear();


                }

            }
        }
/*
        private void btnPartnerADD_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/Partner";
            HttpClient httpclient = new HttpClient();
            Partner partner = new Partner();
            partner.Name = txtPartnerName.Text;
            partner.Address = txtPartnerAddress.Text;
            partner.Email = txtPartnerEmail.Text;
            partner.PhoneNumber = txtPartnerPhoneNumber.Text;
            partner.Password = txtPartnerPassword.Text;



            string data = (new JavaScriptSerializer()).Serialize(partner);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpclient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Partner Details Added");
                LoadData();

            }
            else
                MessageBox.Show("Failed to Partner Details Added");
        }*/

        private void dgvPartner_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col == 0)
            {
                txtPartnerID.Text = dgvPartner.Rows[row].Cells[1].Value.ToString();
                txtPartnerName.Text = dgvPartner.Rows[row].Cells[2].Value.ToString();
                txtPartnerAddress.Text = dgvPartner.Rows[row].Cells[3].Value.ToString();
                txtPartnerEmail.Text = dgvPartner.Rows[row].Cells[1].Value.ToString();
                txtPartnerPhoneNumber.Text = dgvPartner.Rows[row].Cells[2].Value.ToString();
                txtPartnerPassword.Text = dgvPartner.Rows[row].Cells[3].Value.ToString();


                id = Convert.ToInt32(dgvPartner.Rows[row].Cells[1].Value.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DebraAdminOption debraAdminOption = new DebraAdminOption();
            debraAdminOption.Show();
            this.Hide();
        }
    }
}
