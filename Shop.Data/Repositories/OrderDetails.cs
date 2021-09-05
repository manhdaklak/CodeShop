using Shop.Data.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IOrderDetails
    {

    }
    public class OrderDetails: Repository<OrderDetails>, IOrderDetails
    {
        public OrderDetails(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
