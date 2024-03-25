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
        public IActionResult Login([FromBody] LoginInputDataDTO dto)
        {
            return dto == null ? BadRequest() : Ok(_personService.Verification(dto));
        }

        [HttpPost("Registration")]
        public IActionResult Registration([FromBody] UserDataDTO dto)
        {
            return dto == null ? BadRequest() : Ok(_personService.CheckingTheEnteredData(dto));
        }

        [HttpPut("UpdateUsersPersonalData/{id}")]
        public IActionResult ChangeUsersPersonalData([FromRoute] Guid id, [FromBody] UserDataDTO dto)
        {
            return dto == null ? BadRequest() : Ok (_personService.CheckingTheEnteredData(id, dto));
        }

        [HttpGet( "UserData/{id}")]
        public DbPerson GetUserData([FromRoute] Guid id)
        {
            return _personService.SearchUserData(id);
        }
    }
}
