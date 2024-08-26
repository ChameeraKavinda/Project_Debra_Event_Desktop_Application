using DebraAPI.Model;
namespace DebraAPI.Data
{
    public class PartnerRepo : IPartnerRepo
    {
        private DebraAddDBContext _dbContext;
        
        public PartnerRepo(DebraAddDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Partner Login(string email, string password) 
        { 
            return _dbContext.Partners.FirstOrDefault(p =>p.Email == email && p.Password == password);
        }
        public bool CreatePartner(Partner partner)
        {
            if (partner != null)
            {
                _dbContext.Partners.Add(partner);
                return Save();
            }
            else
            {
                return false;
            }
        }

        public bool DeletePartner(Partner partner)
        {
            if (partner != null)
            {
                _dbContext.Partners.Remove(partner);
                return Save();
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Partner> GetAllPartners()
        {
            return _dbContext.Partners.ToList();
        }

        public Partner GetPartner(int id)
        {
            return _dbContext.Partners.FirstOrDefault(Partner => Partner.Id == id);
        }

        public bool Save()
        {
            int count = _dbContext.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool UpdatePartner(Partner partner)
        {
            _dbContext.Partners.Update(partner);
            return Save();
        }

        
        
    }
}

    

