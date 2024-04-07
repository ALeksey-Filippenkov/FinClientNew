using FinCommon.DTO;
using FinServer.DbModels;
using FinServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController()
        {
            _personService = new PersonService();
        }
        /// <summary>
        /// Вход в личный кабинет пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginInputDataDTO dto)
        {
            return dto == null ? BadRequest() : Ok(_personService.Verification(dto));
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Registration")]
        public IActionResult Registration([FromBody] UserDataDTO dto)
        {
            return dto == null ? BadRequest() : Ok(_personService.AddingUser(dto));
        }

        /// <summary>
        /// Изменение личных данных пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("UpdateUsersPersonalData")]
        public IActionResult ChangeUsersPersonalData([FromBody] UserDataDTO dto)
        {
            return dto == null ? BadRequest() : Ok (_personService.ChangingUsersPersonalData(dto));
        }

        /// <summary>
        /// Получение с сервера личных данных пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet( "UserData/{id}")]
        public DbPerson GetUserData([FromRoute] Guid id)
        {
            return _personService.SearchUserData(id);
        }
    }
}
