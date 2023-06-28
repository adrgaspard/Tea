using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application.Contracts.Exceptions
{
    public class ApplicationException : ErrorException
    {
        public ApplicationException() : base($"An unknown {nameof(ApplicationException)} occured!")
        {
        }

        public ApplicationException(string? message) : base(message)
        {
        }

        public ApplicationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}