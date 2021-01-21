using CQRS.API.Application.Commands;
using CQRS.API.Application.Queries;
using CQRS.Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CQRS.API.Controllers
{
    public class PedidoController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IPedidoQueries _pedidoQueries;

        public PedidoController(IMediatorHandler mediator,
            IPedidoQueries pedidoQueries)
        {
            _mediator = mediator;
            _pedidoQueries = pedidoQueries;
        }

        [HttpPost("pedido")]
        public async Task<IActionResult> AdicionarPedido(AdicionarPedidoCommand pedido)
        {
            pedido.ClienteId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            return CustomResponse(await _mediator.EnviarComando(pedido));
        }

        [HttpGet("pedido/ultimo")]
        public async Task<IActionResult> UltimoPedido()
        {
            var pedido = await _pedidoQueries.ObterUltimoPedido(new Guid());

            return pedido == null ? NotFound() : CustomResponse(pedido);
        }

        [HttpGet("pedido/lista-cliente")]
        public async Task<IActionResult> ListaPorCliente()
        {
            var pedidos = await _pedidoQueries.ObterListaPorClienteId(new Guid());

            return pedidos == null ? NotFound() : CustomResponse(pedidos);
        }
    }
}
