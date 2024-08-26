using System.ComponentModel.DataAnnotations;

namespace DebraAPI.DTO
{
    public class SelTicketCreateDTO
    {
       
        [Required]

        public string Title { get; set; }
        [Range(0, double.MaxValue,ErrorMessage ="Please enter value bigger than {1}")]
        public decimal Price { get; set; }
        public bool IsSold { get; set; }
        public decimal Commision { get; set; }
        public DateTime? SelDate { get; set; }
        public int EventId { get; set; }


    }
}
