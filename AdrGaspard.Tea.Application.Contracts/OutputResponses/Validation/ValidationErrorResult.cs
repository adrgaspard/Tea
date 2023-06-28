namespace AdrGaspard.Tea.Application.Contracts.OutputResponses.Validation
{
    public class ValidationErrorResult : ErrorResult
    {
        public required string PropertyName { get; init; }

        public required string Message { get; init; }
    }
}