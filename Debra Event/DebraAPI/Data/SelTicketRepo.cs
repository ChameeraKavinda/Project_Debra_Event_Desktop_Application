using DebraAPI.Model;
namespace DebraAPI.Data
{
    public class SelTicketRepo : ISelTicketRepo
    {
        private DebraAddDBContext _dbContext;
        
        public SelTicketRepo(DebraAddDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateSelTicket(SelTicket selTicket)
        {
            if (selTicket != null)
            {
                _dbContext.SelTickets.Add(selTicket);
                return Save();
            }
            else
            {
                return false;
            }
        }

        public bool DeleteSelTicket(SelTicket selTicket)
        {
            if (selTicket != null)
            {
                _dbContext.SelTickets.Remove(selTicket);
                return Save();
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<SelTicket> GetAllSelTickets()
        {
            return _dbContext.SelTickets.ToList();
        }

        public SelTicket GetSelTicket(int id)
        {
            return _dbContext.SelTickets.FirstOrDefault(selTicket => selTicket.Id == id);
        }

        public bool Save()
        {
            int count = _dbContext.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool UpdateSelTicket(SelTicket selTicket)
        {
            _dbContext.SelTickets.Update(selTicket);
            return Save();
        }

        public IEnumerable<SelTicket> GetSelTicketsByEventId(int eventId)
        {
            return _dbContext.SelTickets.Where(t => t.EventId == eventId).ToList();
        }

        
        
    }
}

    

