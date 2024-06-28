using ControleFinanceiro.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Validations
{
    public class UsuarioUpdateValidator : AbstractValidator<UsuarioUpdateDTO>
    {
        public UsuarioUpdateValidator()
        {
            RuleFor(u => u.UserName)
                .NotNull().WithMessage("Preencha o nome de usuário")
                .NotEmpty().WithMessage("Preencha o nome de usuário")
                .MinimumLength(6).WithMessage("Use mais caracteres")
                .MaximumLength(30).WithMessage("Use menos caracteres");

            RuleFor(u => u.CPF)
                .NotNull().WithMessage("Prrencha o CPF.")
                .NotEmpty().WithMessage("Prrencha o CPF.")
                .MinimumLength(1).WithMessage("Use mais caracteres")
                .MaximumLength(20).WithMessage("Use menos caractares");


            RuleFor(u => u.Profissao)
                .NotNull().WithMessage("Prrencha a profissão.")
                .NotEmpty().WithMessage("Prrencha a profissão.")
                .MinimumLength(1).WithMessage("Use mais caracteres")
                .MaximumLength(30).WithMessage("Use menos caractares");

            RuleFor(u => u.Foto)
                .NotNull().WithMessage("Prrencha a foto.")
                .NotEmpty().WithMessage("Prrencha a foto.");

            RuleFor(u => u.Email)
                .NotNull().WithMessage("Prrencha a e-mail.")
                .NotEmpty().WithMessage("Prrencha a e-mail.")
                .MinimumLength(10).WithMessage("Use mais caracteres")
                .MaximumLength(50).WithMessage("Use menos caractares")
                .EmailAddress().WithMessage("E-mail inválido.");
        }
    }
}
