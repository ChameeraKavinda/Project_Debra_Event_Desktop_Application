using DebraAPI.Model;
namespace DebraAPI.Data
{
    public class DebraAdminRepo : IDebraAdminRepo
    {
        private DebraAddDBContext _dbContext;

        public DebraAdminRepo(DebraAddDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DebraAdmin DebraAdminLogin(string email, string password)
        {
            return _dbContext.DebraAdmins.FirstOrDefault(p => p.AdminEmail == email && p.AdminPassword == password);
        }
        public bool CreateDebraAdmin(DebraAdmin debraAdmin)
        {
            if (debraAdmin != null)
            {
                _dbContext.DebraAdmins.Add(debraAdmin);
                return AdminSave();
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDebraAdmin(DebraAdmin debraAdmin)
        {
            if (debraAdmin != null)
            {
                _dbContext.DebraAdmins.Remove(debraAdmin);
                return AdminSave();
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<DebraAdmin> GetAllDebraAdmins()
        {
            return _dbContext.DebraAdmins.ToList();
        }

        public DebraAdmin GetDebraAdmin(int id)
        {
            return _dbContext.DebraAdmins.FirstOrDefault(DebraAdmin => DebraAdmin.AdminId == id);
        }

        public bool AdminSave()
        {
            int count = _dbContext.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool UpdateDebraAdmin(DebraAdmin debraAdmin)
        {
            _dbContext.DebraAdmins.Update(debraAdmin);
            return AdminSave();
        }



    }
}



