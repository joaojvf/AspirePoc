using FluentValidation.Results;

namespace AspirePoc.Core.Exceptions
{
    public class FluentValidationException(ValidationResult validation) : Exception($"Error validating: {validation.ToString()}") { }
}
