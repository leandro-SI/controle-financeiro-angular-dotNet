using ControleFinanceiro.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Validations
{
    public class DespesaValidator : AbstractValidator<DespesaDTO>
    {

        public DespesaValidator()
        {
            RuleFor(d => d.CartaoId)
                .NotEmpty().WithMessage("Escolha o cartão")
                .NotNull().WithMessage("Escolha o cartão");

            RuleFor(d => d.Descricao)
                .NotEmpty().WithMessage("Preencha a descrição")
                .NotNull().WithMessage("Preencha a descrição")
                .MinimumLength(1).WithMessage("Use mais caracteres")
                .MaximumLength(50).WithMessage("Use menos caracteres");

            RuleFor(d => d.Valor)
                .NotNull().WithMessage("Preencha o valor")
                .NotEmpty().WithMessage("Escolha o valor")
                .InclusiveBetween(0, decimal.MaxValue).WithMessage("Valor inválido");

            RuleFor(d => d.MesId)
                .NotEmpty().WithMessage("Escolha o mês")
                .NotNull().WithMessage("Escolha o mês");

            RuleFor(d => d.Ano)
                .NotNull().WithMessage("Preencha o ano")
                .NotEmpty().WithMessage("Escolha o ano")
                .InclusiveBetween(2024, 3000).WithMessage("Valor inválido");

        }
    }
}
