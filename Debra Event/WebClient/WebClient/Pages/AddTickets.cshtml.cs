using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.Model;
using System.Text;
using System.Text.Json;

namespace WebClient.Pages
{
    public class AddTicketsModel : PageModel
    {
        [BindProperty]
        public Tickets tickets { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        public async Task<IActionResult> OnPost() // Add Items using post method
        {
            string url = "https://localhost:7202/api/SelTicketControlles/";
            var content = new StringContent(JsonSerializer.Serialize(tickets), Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.PostAsync(url, content);
                if (message.IsSuccessStatusCode)
                {
                    SuccessMessage = "Ticket Sell Successfully";
                    return RedirectToPage("");
                }
                else
                {
                    throw new Exception(message.IsSuccessStatusCode.ToString());
                }
            }
        }
    }
}
