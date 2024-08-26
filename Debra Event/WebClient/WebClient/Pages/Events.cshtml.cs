using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.Model;

namespace WebClient.Pages
{
    public class EventsModel : PageModel
    {
        public List<Events> Events = new List<Events>();
        public async Task<IActionResult> OnGet()
        {
            string url = "https://localhost:7202/api/CreateEvent";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    Events = await response.Content.ReadFromJsonAsync<List<Events>>();
                }
                else
                    throw new Exception(response.StatusCode.ToString());
            }
            return Page();
        }
    }
}

