namespace AdrGaspard.Tea.Application.Contracts.OutputResponses.Validation
{
    public class ValidationFailureResult
    {
        public required IReadOnlyList<ValidationErrorResult> Errors { get; init; }
    }
}