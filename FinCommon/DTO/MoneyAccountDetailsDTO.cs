using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace FinCommon.DTO
{
    public class MoneyAccountDetailsDTO
    {
        public Guid PersonId { get; set; }

        public int Index { get; set; }
        
        [Required(ErrorMessage = @"Вы не ввели сумму для пополнения")]
        [Range(1, int.MaxValue, ErrorMessage = "Пополнение не может быть меньше 1")]
        public string Balance { get; set; }
    }
}
