using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Domain.Exceptions
{
    public class DomainException : ErrorException
    {
        public DomainException() : base($"An unknown {nameof(DomainException)} occured!")
        {
        }

        public DomainException(string? message) : base(message)
        {
        }

        public DomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}