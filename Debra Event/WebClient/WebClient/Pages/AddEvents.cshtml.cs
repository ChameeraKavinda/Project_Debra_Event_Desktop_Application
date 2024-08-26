using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.Model;
using System.Text;
using System.Text.Json;

namespace WebClient.Pages
{
    public class AddEventsModel : PageModel
    {

        [BindProperty]
        public Events events { get; set; }
        public async Task<IActionResult> OnPost()//Add Items using post method
        {
            string url = "https://localhost:7202/api/CreateEvent/";
            var content = new StringContent(JsonSerializer.Serialize(events), Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.PostAsync(url, content);
                if (message.IsSuccessStatusCode)
                    return RedirectToPage("Events");
                else
                    throw new Exception(message.IsSuccessStatusCode.ToString());
            }
        }

    }
}
