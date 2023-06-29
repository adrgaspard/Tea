namespace AdrGaspard.Tea.Application.Contracts.OutputResults.Validation
{
    public class ValidationFailureResult
    {
        public IReadOnlyList<ValidationErrorResult> Errors { get; init; }
    }
}