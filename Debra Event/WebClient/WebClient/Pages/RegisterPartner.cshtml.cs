using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.Model;
using System.Text;
using System.Text.Json;
namespace WebClient.Pages
{
    public class RegisterPartnerModel : PageModel
    {
        [BindProperty]
        public Partners partner { get; set; }
        public async Task<IActionResult> OnPost()
        {
            string url = "https://localhost:7202/api/Partner";
            var content = new StringContent(JsonSerializer.Serialize(partner), Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.PostAsync(url, content);
                if (message.IsSuccessStatusCode)
                    return RedirectToPage("Partners");
                else
                    throw new Exception(message.IsSuccessStatusCode.ToString());
            }
        }
    }
}
