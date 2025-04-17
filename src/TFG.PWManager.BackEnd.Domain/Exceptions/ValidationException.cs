using FluentValidation.Results;
using TFG.PWManager.BackEnd.Domain.Resources;

namespace TFG.PWManager.BackEnd.Domain.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; set; }

        public IEnumerable<string> CustomCodes { get; set; }

        public ValidationException() : base(ExceptionsMessages.ValidationExceptionMsg)
        {
            Errors = new Dictionary<string, string[]>();
            CustomCodes = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> errors) : this()
        {
            Errors = errors.GroupBy(x => x.PropertyName, x => x.ErrorMessage).ToDictionary(x => x.Key, x => x.ToArray());
            CustomCodes = errors.Select(x => x.ErrorMessage);
        }
    }
}
