using DevIO.Business.Models;
using System;
using System.Collections.Generic;

namespace DevIO.Business.Intefaces.Testes
{
    public interface IFornecedorTesteService : IDisposable
    {
        IEnumerable<Fornecedor> GetAllActive();
        void Register(Fornecedor customer);
        void Update(Fornecedor customer);
        void Remove(Fornecedor customer);
        void Inactivate(Fornecedor customer);
    }
}
