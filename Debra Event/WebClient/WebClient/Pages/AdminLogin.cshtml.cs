using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using WebClient.Model;

namespace WebClient.Pages
{
    public class AdminLoginModel : PageModel
    {
        [BindProperty]
        public string AdminEmail { get; set; }

        [BindProperty]
        public string AdminPassword { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var admin = new Admin
                {
                    AdminEmail = AdminEmail,
                    AdminPassword = AdminPassword
                };

                string url = "https://localhost:7202/api/DebraAdmin/login";
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var json = JsonSerializer.Serialize(admin);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        // Handle successful login here, e.g., redirect to the admin dashboard
                        return RedirectToPage("/Option");
                    }
                    else
                    {
                        ErrorMessage = "Invalid email or password.";
                    }
                }
            }
            return Page();
        }

    }
}
