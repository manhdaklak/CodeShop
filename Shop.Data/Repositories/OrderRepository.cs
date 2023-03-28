using Shop.Data.Structure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {

    }
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository (IDbFactory dbFactory): base(dbFactory)
        {

        }

    }
}
