using ControleFinanceiro.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Validations
{
    public class CartaoValidator : AbstractValidator<CartaoDTO>
    {

        public CartaoValidator()
        {
            RuleFor(c => c.Nome)
                .NotNull().WithMessage("Preencha o nome")
                .NotEmpty().WithMessage("Preencha o nome")
                .MinimumLength(2).WithMessage("Use mais caracteres.")
                .MaximumLength(50).WithMessage("Use menos caracteres.");

            RuleFor(c => c.Bandeira)
                .NotNull().WithMessage("Preencha a bandeira")
                .NotEmpty().WithMessage("Preencha a bandeira")
                .MinimumLength(2).WithMessage("Use mais caracteres.")
                .MaximumLength(15).WithMessage("Use menos caracteres.");

            RuleFor(c => c.Numero)
                .NotNull().WithMessage("Preencha o numero")
                .NotEmpty().WithMessage("Preencha o numero")
                .MinimumLength(5).WithMessage("Use mais caracteres.")
                .MaximumLength(20).WithMessage("Use menos caracteres.");


        }
    }
}
