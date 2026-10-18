namespace Lab_6;

public record ValidationError(string MemberName, string Message);

public class ValidationResult
{
    private readonly List<ValidationError> _errors = new();

    public bool IsValid => _errors.Count == 0;
    public IReadOnlyList<ValidationError> Errors => _errors;

    public void AddError(string memberName, string message) =>
        _errors.Add(new ValidationError(memberName, message));
}