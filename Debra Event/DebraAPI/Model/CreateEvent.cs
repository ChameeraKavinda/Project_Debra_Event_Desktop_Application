using System.ComponentModel.DataAnnotations;

namespace DebraAPI.Model
{
    public class CreateEvent
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime? Date { get; set; }
        public int PartnerId {  get; set; }
        


    }
}
