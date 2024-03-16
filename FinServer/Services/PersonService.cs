using FinCommon.DTO;
using FinServer.DbModels;

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

        public ResultDTO CheckingTheEnteredData(UserDataDTO dto)
        {
            if (dto.Age == string.Empty)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = @"Поле ""Возраст"" обязательно для заполнения"
                };
            }
            if (dto.PhoneNumber == string.Empty)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = @"Поле ""Номер телефона"" обязательно для заполнения"
                };
            }

            var ageValue = int.TryParse(dto.Age, out var ageInt);
            if (ageValue == false)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Возраст должен быть в виде числа"
                };
            }
            switch (ageInt)
            {
                case <= 0:
                    return new ResultDTO
                    {
                        IsSuccess = false,
                        Message = "Возраст не может быть меньше 0"
                    };
                case > 200:
                    return new ResultDTO
                    {
                        IsSuccess = false,
                        Message = "Возраст не может быть больше 200 лет"
                    };
            }

            var phoneNumberValue = int.TryParse(dto.PhoneNumber, out var phoneNumberInt);
            if (phoneNumberValue == false)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Номер телефона должен быть в виде числа"
                };
            }

            if (dto.Login == string.Empty)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Логин не может быть пустым"
                };
            }

            var isLoginExist = _context.Persons.Any(p => p.Login == dto.Login);

            if (isLoginExist)
            {
                return new ResultDTO()
                {
                    IsSuccess = false,
                    Message = "Пользователь с таким логином уже существует"
                };
            }

            if (dto.Password == string.Empty)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Пароль не может быть пустым"
                };
            }

            return AddPerson(dto, ageInt, phoneNumberInt);
        }

        private ResultDTO AddPerson(UserDataDTO dto, int ageInt, int phoneNumberInt)
        {
            _context.Add(new DbPerson
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Surname = dto.Surname,
                Age = ageInt,
                City = dto.City,
                Adress = dto.Adress,
                PhoneNumber = phoneNumberInt,
                EmailAdress = dto.EmailAdress,
                Login = dto.Login,
                Password = dto.Password,
                IsBanned = false
            });
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true
            };
        }

        public ResultDTO Verification(LoginDTO dto)
        {
            _searchAccount = _context.Persons.FirstOrDefault(e => e.Login == dto.Login );
            //var searchAdmin = _context.Admins.FirstOrDefault(admin => admin.Login == loginInput.Text && admin.Password == passwordInput.Text);

            if (dto.Password == string.Empty)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Пароль не может быть пустым"
                };
            }

            if (dto.Login == string.Empty)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Логин не может быть пустым"
                };
            }

            if (_searchAccount == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Пользователь с таким логином не найден"
                };
            }

            if (_searchAccount.Password != dto.Password)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Введен не правильный пароль"
                };
            }

            if (_searchAccount.IsBanned)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Пользователь забанен"
                };
            }

            return new ResultDTO
            {
                IsSuccess = true,
                idAccount = _searchAccount.Id,
            };
        }

        public DbPerson GetDB(Guid id)
        {
            var user = _context.Persons.First(i => i.Id == id);
            return user;
        }

        public ResultDTO CheckingPutTheEnteredData(Guid id, PutUserDataDTO dto)
        {
            if (dto.Age == string.Empty)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = @"Поле ""Возраст"" обязательно для заполнения"
                };
            }
            if (dto.PhoneNumber == string.Empty)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = @"Поле ""Номер телефона"" обязательно для заполнения"
                };
            }

            var ageValue = int.TryParse(dto.Age, out var ageInt);
            if (ageValue == false)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Возраст должен быть в виде числа"
                };
            }
            switch (ageInt)
            {
                case <= 0:
                    return new ResultDTO
                    {
                        IsSuccess = false,
                        Message = "Возраст не может быть меньше 0"
                    };
                case > 200:
                    return new ResultDTO
                    {
                        IsSuccess = false,
                        Message = "Возраст не может быть больше 200 лет"
                    };
            }

            var phoneNumberValue = int.TryParse(dto.PhoneNumber, out var phoneNumberInt);
            if (phoneNumberValue == false)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Номер телефона должен быть в виде числа"
                };
            }

            if (dto.Login == string.Empty)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Логин не может быть пустым"
                };
            }

            var isLoginExist = _context.Persons.Any(p => p.Login == dto.Login);
            var user = _context.Persons.FirstOrDefault(i => i.Id == id);

            if (dto.Login != user.Login)
            {
                if (isLoginExist)
                {
                    return new ResultDTO()
                    {
                        IsSuccess = false,
                        Message = "Пользователь с таким логином уже существует"
                    };
                }
            }

            if (dto.Password == string.Empty)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "Пароль не может быть пустым"
                };
            }

            return PutPerson(dto, user, ageInt, phoneNumberInt);
        }

        public ResultDTO PutPerson(PutUserDataDTO dto, DbPerson user, int ageInt, int phoneNumberInt)
        {
            user.Name= dto.Name;
            user.Surname= dto.Surname;
            user.Age = ageInt;
            user.City = dto.City;
            user.Adress = dto.Adress;
            user.PhoneNumber = phoneNumberInt;
            user.EmailAdress = dto.EmailAdress;
            user.Login = dto.Login;
            user.Password = dto.Password;

            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true
            };
        }
    }
}