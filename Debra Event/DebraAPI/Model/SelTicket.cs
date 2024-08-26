using System.ComponentModel.DataAnnotations;
namespace DebraAPI.Model
{
    public class SelTicket
    {
       
        public int Id { get; set; }
        

        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsSold { get; set; }
        public decimal Commision { get; set; }
        public DateTime? SelDate { get; set; }

        public int EventId { get; set; }







    }
}
