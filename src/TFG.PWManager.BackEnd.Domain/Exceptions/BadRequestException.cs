namespace TFG.PWManager.BackEnd.Domain.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception nested) : base(message, nested)
        {
        }
    }
}
