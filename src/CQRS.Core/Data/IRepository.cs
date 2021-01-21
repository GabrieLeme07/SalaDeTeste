using CQRS.Core.DomainObjects;
using System;

namespace CQRS.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
