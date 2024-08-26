using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebClient.Model;

namespace WebClient.Pages
{
    public class ManageEventsModel : PageModel
    {
        [BindProperty]
        public Events events { get; set; }
        public async Task OnGet(int id)
        {
            string url = "https://localhost:7202/api/CreateEvent/" + id;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync(url);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var content = await responseMessage.Content.ReadAsStringAsync();
                    events = JsonConvert.DeserializeObject<Events>(content);
                }
                else
                    throw new Exception(responseMessage.ToString());
            }

        }
        public async Task<IActionResult> OnPostUpdate()//Update Button using Onpost update method
        {
            string url = "https://localhost:7202/api/CreateEvent/" + events.Id;
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(events), Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.PutAsync(url, content);
                if (message.IsSuccessStatusCode)
                    return RedirectToPage("Events");
                else
                    throw new Exception(message.ToString());
            }
        }
        public async Task<IActionResult> OnPostDelete()//Delete Button using Onpost delete method
        {
            string url = "https://localhost:7202/api/CreateEvent/" + events.Id;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.DeleteAsync(url);
                if (message.IsSuccessStatusCode)
                    return RedirectToPage("Events");
                else
                    throw new Exception(message.ToString());
            }
        }
    }
}


       
