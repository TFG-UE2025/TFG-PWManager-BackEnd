
namespace TFG.PWManager.BackEnd.Domain.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception nested) : base(message, nested)
        {
        }
    }
}
