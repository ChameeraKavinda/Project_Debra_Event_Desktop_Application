using DebraAPI.Model;

namespace DebraAPI.Data
{
    public interface ISelTicketRepo
    {
        bool Save();

        SelTicket GetSelTicket(int id);
        bool CreateSelTicket(SelTicket selTicket);
        bool UpdateSelTicket(SelTicket selTicket);
        bool DeleteSelTicket(SelTicket selTicket);

       
        IEnumerable<SelTicket> GetAllSelTickets();

        IEnumerable<SelTicket> GetSelTicketsByEventId(int eventId);

    }
}
