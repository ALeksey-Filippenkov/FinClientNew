using FinCommon.DTO;
using FinServer.DbModels;
using System.Net.Mail;
using System.Net;

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
        public ValidationAuthorizationResultDTO Verification(LoginInputDataDTO dto)
        {
            _searchAccount = _context.Persons.FirstOrDefault(e => e.Login == dto.Login);
            
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

            var Smtp = new SmtpClient("smtp.yandex.ru", 587);
            Smtp.EnableSsl = true;
            Smtp.Credentials = new NetworkCredential("supermegapuperdengi@yandex.ru", "qezfmwmugcjliwod");
            var Message = new MailMessage();
            Message.From = new MailAddress("supermegapuperdengi@yandex.ru");
            Message.To.Add(new MailAddress($"{dto.EmailAddress}"));
            Message.Subject = "Регистрация в приложении в супер пупер деньги! ";
            Message.Body = $"Поздравляем с успешной регистрацией в приложении супер пупер деньги!\nLogin: {dto.Login}\nPassword: {dto.Password}";

            try
            {
                Smtp.Send(Message);
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

            var smtp = new SmtpClient("smtp.yandex.ru", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("supermegapuperdengi@yandex.ru", "qezfmwmugcjliwod");
            var message = new MailMessage();
            message.From = new MailAddress("supermegapuperdengi@yandex.ru");
            message.To.Add(new MailAddress($"{dto.EmailAddress}"));
            message.Subject = "Изменение личных данных в приложении в супер пупер деньги! ";
            message.Body = $"Поздравляем с успешным изменением личных данных!\nLogin: {dto.Login}\nPassword: {dto.Password}";

            try
            {
                smtp.Send(message);
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