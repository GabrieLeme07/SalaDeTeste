using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DevIO.Business.Tests.Fornecedores
{
    [Collection(nameof(FornecedorCollection))]
    public class FornecedorTests
    {
        public FornecedorTestsFixture Fixture { get; set; }

        public FornecedorTests(FornecedorTestsFixture fixture) { Fixture = fixture; }

        //AAA == Arrange, Act, Assert

        [Fact(DisplayName = "New Fornecedor Valid")]
        [Trait("Category", "Fornecedor Tests")]
        public void Fornecedor_NewFornecedor_ShouldBeValid()
        {
            // Arrange
            var fornecedor = Fixture.GetValidFornecedor();

            //Act
            var result = fornecedor.IsValid();

            //Assert XUnit
            Assert.True(result);
            Assert.Equal(0, fornecedor.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "New Fornecedor Invalid")]
        [Trait("Category", "Fornecedor Tests")]
        public void Fornecedor_NewFornecedor_ShouldBeInvalid()
        {
            // Arrange
            var fornecedor = Fixture.GetInvalidFornecedor();

            //Act
            var result = fornecedor.IsValid();

            //Assert XUnit
            Assert.False(result);
            Assert.NotEqual(0, fornecedor.ValidationResult.Errors.Count);
        }
    }
}
