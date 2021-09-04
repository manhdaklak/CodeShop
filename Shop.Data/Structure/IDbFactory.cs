using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Structure
{
    
    public interface IDbFactory
    {
        ShopDbContext Init();
    }
}
