using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;

namespace ETour.Repository
{
    public interface IDateRepository
    {
        Task<IEnumerable<Date>> getDateById(int id);
        Task<ActionResult<IEnumerable<Date>?>> getDates();
       
    }
}
