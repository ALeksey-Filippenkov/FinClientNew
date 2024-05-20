using FinCommon.AdditionalClasses;
using FinCommon.DTO;
using FinServer.DbModels;

namespace FinServer.Services
{
    public class AdminService
    {
        private readonly ApplicationContext _context;
        private UserDataOfTheProgramDTO _userDataOfTheProgram;
        private List<DbPerson> _user;

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

        public UserDataOfTheProgramDTO GetUsersOfTheProgram(SearchForUserDataDTO dto)
        {
            var searchInfo = _context.Persons.Where(p => p.Name.ToLower().Contains(dto.SearchString) && p.Name.Length > 0 ||
                                                         p.Surname.ToLower().Contains(dto.SearchString) &&
                                                         p.Surname.Length > 0 ||
                                                         p.City.ToLower().Contains(dto.SearchString) && p.City.Length > 0 ||
                                                         p.Address.ToLower().Contains(dto.SearchString) && p.Address.Length > 0 ||
                                                         p.Age.ToString().Contains(dto.SearchString)).ToList();


            if (dto.SearchString.Length != 0 && dto.Index == -1 || dto.Index == 0)
            {
                _user = searchInfo;
                return SavingFilteredUserInformation();
            }

            if (dto.SearchString.Length != 0 && dto.Index == 1)
            {
                _user = searchInfo.Where(i => i.IsBanned == true).ToList();
                return SavingFilteredUserInformation();
            }

            if (dto.SearchString.Length != 0 && dto.Index == 2)
            {
                _user = searchInfo.Where(i => i.IsBanned == false).ToList();
                return SavingFilteredUserInformation();

            }

            if (dto.SearchString.Length == 0 && dto.Index == 1)
            {
                _user = _context.Persons.Where(s => s.IsBanned == true).ToList();
                return SavingFilteredUserInformation();
            }

            _user = _context.Persons.ToList();
            return SavingFilteredUserInformation();
        }

        private UserDataOfTheProgramDTO SavingFilteredUserInformation()
        {
            _userDataOfTheProgram = new UserDataOfTheProgramDTO
            {
                UsersOfTheProgram = new List<UserData>()
            };

            foreach (var item in _user)
            {
                var userData = new UserData()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    City = item.City,
                    Address = item.Address,
                    Age = item.Age,
                    PhoneNumber = item.PhoneNumber,
                    EmailAddress = item.EmailAddress,
                    IsBanned = item.IsBanned,
                };
                _userDataOfTheProgram.UsersOfTheProgram.Add(userData);
            }
            return _userDataOfTheProgram;
        }
    }
}
