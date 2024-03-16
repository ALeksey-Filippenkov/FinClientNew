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

        [HttpPost("Login")]
        public ResultDTO Authorization([FromBody] LoginDTO dto)
        {
            return _personService.Verification(dto);
        }


        [HttpGet( "UserData/{id}")]
        public DbPerson GetUserData(Guid id)
        {
            return _personService.GetDB(id);
        }

        [HttpPost("Registration")]
        public ResultDTO Registration([FromBody] UserDataDTO dto)
        {
           return _personService.CheckingTheEnteredData(dto);
        }

        [HttpPut("PutUserData/{id}")]
        public ResultDTO PutUserData(Guid id, PutUserDataDTO dto)
        {
            return _personService.CheckingPutTheEnteredData(id, dto);
        }
    }
}
