using FluentValidation;

namespace MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.CreateCliente
{
    public class CreateClienteCommndValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommndValidator()
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
