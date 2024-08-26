using DebraAPI.Model;

namespace DebraAPI.Data
{
    public interface IDebraAdminRepo
    {
        bool AdminSave();

        DebraAdmin GetDebraAdmin(int id);
        bool CreateDebraAdmin(DebraAdmin debraAdmin);
        bool UpdateDebraAdmin(DebraAdmin debraAdmin);
        bool DeleteDebraAdmin(DebraAdmin debraAdmin);

        DebraAdmin DebraAdminLogin(string username, string password);
        IEnumerable<DebraAdmin> GetAllDebraAdmins();
    }
}
