namespace AdrGaspard.Tea.Application.Contracts.OutputResponses.Validation
{
    public class ValidationResponse
    {
        public required string PropertyName { get; init; }

        public required string Message { get; init; }
    }
}
