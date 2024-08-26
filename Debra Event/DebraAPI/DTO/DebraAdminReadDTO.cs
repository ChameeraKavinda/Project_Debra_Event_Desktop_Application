using System.ComponentModel.DataAnnotations;

namespace DebraAPI.DTO
{
    public class DebraAdminReadDTO
    {
        public int AdminId { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; } = string.Empty;
    }
}
