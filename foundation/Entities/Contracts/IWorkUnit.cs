using System.Threading.Tasks;

namespace foundation.Entities.Contracts
{
    public interface IWorkUnit
    {
        void Commit();

        Task CommitAsync();
    }
}