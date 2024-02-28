using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;

namespace ETour.Repository
{
    public interface IPackageRepository
    {
        public Task<ActionResult<IEnumerable<Package>?>> getPackages();
        public  Task<IEnumerable<Package>> getPackageById(int id);

        Task<ActionResult<IEnumerable<Package>>> GetPackagesByCategoryId(int id);
    }
}
