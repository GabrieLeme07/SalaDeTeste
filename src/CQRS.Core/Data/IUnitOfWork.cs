using System.Threading.Tasks;

namespace CQRS.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
