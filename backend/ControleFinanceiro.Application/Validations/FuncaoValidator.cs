using ControleFinanceiro.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Validations
{
    public class FuncaoValidator : AbstractValidator<FuncaoDTO>
    {
        public FuncaoValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("Preencha o nome")
                .NotEmpty().WithMessage("Preencha o nome")
                .MinimumLength(1).WithMessage("Use mais caracteres.")
                .MaximumLength(50).WithMessage("Use menos caracteres.");

            RuleFor(c => c.Descricao)
                .NotNull().WithMessage("Preencha a descrição")
                .NotEmpty().WithMessage("Preencha o descrição")
                .MinimumLength(1).WithMessage("Use mais caracteres.")
                .MaximumLength(50).WithMessage("Use menos caracteres.");
        }
    }
}
