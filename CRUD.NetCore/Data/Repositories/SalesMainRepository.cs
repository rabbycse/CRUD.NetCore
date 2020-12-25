
namespace CRUD.NetCore.Data.Repositories
{
    using Entities;
    using Interfaces;
    public class SalesMainRepository : Repository<SalesMain>, ISalesMainRepository
    {
        public SalesMainRepository(SalesDbContext context) : base(context)
        { }
    }
}
