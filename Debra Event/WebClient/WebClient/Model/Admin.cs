using System.ComponentModel.DataAnnotations;

namespace WebClient.Model
{
    public class Admin
    {
        public int AdminId { get; set; }

        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; } = string.Empty;
    }
}
