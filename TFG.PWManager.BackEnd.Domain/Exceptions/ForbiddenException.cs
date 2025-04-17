namespace TFG.PWManager.BackEnd.Domain.Exceptions
{
    public class ForbiddenException : ApplicationException
    {
        public ForbiddenException()
        {
        }

        public ForbiddenException(string message) : base(message)
        {
        }

        public ForbiddenException(string message, Exception nested) : base(message, nested)
        {
        }
    }
}
