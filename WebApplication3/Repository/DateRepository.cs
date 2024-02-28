
using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;
using Microsoft.EntityFrameworkCore;


namespace ETour.Repository
{


    public class DateRepository : IDateRepository
    {
        private readonly ScottDbContext context;
        public DateRepository(ScottDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Date>> getDateById(int id)
        {
            var dates =  context.Dates.FromSql($"SELECT * FROM date where package_id={id}");
            return dates.ToList();
        }

        public async Task<ActionResult<IEnumerable<Date>?>> getDates()
        {
            if(context.Dates==null)
            {
                return null;
            }
            return context.Dates.ToList();
        }







    }

}