using FinCommon.DTO;
using FinServer.DbModels;

namespace FinServer.Services
{
    public class AdminService
    {
        private readonly ApplicationContext _context;

        public AdminService()
        {
            _context = new ApplicationContext();
        }

        public AdminNameDTO GetAdministratorsName(Guid id)
        {
            var nameAdmin = _context.Admins.First(n => n.Id == id);

            return new AdminNameDTO
            {
                AdministratorName = string.Join(" ", nameAdmin.Name + nameAdmin.Surname)
            };
        }
    }
}
