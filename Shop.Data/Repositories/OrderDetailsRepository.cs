using Shop.Data.Structure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IOrderDetailsRepository : IRepository<OrderDetail>
    {

    }
    public class OrderDetailsRepository: Repository<OrderDetail>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
