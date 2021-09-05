using Shop.Data.Structure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IProductRepository
    {

    }
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        public ProductRepository (IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
