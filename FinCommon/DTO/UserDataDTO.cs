using System.ComponentModel.DataAnnotations;

namespace FinCommon.DTO
{
    public class UserDataDTO
    {
        public Guid? Id { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Имя не может быть меньше 3 букв")]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Фамилия не может быть меньше 3 букв")]
        public string Surname { get; set; }

        [Required(ErrorMessage = @"Поле ""Возраст"" обязательно для заполнения")]
        [Range(0, 200, ErrorMessage = "Возраст не может быть меньше 0 и больше 200 лет")]
        public string Age { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = @"Поле ""Номер телефона"" обязательно для заполнения")]
        public string PhoneNumber { get; set; }

        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес электронной почты")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Логин не может быть пустым")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль не может быть пустым")]
        public string Password { get; set; }

        public bool? IsBanned { get; set; }
    }
}
