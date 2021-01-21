using AutoMoq;
using Bogus;
using Bogus.Extensions.Brazil;
using DevIO.Business.Intefaces;
using DevIO.Business.Intefaces.Testes;
using DevIO.Business.Models;
using DevIO.Business.Services;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DevIO.Business.Tests.Fornecedores
{
    [CollectionDefinition(nameof(FornecedorCollection))]
    public class FornecedorCollection : ICollectionFixture<FornecedorTestsFixture>
    {
    }

    public class FornecedorTestsFixture : IDisposable
    {
        public Mock<IFornecedorTesteRepository> FornecedorRepositoryMock { get; set; }
        public Mock<IFornecedorTesteService> FornecedorServiceMock { get; set; }
        public Mock<IMediator> MediatorMock { get; set; }

        public FornecedorTesteService GetFornecedorService()
        {
            var mocker = new AutoMoqer();
            mocker.Create<FornecedorTesteService>();

            var fornecedorService = mocker.Resolve<FornecedorTesteService>();

            FornecedorRepositoryMock = mocker.GetMock<IFornecedorTesteRepository>();
            FornecedorServiceMock = mocker.GetMock<IFornecedorTesteService>();
            MediatorMock = mocker.GetMock<IMediator>();

            return fornecedorService;
        }

        public Fornecedor GetValidFornecedor()
        {
            return GetFornecedores(1, true).First();
        }

        public Fornecedor GetInvalidFornecedor()
        {
            var fornecedorTests = new Faker<Fornecedor>("pt_BR")
               .CustomInstantiator(f => new Fornecedor(
                   Guid.NewGuid(),
                   "",
                   f.Company.Cnpj(),
                   TipoFornecedor.PessoaJuridica,
                   false
                   ));

            return fornecedorTests;
        }

        private static IEnumerable<Fornecedor> GetFornecedores(int number, bool isActive)
        {
            var fornecedorTests = new Faker<Fornecedor>("pt_BR")
                .CustomInstantiator(f => new Fornecedor(
                    Guid.NewGuid(),
                    f.Company.CompanyName(),
                    f.Company.Cnpj(),
                    TipoFornecedor.PessoaJuridica,
                    isActive
                    ));

            return fornecedorTests.Generate(number);
        }


        public void Dispose()
        {
           //
        }
    }
}
