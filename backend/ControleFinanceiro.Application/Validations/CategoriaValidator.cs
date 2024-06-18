using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Validations
{
    public class CategoriaValidator : AbstractValidator<CategoriaDTO>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Nome)
                .NotNull().WithMessage("Preencha o nome")
                .NotEmpty().WithMessage("Preencha o nome")
                .MinimumLength(6).WithMessage("Use mais caracteres.")
                .MaximumLength(50).WithMessage("Use menos caracteres.");

            RuleFor(c => c.Icone)
                .NotNull().WithMessage("Preencha o icone")
                .NotEmpty().WithMessage("Preencha o icone")
                .MinimumLength(1).WithMessage("Use mais caracteres.")
                .MaximumLength(15).WithMessage("Use menos caracteres.");

            RuleFor(c => c.TipoId)
                .NotNull().WithMessage("Preencha o nome")
                .NotEmpty().WithMessage("Preencha o nome");
        }
    }
}
