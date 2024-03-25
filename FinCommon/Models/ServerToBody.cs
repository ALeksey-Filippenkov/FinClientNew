using System.Text;
using System.Text.Json;

namespace FinCommon.Models
{
    public static class ServerToBody
    {
        public static StringContent ToBody(object model)
        {
            return new(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");
        }
    }
}
