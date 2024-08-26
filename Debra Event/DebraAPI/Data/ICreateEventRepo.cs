using DebraAPI.Model;

namespace DebraAPI.Data
{
    public interface ICreateEventRepo
    {
        bool Save();

        CreateEvent GetCreateEvent(int id);
        bool CreateCreateEvent(CreateEvent createEvent);
        bool UpdateCreateEvent(CreateEvent createEvent);
        bool DeleteCreateEvent(CreateEvent createEvent);

       
        IEnumerable<CreateEvent> GetAllCreateEvents();
        IEnumerable<CreateEvent> GetEventsByPartnerId(int partnerId);

    }
}
