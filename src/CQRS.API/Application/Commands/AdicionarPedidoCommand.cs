using CQRS.API.Application.DTO;
using CQRS.API.Application.Validation;
using CQRS.Core.Messages;
using System;
using System.Collections.Generic;

namespace CQRS.API.Application.Commands
{
    public class AdicionarPedidoCommand : Command
    {
        public AdicionarPedidoCommand(Guid clienteId,
                                      decimal valorTotal,
                                      List<PedidoItemDTO> pedidoItems,
                                      string voucherCodigo,
                                      bool voucherUtilizado,
                                      decimal desconto,
                                      EnderecoDTO endereco,
                                      string numeroCartao,
                                      string nomeCartao,
                                      string expiracaoCartao,
                                      string cvvCartao)
        {
            ClienteId = clienteId;
            ValorTotal = valorTotal;
            PedidoItems = pedidoItems;
            VoucherCodigo = voucherCodigo;
            VoucherUtilizado = voucherUtilizado;
            Desconto = desconto;
            Endereco = endereco;
            NumeroCartao = numeroCartao;
            NomeCartao = nomeCartao;
            ExpiracaoCartao = expiracaoCartao;
            CvvCartao = cvvCartao;
        }

        // Pedido
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public List<PedidoItemDTO> PedidoItems { get; set; }

        // Voucher
        public string VoucherCodigo { get; set; }
        public bool VoucherUtilizado { get; set; }
        public decimal Desconto { get; set; }

        // Endereco
        public EnderecoDTO Endereco { get; set; }

        // Cartao
        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
