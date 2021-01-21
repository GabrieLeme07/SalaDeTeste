using CQRS.API.Application.DTO;
using CQRS.Domain.Models;
using CQRS.Domain.Teste.PedidoTs;
using FluentAssertions;
using FluentValidation.Results;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CQRS.Domain.Teste.Pedidos
{
    [Collection(nameof(PedidoCollection))]
    public class PedidoServiceTeste
    {
        public PedidoTestsFixture Fixture { get; set; }

        public PedidoServiceTeste(PedidoTestsFixture fixture)
        {
            Fixture = fixture;
        }

        //AAA === Arrange, Act, Assert
        [Fact(DisplayName = "Add Novo Pedido")]
        [Trait("Category", "Teste de Pedido Service")]
        public void PedidoService_AddNew_ShouldRegisterWithSucess()
        {
            bool testeFinal = false;
            //Arrange
            var pedidoHandler = Fixture.GetPedidoCommandHandler();
            var pedidoValido = Fixture.GetValidPedidoCommand();
            

            // Act
            var result = pedidoHandler.Handle(pedidoValido, CancellationToken.None);

            //Assert
            if (result.Result.IsValid)
                testeFinal = true;

            Fixture.PedidoRepositoryMock.Verify(r => r.Adicionar(It.IsAny<Pedido>()), Times.Once);
            Assert.True(testeFinal);
            Assert.Equal(0, result.Result.Errors.Count);
        }

        [Fact(DisplayName = "Obter Ultimo Pedido")]
        [Trait("Category", "Teste de Pedido Queries")]
        public void PedidoService_GetLast_ShouldReturnsWithSucess()
        {
            var pedidoQueries = Fixture.GetPedidoQueries();

            var result = pedidoQueries.ObterItemPorId(new Guid("b8b176e6-39b4-4bb6-b57c-a827e9c6698a")).GetAwaiter();

            

        }
    }
}
