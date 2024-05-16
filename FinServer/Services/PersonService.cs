using FinancialApp.DataBase.DbModels;
using FinCommon.DTO;
using FinServer.DbModels;
using FinServer.Enum;
using System.Net;
using System.Net.Mail;

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

        /// <summary>
        /// Валидация пользователя для входа в личный кабинет
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AuthorizationResultDTO Verification(LoginInputDataDTO dto)
        {
            _searchAccount = _context.Persons.FirstOrDefault(e => e.Login == dto.Login);

            if (_searchAccount == null)
            {
                var searchAdmin = _context.Admins.FirstOrDefault(admin => admin.Login == dto.Login && admin.Password == dto.Password);

                if (searchAdmin != null && searchAdmin.Login == dto.Login && searchAdmin.Password == dto.Password)
                {
                    return new AuthorizationResultDTO
                    {
                        IsSuccess = true,
                        UserRole = TheUsersRoleInTheProgram.Admin,
                        IdAccount = searchAdmin.Id,
                    };
                }

                var generalAdmin = new DbAdmin() { Password = "admin", Login = "admin", Id = Guid.NewGuid() };

                if (generalAdmin.Login == dto.Login && generalAdmin.Password == dto.Password)
                {
                    return new AuthorizationResultDTO
                    {
                        IsSuccess = true,
                        UserRole = TheUsersRoleInTheProgram.SuperAdmin,
                        IdAccount = generalAdmin.Id,
                    };
                }

                return new AuthorizationResultDTO
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>()
                        { { "SearchUserError", "Пользователь с таким логином не найден" } }
                };
            }

            if (_searchAccount.Password != dto.Password)
            {
                return new AuthorizationResultDTO
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { { "PasswordError", "Не верный пароль" } }
                };
            }

            if (_searchAccount.IsBanned)
            {
                return new AuthorizationResultDTO
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { { "UserIsBannedError", "Пользователь забанен" } }
                };
            }

            return new AuthorizationResultDTO
            {
                IsSuccess = true,
                UserRole = TheUsersRoleInTheProgram.User,
                IdAccount = _searchAccount.Id,
            };
        }

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ValidationRegistrationResultDTO AddingUser(UserDataDTO dto)
        {
            var isLoginExist = _context.Persons.Any(p => p.Login == dto.Login);
            if (isLoginExist)
            {
                return new ValidationRegistrationResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string> { { "LoginError", $"Пользователь с логином: {dto.Login} уже существует" } }
                };
            }
            var isPhoneNumberExist = _context.Persons.Any(p => p.PhoneNumber == dto.PhoneNumber);
            if (isPhoneNumberExist)
            {
                return new ValidationRegistrationResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string> { { "PhoneNumberError", $"Пользователь с номером телефона: {dto.PhoneNumber} уже существует" } }
                };
            }

            _context.Add(new DbPerson
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Surname = dto.Surname,
                Age = dto.Age,
                City = dto.City,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                EmailAddress = dto.EmailAddress,
                Login = dto.Login,
                Password = dto.Password,
                IsBanned = false
            });
            _context.SaveChanges();

            try
            {
                var theSubjectOfTheLetter = "Регистрация в приложении в супер пупер деньги!";
                var theBodyOfTheLetter = $"Поздравляем с успешной регистрацией в приложении супер пупер деньги!\nLogin: {dto.Login}\nPassword: {dto.Password}";
                SendingAnEmail(dto, theSubjectOfTheLetter, theBodyOfTheLetter);

            }
            catch (SmtpFailedRecipientException e)
            {
                return new ValidationRegistrationResultDTO()
                {
                    IsSuccess = true,
                    Message = new Dictionary<string, string>() { { "Congratulations", $"Поздравляем! Вы успешно прошли регистрацию!\nНе удалось отправить на электронную почту,\nс адресом {dto.EmailAddress}, напоминание с Логином и паролем.  " } }
                };
            }
            return new ValidationRegistrationResultDTO()
            {
                IsSuccess = true,
                Message = new Dictionary<string, string>() { { "Congratulations", "Поздравляем! Вы успешно прошли регистрацию" } }
            };
        }

        /// <summary>
        /// Изменение персодальных данных пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ValidationRegistrationResultDTO ChangingUsersPersonalData(UserDataDTO dto)
        {
            var user = _context.Persons.FirstOrDefault(i => i.Id == dto.Id);
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

            if (dto.PhoneNumber != user.PhoneNumber)
            {
                var isPhoneNumberExist = _context.Persons.Any(p => p.PhoneNumber == dto.PhoneNumber);
                if (isPhoneNumberExist)
                {
                    return new ValidationRegistrationResultDTO()
                    {
                        IsSuccess = false,
                        Message = new Dictionary<string, string> { { "PhoneNumberError", $"Пользователь с номером телефона: {dto.PhoneNumber} уже существует" } }
                    };
                }
            }

            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.Age = dto.Age;
            user.City = dto.City;
            user.Address = dto.Address;
            user.PhoneNumber = dto.PhoneNumber;
            user.EmailAddress = dto.EmailAddress;
            user.Login = dto.Login;
            user.Password = dto.Password;

            _context.SaveChanges();
            try
            {
                string theSubjectOfTheLetter = "Изменение личных данных в приложении в супер пупер деньги! ";
                string theBodyOfTheLetter = "$\"Поздравляем с успешным изменением личных данных!\\nLogin: {dto.Login}\\nPassword: {dto.Password}\"";
                SendingAnEmail(dto, theSubjectOfTheLetter, theBodyOfTheLetter);
            }
            catch (SmtpFailedRecipientException e)
            {
                return new ValidationRegistrationResultDTO()
                {
                    IsSuccess = true,
                    Message = new Dictionary<string, string>() { { "Congratulations", $"Поздравляем! Вы успешно изменили данные в личном кабинете!\nНе удалось отправить на электронную почту,\nс адресом {dto.EmailAddress}, напоминание с Логином и паролем.  " } }
                };
            }

            return new ValidationRegistrationResultDTO
            {
                IsSuccess = true,
                Message = new Dictionary<string, string> { { "Congratulations", "Данные успешно сохранены!" } }
            };
        }

        /// <summary>
        /// Отправка электронного письма на указанный пользователем Email
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="theSubjectOfTheLetter"></param>
        /// <param name="theBodyOfTheLetter"></param>
        private void SendingAnEmail(UserDataDTO dto, string theSubjectOfTheLetter, string theBodyOfTheLetter)
        {
            var smtp = new SmtpClient("smtp.yandex.ru", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("supermegapuperdengi@yandex.ru", "qezfmwmugcjliwod");
            var message = new MailMessage();
            message.From = new MailAddress("supermegapuperdengi@yandex.ru");
            message.To.Add(new MailAddress($"{dto.EmailAddress}"));
            message.Subject = theSubjectOfTheLetter;
            message.Body = theBodyOfTheLetter;
            smtp.Send(message);
        }

        /// <summary>
        /// Поиск данных пользователя по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DbPerson SearchUserData(Guid id)
        {
            var user = _context.Persons.First(i => i.Id == id);
            return user;
        }
    }
}