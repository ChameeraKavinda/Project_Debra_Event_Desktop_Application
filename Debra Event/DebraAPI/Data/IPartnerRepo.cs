using DebraAPI.Model;

namespace DebraAPI.Data
{
    public interface IPartnerRepo
    {
        bool Save();

        Partner GetPartner(int id);
        bool CreatePartner(Partner partner);
        bool UpdatePartner(Partner partner);
        bool DeletePartner(Partner partner);

        Partner Login(string username, string password);
        IEnumerable<Partner> GetAllPartners();
           
    }
}
