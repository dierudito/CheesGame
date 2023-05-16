using DomainValidation.Validation;

namespace Moreno.ChessGame.Domain.Entities.Base;

public abstract class Entity
{
    public Guid Id { get; private set; }
    public ValidationResult ValidationResult { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        ValidationResult = new();
    }

    public void AddErrorValidation(string erro, string mensagem)
    {
        ValidationResult.Add(new ValidationError(erro, mensagem));
    }

    public void AddErrorsValidation(ValidationResult validationResult)
    {
        ValidationResult.Add(validationResult);
    }

    public void ResetListErrors()
    {
        ValidationResult = new();
    }
}
