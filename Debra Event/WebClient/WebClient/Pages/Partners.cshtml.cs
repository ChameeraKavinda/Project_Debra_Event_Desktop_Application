using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.Model;
namespace WebClient.Pages
{
    public class PartnersModel : PageModel
    {
      
            public List<Partners> Partners = new List<Partners>();
        public async Task<IActionResult> OnGet()
        {
            string url = "https://localhost:7202/api/Partner";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    Partners = await response.Content.ReadFromJsonAsync<List<Partners>>();
                }
                else
                    throw new Exception(response.StatusCode.ToString());
            }
            return Page();
        }
            }
        
}

