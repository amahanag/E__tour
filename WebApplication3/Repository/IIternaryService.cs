using ETour.DbRepos;

namespace ETour.Repository
{
    public interface IIternaryService
    {
        Task<List<Iternary>> GetIternaryAsync();
        Task<IEnumerable<Iternary>> GetIternaryByIdAsync(int id);
    }

   
}
