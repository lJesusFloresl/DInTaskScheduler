using System.Threading.Tasks;

namespace DInTaskScheduler.Domain.Contracts.Repositories
{
    public interface IJobRepository
    {
        Task<bool> UpdateProcess(int idJob, bool InProcess);

        Task<bool> UpdateFinished(int idJob, bool finished);
    }
}
