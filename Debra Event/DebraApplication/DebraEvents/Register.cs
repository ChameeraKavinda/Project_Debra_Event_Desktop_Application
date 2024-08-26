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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        public class Partner
        {
            public int Id {get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Password {  get; set; }

        }


        


            

        private void Register_Load(object sender, EventArgs e)
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
        }

        private void btnRRegister_Click_1(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/Partner";
            HttpClient httpclient = new HttpClient();
            Partner partner = new Partner();
            partner.Name = txtRPartnerName.Text;
            partner.Address = txtRAddress.Text;
            partner.Email = txtREmail.Text;
            partner.PhoneNumber = txtRPhoneNumber.Text;
            partner.Password = txtRPassword.Text;

            string data = (new JavaScriptSerializer()).Serialize(partner);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpclient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Registerd");
                LoadData();
                {
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Failed to Registerd");

        }

       

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Register_Load_1(object sender, EventArgs e)
        {

        }
    }

    
        
    }
