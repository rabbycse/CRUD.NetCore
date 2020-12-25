
namespace CRUD.NetCore.Data.Repositories
{
    using Entities;
    using Interfaces;
    public class SalesSubRepository : Repository<SalesSub>, ISalesSubRepository
    {
        public SalesSubRepository(SalesDbContext context) : base(context)
        { }
    }
}
