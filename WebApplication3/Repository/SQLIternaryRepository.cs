using ETour.Repository;
using Microsoft.EntityFrameworkCore;
using ETour.DbRepos;

namespace ETour.Repository
{
    public class SQLIternaryRepository : IIternaryService
    {
        private readonly ScottDbContext context;

        public SQLIternaryRepository(ScottDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Iternary>> GetIternaryAsync()
        {
            
            if (context == null)
            {
                return null;
            }

           
            await context.Iternaries.LoadAsync();

           
            return await context.Iternaries.ToListAsync();
        }

        public async Task<IEnumerable<Iternary>> GetIternaryByIdAsync(int id)
        {
            // You should check against null for context itself, not its DbSet
            var iternary = context.Iternaries.FromSql($"SELECT * FROM iternary where package_id={id}");
            return iternary.ToList();
        }
    }
}
