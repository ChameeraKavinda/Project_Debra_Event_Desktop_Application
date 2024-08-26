using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.Model;

namespace WebClient.Pages
{
    public class ItemsModel : PageModel
    {
        public List<Items>Items=new List<Items>();
        public async Task<IActionResult> OnGet()
        {
            string url = "https://localhost:7202/api/Partner";
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    Items = await response.Content.ReadFromJsonAsync<List<Items>>();
                }
                else
                    throw new Exception(response.StatusCode.ToString());
            }
            return Page();

        }
    }
}
