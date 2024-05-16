using FinCommon.DTO;
using FinServer.DbModels;
using FinServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;
        public AdminController()
        {
            _adminService = new AdminService();
        }
        /// <summary>
        /// Получение имени администратора
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Name/{_id}")]
        public AdminNameDTO AdministratorsName([FromRoute] Guid id)
        {
            return _adminService.GetAdministratorsName(id);
        }
    }
}
