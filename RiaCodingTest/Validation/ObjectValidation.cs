using System.ComponentModel.DataAnnotations;

namespace RiaCodingTest.API.Validation
{
    public static class ObjectValidation
    {
        public static IEnumerable<ValidationResult> GetValidationErros(object obj)
        {
            var validationResult = new List<ValidationResult>();
            var contexto = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, contexto, validationResult, true);
            return validationResult;
        }
    }
}
