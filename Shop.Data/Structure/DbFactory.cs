using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Structure
{
    /// <summary>
    /// Khởi tạo DB
    /// </summary>
    public class DbFactory : Disposable, IDbFactory
    {
        ShopDbContext db ;
        public ShopDbContext Init()
        {
            return db ?? (db = new ShopDbContext());
        }
        protected override void DisposeCore()
        {
            if(db != null)
            {
                db.Dispose();
            }
           
        }
    }
}
