using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdrGaspard.Tea.Application.OutputResponses.Validation
{
    public class ValidationFailureResponse
    {
        public required IReadOnlyList<ValidationResponse> Errors { get; init; }
    }
}
