namespace Lab_6;

public interface IValidationService
{
    ValidationResult Validate(object entity);
}