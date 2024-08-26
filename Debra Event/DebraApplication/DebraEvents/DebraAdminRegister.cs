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
    public partial class DebraAdminRegister : Form
    {
        int id = 0;
        public DebraAdminRegister()
        {
            InitializeComponent();
        }

        private void DebraAdminRegister_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string url = "https://localhost:7202/api/DebraAdmin";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            dgvAdmin.DataSource = null;
            dgvAdmin.DataSource = (new JavaScriptSerializer()).Deserialize<List<DebraAdmin>>(json);
        }

        public class DebraAdmin
        {
            public int AdminId { get; set; }
            public string AdminEmail { get; set; }
            public string AdminPassword { get; set; } = string.Empty;

        }

        private void btnAdminAdd_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/DebraAdmin";
            HttpClient httpclient = new HttpClient();
            DebraAdmin debraAdmin = new DebraAdmin();
            debraAdmin.AdminEmail = txtAdminEmail.Text;
            debraAdmin.AdminPassword = txtAdminPassword.Text;
            

            string data = (new JavaScriptSerializer()).Serialize(debraAdmin);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpclient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Admin Details Added");
                LoadData();

            }
            else
                MessageBox.Show("Failed to Admin Details Added");
        }

        private void btnAdminUpdate_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/DebraAdmin/" + id;
            HttpClient httpclient = new HttpClient();
            DebraAdmin debraAdmin = new DebraAdmin();
            debraAdmin.AdminId = id;
            debraAdmin.AdminEmail = txtAdminEmail.Text;
            debraAdmin.AdminPassword = txtAdminPassword.Text;


            string data = (new JavaScriptSerializer()).Serialize(debraAdmin);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpclient.PutAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Admin Updated");
                LoadData();

            }
            else
                MessageBox.Show("Failed to Admin Updated");
        }

        private void btnDeleteAdmin_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/DebraAdmin/" + id;
            HttpClient httpclient = new HttpClient();
            DebraAdmin debraAdmin = new DebraAdmin();
            DialogResult result = MessageBox.Show("Are you want to delete", "Delete Admin Details",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var res = httpclient.DeleteAsync(url).Result;
                if (res.IsSuccessStatusCode)
                {
                    LoadData();
                    txtAdminID.Clear();
                    txtAdminEmail.Clear();
                    txtAdminPassword.Clear();
                    

                }

            }
        }

        private void dgvAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col == 0)
            {
                txtAdminID.Text = dgvAdmin.Rows[row].Cells[1].Value.ToString();
                txtAdminEmail.Text = dgvAdmin.Rows[row].Cells[2].Value.ToString();
                txtAdminPassword.Text = dgvAdmin.Rows[row].Cells[3].Value.ToString();
               

                id = Convert.ToInt32(dgvAdmin.Rows[row].Cells[1].Value.ToString());
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DebraAdminOption debraAdminOption = new DebraAdminOption();
            debraAdminOption.Show();
            this.Hide();
        }
    }
}
