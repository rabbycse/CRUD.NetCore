
namespace CRUD.NetCore.Data
{
    using Repositories;
    using Repositories.Interfaces;
    public class UnitOfWork : IUnitOfWork
    {
        readonly SalesDbContext _context;

        ISalesMainRepository _salesMain;
        ISalesSubRepository _salesSub;

        public UnitOfWork()
        {
        }

        public UnitOfWork(SalesDbContext context)
        {
            _context = context;
        }



        public ISalesMainRepository SalesMain
        {
            get
            {
                if (_salesMain == null)
                    _salesMain = new SalesMainRepository(_context);

                return _salesMain;
            }
        }



        public ISalesSubRepository SalesSub 
        {
            get
            {
                if (_salesSub == null)
                    _salesSub = new SalesSubRepository(_context);

                return _salesSub;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}

