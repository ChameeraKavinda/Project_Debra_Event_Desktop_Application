using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.Model;
using System.Text;
using System.Text.Json;

namespace WebClient.Pages
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        public Items item { get; set; }
        public async Task<IActionResult> OnPost()//Add Items using post method
        {
            string url = "https://localhost:7084/api/Product/" ;
            var content=new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8,"application/json");
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.PostAsync(url,content);
                if (message.IsSuccessStatusCode)
                    return RedirectToPage("Items");
                else
                    throw new Exception(message.IsSuccessStatusCode.ToString());
            }
        }
    
    }
}
