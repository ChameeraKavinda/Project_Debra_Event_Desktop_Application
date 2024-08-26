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
using static DebraEvents.Login;

namespace DebraEvents
{
    public partial class DebraAdmin : Form
    {
        public DebraAdmin()
        {
            InitializeComponent();
        }

        private void btnDLogin_Click(object sender, EventArgs e)
        {
            /*string UserName, Password;
            UserName=txtDUerName.Text;
            Password=txtDPassword.Text;
            if(UserName=="DebraAdmin" && Password == "Admin123")
            {
                MessageBox.Show("Loging Successfull");
            }
            else MessageBox.Show("Loging UnSuccessfull");

            SelTicketDisplay selTicketDisplay = new SelTicketDisplay();
            selTicketDisplay.Show();
            this.Hide();*/


            string url = "https://localhost:7202/api/DebraAdmin/Login";

            HttpClient httpclient = new HttpClient();
            LoginDebraAdmin loginDebraAdmin = new LoginDebraAdmin();
            loginDebraAdmin.AdminEmail = txtDUerName.Text;
            loginDebraAdmin.AdminPassword = txtDPassword.Text;
            string data = (new JavaScriptSerializer()).Serialize(loginDebraAdmin);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpclient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Login");
                LoadData();
                {
                    DebraAdminOption debraAdminOption = new DebraAdminOption();
                    debraAdminOption.Show();
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Login Failed");

            
             
                

        }

        public class LoginDebraAdmin
        {
            public string AdminEmail { get; set; }

            public string AdminPassword { get; set; }
        }

     

        private void DebraAdmin_Load(object sender, EventArgs e)
        {
           LoadData();  
        }

        private void LoadData()
        {
            string url = "https://localhost:7202/api/DebraAdmin/Login";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;

        }

        private void btnDLogin_Click_1(object sender, EventArgs e)
        {
            string url = "https://localhost:7202/api/DebraAdmin/Login";

            HttpClient httpclient = new HttpClient();
            LoginDebraAdmin loginDebraAdmin = new LoginDebraAdmin();
            loginDebraAdmin.AdminEmail = txtDUerName.Text;
            loginDebraAdmin.AdminPassword = txtDPassword.Text;
            string data = (new JavaScriptSerializer()).Serialize(loginDebraAdmin);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpclient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Admin Login");
                LoadData();
                {
                    DebraAdminOption debraAdminOption = new DebraAdminOption();
                    debraAdminOption.Show();
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Admin Login Failed");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DebraOption debraOption = new DebraOption();
            debraOption.Show();
            this.Hide();
        }
    }
}
