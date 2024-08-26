using System.ComponentModel.DataAnnotations;

namespace DebraAPI.DTO
{
    public class CreateEventCreateDTO
    {
        [Required]

        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime? Date { get; set; }
        
    }
}
