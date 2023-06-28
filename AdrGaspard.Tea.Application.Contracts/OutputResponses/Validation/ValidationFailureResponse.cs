namespace AdrGaspard.Tea.Application.Contracts.OutputResponses.Validation
{
    public class ValidationFailureResponse
    {
        public IReadOnlyList<ValidationResponse> Errors { get; init; }
    }
}