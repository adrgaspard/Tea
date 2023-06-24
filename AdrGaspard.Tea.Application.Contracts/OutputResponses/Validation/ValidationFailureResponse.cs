namespace AdrGaspard.Tea.Application.Contracts.OutputResponses.Validation
{
    public class ValidationFailureResponse
    {
        public required IReadOnlyList<ValidationResponse> Errors { get; init; }
    }
}
