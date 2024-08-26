using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.Model;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace WebClient.Pages
{
    public class EditItemsModel : PageModel
    {
        [BindProperty]
        public Items item { get; set; }
        public async Task OnGet(int id)
        {
            string url = "https://localhost:7084/api/Product/" + id;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync(url);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var content = await responseMessage.Content.ReadAsStringAsync();
                    item =  JsonConvert.DeserializeObject<Items>(content);
                }
                else
                    throw new Exception(responseMessage.ToString());
            }
            
        }
        public async Task<IActionResult> OnPostUpdate()//Update Button using Onpost update method
        {
            string url = "https://localhost:7084/api/Product/" + item.Id;
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.PutAsync(url, content);
                if (message.IsSuccessStatusCode)
                    return RedirectToPage("Items");
                else
                    throw new Exception(message.ToString());
            }
        }
        public async Task<IActionResult> OnPostDelete()//Delete Button using Onpost delete method
        {
            string url = "https://localhost:7084/api/Product/" + item.Id;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.DeleteAsync(url);
                if (message.IsSuccessStatusCode)
                    return RedirectToPage("Items");
                else
                    throw new Exception(message.ToString());
            }
        }
    }
}
