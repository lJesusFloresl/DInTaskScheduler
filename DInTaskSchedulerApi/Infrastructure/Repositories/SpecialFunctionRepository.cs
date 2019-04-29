using System.Linq;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DInTaskSchedulerApi.Infrastructure.Repositories
{
    public class SpecialFunctionRepository : ISpecialFunctionRepository
    {
        private readonly DInTaskSchedulerContext context;

        public SpecialFunctionRepository(DInTaskSchedulerContext context)
        {
            this.context = context;
        }

        public IQueryable<SpecialFunction> Get()
        {
            return context.SpecialFunction
                .Include(e => e.IdPropertyTypeNavigation)
                .AsQueryable();
        }

        public IQueryable<SpecialFunction> GetByPropertyType(int idPropertyType)
        {
            return context.SpecialFunction
                .Include(e => e.IdPropertyTypeNavigation)
                .Where(e => e.IdPropertyType.Equals(idPropertyType))
                .AsQueryable();
        }
    }
}
