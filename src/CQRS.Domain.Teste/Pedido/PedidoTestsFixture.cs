using AutoMoq;
using Bogus;
using CQRS.API.Application.Commands;
using CQRS.API.Application.DTO;
using CQRS.API.Application.Queries;
using CQRS.Core.Mediator;
using CQRS.Domain.Interfaces;
using CQRS.Domain.Models;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CQRS.Domain.Teste.PedidoTs
{
    [CollectionDefinition(nameof(PedidoCollection))]
    public class PedidoCollection : ICollectionFixture<PedidoTestsFixture>
    {
    }
    public class PedidoTestsFixture : IDisposable
    {
        /// <summary>
        /// #1 Primeiro deve-se incluir as injeções de dependencia em Moq 
        /// </summary>
        #region :: Injeção de Dependencia em Moq
        public Mock<IPedidoRepository> PedidoRepositoryMock { get; set; }
        public Mock<IMediatorHandler> MediatorHandlerMock { get; set; }
        public Mock<IMediator> MediatorMock { get; set; }

        public Mock<IPedidoQueries> PedidoQueriesMock { get; set; }
        #endregion

        /// <summary>
        /// Aqui é onde iremos conseguir informar que iremos trabalhar com injeção de dependencias.
        /// </summary>
        /// <returns></returns>
        public PedidoCommandHandler GetPedidoCommandHandler()
        {
            var mocker = new AutoMoqer();
            mocker.Create<PedidoCommandHandler>();

            var pedidoCommandHandler = mocker.Resolve<PedidoCommandHandler>();

            PedidoRepositoryMock = mocker.GetMock<IPedidoRepository>();
            MediatorHandlerMock = mocker.GetMock<IMediatorHandler>();
            MediatorMock = mocker.GetMock<IMediator>();

            return pedidoCommandHandler;

        }

        public PedidoQueries GetPedidoQueries()
        {
            var mocker = new AutoMoqer();
            mocker.Create<PedidoQueries>();

            var pedidoQueries = mocker.Resolve<PedidoQueries>();
            PedidoQueriesMock = mocker.GetMock<IPedidoQueries>();
            PedidoRepositoryMock = mocker.GetMock<IPedidoRepository>();

            return pedidoQueries;
        }

        public AdicionarPedidoCommand GetValidPedidoCommand()
        {
            return GetPedidoCommand(true).First();
        }
        public AdicionarPedidoCommand GetInvalidPedidoCommand()
        {
            return GetPedidoCommand(false).First();
        }

        /// <summary>
        /// Valid == true / Invalid == false;
        /// </summary>
        /// <param name="ValidOrInvalid"></param>
        /// <returns></returns>
        private static IEnumerable<AdicionarPedidoCommand> GetPedidoCommand(bool ValidOrInvalid)
        {
            //Aqui eu crio uma lista de PedidoItem para incluir na instancia do Pedido Valido ou invalido

            if (ValidOrInvalid)
            {
                #region :: Pedidos Validos
                var pedidoValidoItem = new Faker<PedidoItemDTO>("pt_BR")
                .CustomInstantiator(i => new PedidoItemDTO
                {
                    PedidoId = Guid.NewGuid(),
                    ProdutoId = Guid.NewGuid(),
                    Nome = "Produto 1 Teste",
                    Valor = 100,
                    Imagem = "",
                    Quantidade = 1
                });

                var pedidosValidosItem = new List<PedidoItemDTO>();
                pedidosValidosItem.Add(pedidoValidoItem);

                //Instacia do Pedido Fake
                var pedidoValidoTestes = new Faker<AdicionarPedidoCommand>("pt_BR")
                    .CustomInstantiator(p => new AdicionarPedidoCommand(
                        Guid.NewGuid(),
                        100,
                        pedidosValidosItem,
                        "",
                        false,
                        0,
                        new EnderecoDTO(),
                        "5185339283234621",
                        "Joao da Silva",
                         "19/12/2022",
                         "321"
                        ));

                return pedidoValidoTestes.Generate(1);
                #endregion 
            }
            #region :: Pedidos Invalidos
            var pedidoInvalidoItem = new Faker<PedidoItemDTO>("pt_BR")
                .CustomInstantiator(i => new PedidoItemDTO
                {
                    PedidoId = Guid.NewGuid(),
                    ProdutoId = Guid.NewGuid(),
                    Nome = "",
                    Valor = 0,
                    Imagem = "",
                    Quantidade = 1
                });

            var pedidosInvalidosItem = new List<PedidoItemDTO>();
            pedidosInvalidosItem.Add(pedidoInvalidoItem);

            //Instacia do Pedido Fake
            var pedidoInvalidoTestes = new Faker<AdicionarPedidoCommand>("pt_BR")
                .CustomInstantiator(p => new AdicionarPedidoCommand(
                    Guid.NewGuid(),
                    100,
                    pedidosInvalidosItem,
                    "",
                    false,
                    0,
                    new EnderecoDTO(),
                    "111111111111111",
                    "Joao da Silva",
                     "19/12/2022",
                     "32"
                    ));

            return pedidoInvalidoTestes.Generate(1);
            #endregion
        }
          

        public void Dispose()
        {
            //
        }
    }
}
