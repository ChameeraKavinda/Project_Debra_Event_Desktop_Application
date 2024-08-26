using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using WebClient.Model;

namespace WebClient.Pages
{
    public class PartnerLoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var partner = new Partners
                {
                    Email = Email,
                    Password = Password
                };

                string url = "https://localhost:7202/api/Partner/login";
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var json = JsonSerializer.Serialize(partner);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        
                        return RedirectToPage("/Events");
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
