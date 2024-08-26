using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.Model;

namespace WebClient.Pages
{
    public class TicketsModel : PageModel
    {
        public List<Tickets> Tickets = new List<Tickets>();
        public async Task<IActionResult> OnGet()
        {
            string url = "https://localhost:7202/api/SelTicketControlles";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    Tickets = await response.Content.ReadFromJsonAsync<List<Tickets>>();
                }
                else
                    throw new Exception(response.StatusCode.ToString());
            }
            return Page();
        }
    }
}

