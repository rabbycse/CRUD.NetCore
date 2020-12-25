
namespace CRUD.NetCore.Data
{
    using Repositories.Interfaces;
    public interface IUnitOfWork
    {
        ISalesMainRepository SalesMain { get; }
        ISalesSubRepository SalesSub { get; } 

        int SaveChanges();
    }
}

