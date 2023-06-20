using System.ComponentModel.DataAnnotations;

namespace AdrGaspard.Tea.Application.DataTransfertObjects
{
    public interface IValidatableObject
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}
