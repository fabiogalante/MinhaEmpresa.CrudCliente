using FluentValidation;

namespace MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.UpdateCommand
{
    public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("{Nome} é obrigatório.")
                .NotNull()
                .MaximumLength(200).WithMessage("{Nome} deve ter no máximo 200 caracteres.");

            RuleFor(p => p.Idade)
                .NotEmpty().WithMessage("{Idade} é obrigatório.")
                .GreaterThan(-1).WithMessage("{Idade} inválida.");
        }
    }
}
