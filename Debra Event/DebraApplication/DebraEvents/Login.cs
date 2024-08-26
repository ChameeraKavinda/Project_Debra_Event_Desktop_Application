using Nancy;
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
using static DebraEvents.Register;

namespace DebraEvents
{
    public partial class Login : Form
    {
        int id = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            string url = "https://localhost:7202/api/Partner/Login";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            
        }

        public class LoginPartner
        {
            public string Email { get; set; }
         
            public string Password { get; set; }
            public int id { get; set; }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/Partner/Login";

            HttpClient httpclient = new HttpClient();
            LoginPartner loginPartner = new LoginPartner();
            loginPartner.Email=txtLEmail.Text;
            loginPartner.Password=txtLPassword.Text;
            string data = (new JavaScriptSerializer()).Serialize(loginPartner);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpclient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                /*var responsContent = res.Content.ReadAsStringAsync().Result;
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                var responseLogin = jsSerializer.Deserialize<ResponesLogin>(responsContent);
                int id = responseLogin.id;
                string eventurl = "https://localhost:7202/api/CreateEvent/partner/" +id;
                HttpClient httpClient = new HttpClient();*/


                var responsContent = res.Content.ReadAsStringAsync().Result;
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                LoginPartner responseLogin = jsSerializer.Deserialize<LoginPartner>(responsContent);
                MessageBox.Show("Successfully Login");
                DebraDashboard debraDashboard = new DebraDashboard(responseLogin.id);
                //debraDashboard.PartnerID=id;
                debraDashboard.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Login Failed");
        }

        private void txtLPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            DebraAdmin debraAdmin = new DebraAdmin();
            debraAdmin.Show();
            this.Hide();
        }

        public class ResponesLogin
        {
            public int id { get;set;}
        }
    }
}
