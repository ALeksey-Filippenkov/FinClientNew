using FinCommon.DTO;
using FinServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationHistoryController : ControllerBase
    {
        private readonly OperationHistoryService _operationHistoryService;
        public OperationHistoryController()
        {
            _operationHistoryService = new OperationHistoryService();
        }

        /// <summary>
        /// Получение истории финансовых операций пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("UserTransfer/{id}")]
        public TransferHistoryDataDTO UserTransfer([FromRoute] Guid id)
        {
            return _operationHistoryService.GetHistoryTransfer(id);
        }
        
        /// <summary>
        /// Получение отфильтрованной итории финансовых операций пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("SearchUserOperation")]
        public FilteredUserTransactionHistoryDTO SearchUserOperation([FromBody] SearchOperationDataDTO dto)
        {
            return _operationHistoryService.GetSearchOperationUserTransfer(dto);
        }
    }
}
