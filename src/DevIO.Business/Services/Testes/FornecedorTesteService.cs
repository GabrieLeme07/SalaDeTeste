using DevIO.Business.Intefaces;
using DevIO.Business.Intefaces.Testes;
using DevIO.Business.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace DevIO.Business.Services
{
    public class FornecedorTesteService : IFornecedorTesteService
    {
        private readonly IFornecedorTesteRepository _fornecedorTesteRepository;
        private readonly IMediator _mediator;

        public FornecedorTesteService(IFornecedorTesteRepository fornecedorTesteRepository, IMediator mediator)
        {
            _fornecedorTesteRepository = fornecedorTesteRepository;
            _mediator = mediator;
        }

        public IEnumerable<Fornecedor> GetAllActive()
        {
            return _fornecedorTesteRepository.GetAll().Where(c => c.Ativo);
        }

        public void Register(Fornecedor fornecedor)
        {
            if (!fornecedor.IsValid())
                return;

            _fornecedorTesteRepository.Add(fornecedor);
            _mediator.Publish(fornecedor);
        }

        public void Update(Fornecedor fornecedor)
        {
            if (!fornecedor.IsValid())
                return;

            _fornecedorTesteRepository.Update(fornecedor);
            _mediator.Publish(fornecedor);
        }

        public void Inactivate(Fornecedor fornecedor)
        {
            if (!fornecedor.IsValid())
                return;

            fornecedor.SetInactive();
            _fornecedorTesteRepository.Update(fornecedor);
            _mediator.Publish(fornecedor);
        }

        public void Remove(Fornecedor fornecedor)
        {
            _fornecedorTesteRepository.Remove(fornecedor.Id);
            _mediator.Publish(fornecedor);
        }

        public void Dispose()
        {
            _fornecedorTesteRepository.Dispose();
        }
    }
}
