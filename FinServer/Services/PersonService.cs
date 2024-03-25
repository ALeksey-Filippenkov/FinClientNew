namespace FinServer.Services
{
    public class PersonService
    {
        private readonly ApplicationContext _context;
        private DbPerson _searchAccount;

        public PersonService()
        {
            _context = new ApplicationContext();
        }

        public ValidationRegistrationResultDTO CheckingTheEnteredData(UserDataDTO dto)
        {
            var ageValue = int.TryParse(dto.Age, out var ageInt);
            if (!ageValue)
            {

                return new ValidationRegistrationResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>  {{ "AgeError", "Возраст должен быть в виде числа" } }
                };
            }

            var phoneNumberValue = int.TryParse(dto.PhoneNumber, out var phoneNumberInt);
            if (!phoneNumberValue)
            {
                return new ValidationRegistrationResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>
                        { { "PhoneNumberError", "Номер телефона должен быть в виде числа" } }
                };
            }

            var isLoginExist = _context.Persons.Any(p => p.Login == dto.Login);
            if (isLoginExist)
            {
                return new ValidationRegistrationResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string> { { "LoginError", $"Пользователь с логином: {dto.Login} уже существует" } }
                };
            }

            return AddPerson(dto, ageInt, phoneNumberInt);
        }

        private ValidationRegistrationResultDTO AddPerson(UserDataDTO dto, int age, int phoneNumber)
        {
            _context.Add(new DbPerson
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Surname = dto.Surname,
                Age = age,
                City = dto.City,
                Address = dto.Address,
                PhoneNumber = phoneNumber,
                EmailAddress = dto.EmailAddress,
                Login = dto.Login,
                Password = dto.Password,
                IsBanned = false
            });
            _context.SaveChanges();

            return new ValidationRegistrationResultDTO()
            {
                IsSuccess = true,
                Message = new Dictionary<string, string>() { { "Congratulations", "Поздравляем! Вы успешно прошли регистрацию" } }
            };
        }

        public ValidationAuthorizationResultDTO Verification(LoginInputDataDTO dto)
        {
            _searchAccount = _context.Persons.FirstOrDefault(e => e.Login == dto.Login);
            //var searchAdmin = _context.Admins.FirstOrDefault(admin => admin.Login == loginInput.Text && admin.Password == passwordInput.Text);


            if (_searchAccount == null)
            {
                return new ValidationAuthorizationResultDTO
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { { "SearchUserError", "Пользователь с таким логином не найден" } }
                };
            }

            if (_searchAccount.Password != dto.Password)
            {
                return new ValidationAuthorizationResultDTO
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { { "PasswordError", "Не верный пароль" } }
                };
            }

            if (_searchAccount.IsBanned)
            {
                return new ValidationAuthorizationResultDTO
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { { "UserIsBannedError", "Пользователь забанен" } }
                };
            }

            return new ValidationAuthorizationResultDTO
            {
                IsSuccess = true,
                idAccount = _searchAccount.Id,
            };
        }

        public DbPerson SearchUserData(Guid id)
        {
            var user = _context.Persons.First(i => i.Id == id);
            return user;
        }

        public ValidationRegistrationResultDTO CheckingTheEnteredData(Guid id, UserDataDTO dto)
        {
            var ageValue = int.TryParse(dto.Age, out var ageInt);
            if (!ageValue)
            {

                return new ValidationRegistrationResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string> { { "AgeError", "Возраст должен быть в виде числа" } }
                };
            }

            var phoneNumberValue = int.TryParse(dto.PhoneNumber, out var phoneNumberInt);
            if (!phoneNumberValue)
            {
                return new ValidationRegistrationResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>
                        { { "PhoneNumberError", "Номер телефона должен быть в виде числа" } }
                };
            }

            var user = _context.Persons.FirstOrDefault(i => i.Id == id);
            if (dto.Login != user.Login)
            {
                var isLoginExist = _context.Persons.Any(p => p.Login == dto.Login);
                if (isLoginExist)
                {
                    return new ValidationRegistrationResultDTO()
                    {
                        IsSuccess = false,
                        Message = new Dictionary<string, string> { { "Login", "Пользователь с таким логином уже существует" } }
                    };
                }
            }

            return SavingChangesUsersPersonalData(dto, user, ageInt, phoneNumberInt);
        }

        public ValidationRegistrationResultDTO SavingChangesUsersPersonalData(UserDataDTO dto, DbPerson user, int age, int phoneNumber)
        {
            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.Age = age;
            user.City = dto.City;
            user.Address = dto.Address;
            user.PhoneNumber = phoneNumber;
            user.EmailAddress = dto.EmailAddress;
            user.Login = dto.Login;
            user.Password = dto.Password;

            _context.SaveChanges();

            return new ValidationRegistrationResultDTO
            {
                IsSuccess = true,
                Message = new Dictionary<string, string> { { "Congratulations", "Данные успешно сохранены!" } }
            };
        }
    }
}