using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.Model;
using System.Text;
using System.Text.Json;

namespace WebClient.Pages
{
    public class AdminModel : PageModel
    {
        public List<Admin> Admin = new List<Admin>();
        public async Task<IActionResult> OnGet()
        {
            string url = "https://localhost:7202/api/DebraAdmin";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    Admin = await response.Content.ReadFromJsonAsync<List<Admin>>();
                }
                else
                    throw new Exception(response.StatusCode.ToString());
            }
            return Page();
        }
    }
}

