using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;
using Microsoft.EntityFrameworkCore;

namespace ETour.Repository
{
    public class PackageRepository : IPackageRepository
    {

        private readonly ScottDbContext _context;

        public PackageRepository(ScottDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Package>> getPackageById(int id)
        {
            var packages = _context.Packages.FromSql($"SELECT * FROM packages where subcategory_id={id}");
            return packages.ToList();

        }

        public async Task<ActionResult<IEnumerable<Package>>> GetPackagesByCategoryId(int id)
        {
            var packages = _context.Packages.FromSql($"SELECT * FROM packages where category_id={id} and subcategory_id is null");
            return packages.ToList();
        }

        public async Task<ActionResult<IEnumerable<Package>?>> getPackages()
        {
            if (_context.Packages == null) { return null; }
            return _context.Packages.ToList();
        }
    }
}
