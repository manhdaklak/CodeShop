using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Structure
{
    public class UnitOfWork : IUnitWork
    {
        private readonly IDbFactory dbFactory;
        private ShopDbContext db;
        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public ShopDbContext DbContext
        {
            get { return db ?? (db = dbFactory.Init()); }
        }
        public void Commit()
        {
            db.SaveChanges();
        }
    }
}
