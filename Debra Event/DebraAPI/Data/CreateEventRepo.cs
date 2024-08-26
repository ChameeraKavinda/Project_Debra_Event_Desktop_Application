using DebraAPI.Model;
namespace DebraAPI.Data
{
    public class CreateEventRepo : ICreateEventRepo
    {
        private DebraAddDBContext _dbContext;
        
        public CreateEventRepo(DebraAddDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateCreateEvent(CreateEvent createEvent)
        {
            if (createEvent != null)
            {
                _dbContext.CreateEvents.Add(createEvent);
                return Save();
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCreateEvent(CreateEvent createEvent)
        {
            if (createEvent != null)
            {
                _dbContext.CreateEvents.Remove(createEvent);
                return Save();
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<CreateEvent> GetAllCreateEvents()
        {
            return _dbContext.CreateEvents.ToList();
        }

        public CreateEvent GetCreateEvent(int id)
        {
            return _dbContext.CreateEvents.FirstOrDefault(CreateEvent => CreateEvent.Id == id);
        }

        public bool Save()
        {
            int count = _dbContext.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool UpdateCreateEvent(CreateEvent createEvent)
        {
            if(!_dbContext.Partners.Any(p => p.Id != createEvent.PartnerId))
            {
                throw new InvalidOperationException("Invalid PartnerId");
            }
            _dbContext.CreateEvents.Update(createEvent);
            return Save();
        }

        public IEnumerable<CreateEvent> GetEventsByPartnerId(int partnerId)
        {
            return _dbContext.CreateEvents.Where(e => e.PartnerId == partnerId).ToList();
        }






    }
}

    

