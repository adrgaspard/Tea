namespace AdrGaspard.Tea.Application.Contracts.OutputResults.Validation
{
    public class ValidationErrorResult : ErrorResult
    {
        public string PropertyName { get; init; }

        public string Message { get; init; }
    }
}