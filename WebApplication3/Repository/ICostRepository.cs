using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;

namespace ETour.Repository
{
    public interface ICostRepository
    {
        Task <IEnumerable<Cost>> GetCostById(int Id);
      //  Task<ActionResult<IEnumerable<Cost>>> GetAllEmployee();
    }
}
