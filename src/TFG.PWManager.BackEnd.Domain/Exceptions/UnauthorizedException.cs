
namespace TFG.PWManager.BackEnd.Domain.Exceptions
{
    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, Exception nested) : base(message, nested)
        {
        }
    }
}
