using DevIO.Business.Models.Validations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace DevIO.Business.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public IEnumerable<Produto> Produtos { get; set; }

        public Fornecedor()
        {

        }
        public Fornecedor(Guid guid) { }
        public Fornecedor(Guid id, string name, string document, TipoFornecedor tipoFornecedor, bool active)
        {
            Id = id;
            Nome = name;
            Documento = document;
            TipoFornecedor = tipoFornecedor;
            Ativo = active;
        }
        public Fornecedor(Guid id, string name, string document, TipoFornecedor tipoFornecedor, bool active, Endereco endereco)
        {
            Id = id;
            Nome = name;
            Documento = document;
            TipoFornecedor = tipoFornecedor;
            Ativo = active;
            Endereco = endereco;
        }

        public void SetInactive()
        {
            Ativo = false;
        }

        public override bool IsValid()
        {
            ValidationResult = new FornecedorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}