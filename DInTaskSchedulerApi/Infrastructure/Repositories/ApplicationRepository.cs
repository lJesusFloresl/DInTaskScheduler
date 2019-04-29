using System.Linq;
using System.Threading.Tasks;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Infrastructure.DataContext;
using DInTaskSchedulerApi.Tools;
using Microsoft.EntityFrameworkCore;

namespace DInTaskSchedulerApi.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DInTaskSchedulerContext context;

        public ApplicationRepository(DInTaskSchedulerContext context)
        {
            this.context = context;
        }

        public IQueryable<Infrastructure.DataContext.Application> Get()
        {
            return context.Application
                .Include(e => e.IdStatusNavigation)
                .AsQueryable();
        }

        public IQueryable<DataContext.Application> GetActive()
        {
            return context.Application
                .Include(e => e.IdStatusNavigation)
                .Where(e => e.IdStatus.Equals(Enums.StatusCatalog.ACTIVE.GetValue()))
                .AsQueryable();
        }

        public DataContext.Application GetById(int id)
        {
            return context.Application
                .Include(e => e.IdStatusNavigation)
                .FirstOrDefault(e => e.Id.Equals(id));
        }

        public async Task<DataContext.Application> Save(DataContext.Application model)
        {
            context.Application.Add(model);
            await context.SaveChangesAsync();
            return model;
        }

        public async Task<DataContext.Application> Update(DataContext.Application model)
        {
            context.Application.Update(model);
            await context.SaveChangesAsync();
            return model;
        }
    }
}
