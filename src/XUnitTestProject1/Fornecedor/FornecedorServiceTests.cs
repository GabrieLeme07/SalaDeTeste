using DevIO.Business.Tests.Fornecedores;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace DevIO.Business.Tests.Fornecedores
{
    [Collection(nameof(FornecedorCollection))]
    public class FornecedorServiceTests
    {
        public FornecedorTestsFixture Fixture { get; set; }
        public FornecedorServiceTests(FornecedorTestsFixture fixture)
        {
            Fixture = fixture;
        }

        //AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Add New Success")]
        [Trait("Category", "Fornecedor Service Tests")]
        public void FornecedorService_AddNew_ShouldRegisterWithSuccess()
        {
            // Arrange
            var fornecedorService = Fixture.GetFornecedorService();
            var fornecedor = Fixture.GetValidFornecedor();

            // Act
            fornecedorService.Register(fornecedor);

            // Assert
            Fixture.FornecedorRepositoryMock.Verify(r => r.Add(fornecedor), Times.Once);
            Fixture.MediatorMock.Verify(m => m.Publish(fornecedor, CancellationToken.None), Times.Once);
        }
        
        [Fact(DisplayName = "Add New Fail")]
        [Trait("Category", "Fornecedor Service Tests")]
        public void FornecedorService_AddNew_ShouldNotRegister()
        {
            // Arrange
            var fornecedorService = Fixture.GetFornecedorService();
            var fornecedor = Fixture.GetInvalidFornecedor();

            // Act
            fornecedorService.Register(fornecedor);

            // Assert
            Fixture.FornecedorRepositoryMock.Verify(r => r.Add(fornecedor), Times.Never);
            Fixture.MediatorMock.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        //[Fact(DisplayName = "Get All Active Customers")]
        //[Trait("Category", "Customer Service Tests")]
        //public void FornecedorService_GetAllActive_ShouldReturnsOnlyActiveCustomers()
        //{
        //    // Arrange
        //    var fornecedorService = Fixture.GetFornecedorService();
        //    Fixture.FornecedorRepositoryMock.Setup(c => c.GetAll()).Returns(Fixture.GetMixedCustomers());

        //    // Act
        //    var customers = customerService.GetAllActive().ToList();

        //    // Assert Fluent Assertions
        //    customers.Should().HaveCount(c => c > 1).And.OnlyHaveUniqueItems();
        //    customers.Should().NotContain(c => !c.Active);
        //}
    }
}
