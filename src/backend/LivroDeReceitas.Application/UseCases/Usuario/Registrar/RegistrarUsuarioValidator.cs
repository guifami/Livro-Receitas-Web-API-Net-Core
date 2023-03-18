using FluentValidation;
using LivroDeReceitas.Comunicacao.Request;
using LivroDeReceitas.Exceptions;
using System.Text.RegularExpressions;

namespace LivroDeReceitas.Application.UseCases.Usuario.Registrar
{
    public class RegistrarUsuarioValidator : AbstractValidator<RequestRegistrarUsuarioJson>
    {
        public RegistrarUsuarioValidator()
        {
            // Email
            RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceMensagensDeErro.EmailUsuarioEmBranco);
            When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
            {
                RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMensagensDeErro.EmailUsuarioInvalido);
            });

            // Nome
            RuleFor(c => c.Nome).NotEmpty().WithMessage(ResourceMensagensDeErro.NomeUsuarioEmBranco);

            // Senha
            RuleFor(c => c.Senha).NotEmpty().WithMessage(ResourceMensagensDeErro.SenhaUsuarioEmBranco);
            When(c => !string.IsNullOrWhiteSpace(c.Senha), () =>
            {
                RuleFor(c => c.Senha.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMensagensDeErro.SenhaUsuarioMinimoSeisCaracteres);
            });

            // Telefone
            RuleFor(c => c.Telefone).NotEmpty().WithMessage(ResourceMensagensDeErro.TelefoneUsuarioEmBranco);
            When(c => !string.IsNullOrWhiteSpace(c.Telefone), () =>
            {
                RuleFor(c => c.Telefone).Custom((telefone, context) => 
                {
                    string padraoTelefone = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
                    bool isMatch = Regex.IsMatch(telefone, padraoTelefone);
                    if(!isMatch)
                    {
                        context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(telefone), ResourceMensagensDeErro.TelefoneUsuarioInvalido));
                    }
                });
            });
            
        }
    }
}
