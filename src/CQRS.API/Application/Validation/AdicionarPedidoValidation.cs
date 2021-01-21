using CQRS.API.Application.Commands;
using FluentValidation;
using System;

namespace CQRS.API.Application.Validation
{
    public class AdicionarPedidoValidation : AbstractValidator<AdicionarPedidoCommand>
    {
        public AdicionarPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.PedidoItems.Count)
                .GreaterThan(0)
                .WithMessage("O pedido precisa ter no mínimo 1 item");

            RuleFor(c => c.ValorTotal)
                .GreaterThan(0)
                .WithMessage("Valor do pedido inválido");

            RuleFor(c => c.NumeroCartao)
                .CreditCard()
                .WithMessage("Número de cartão inválido");

            RuleFor(c => c.NomeCartao)
                .NotNull()
                .WithMessage("Nome do portador do cartão requerido.");

            RuleFor(c => c.CvvCartao.Length)
                .GreaterThan(2)
                .LessThan(5)
                .WithMessage("O CVV do cartão precisa ter 3 ou 4 números.");

            RuleFor(c => c.ExpiracaoCartao)
                .NotNull()
                .WithMessage("Data expiração do cartão requerida.");
        }
    }
}
