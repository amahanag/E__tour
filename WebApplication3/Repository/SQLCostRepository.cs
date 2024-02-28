using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;
using Microsoft.EntityFrameworkCore;

namespace ETour.Repository
{
    public class SQLCostRepository : ICostRepository
    {
        private readonly ScottDbContext context;

        public SQLCostRepository(ScottDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Cost>> GetCostById(int PackageId)
        {
            var cost = await context.Costs.FromSql($"SELECT * FROM Cost WHERE package_id={PackageId}")
                                          .ToListAsync();
            return cost;
        }


    }
}
