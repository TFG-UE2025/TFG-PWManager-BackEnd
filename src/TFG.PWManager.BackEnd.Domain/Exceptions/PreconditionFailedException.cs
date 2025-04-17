namespace TFG.PWManager.BackEnd.Domain.Exceptions
{
    public class PreconditionFailedException : ApplicationException
    {
        public PreconditionFailedException()
        {
        }

        public PreconditionFailedException(string message) : base(message)
        {
        }

        public PreconditionFailedException(string message, Exception nested) : base(message, nested)
        {
        }
    }
}
