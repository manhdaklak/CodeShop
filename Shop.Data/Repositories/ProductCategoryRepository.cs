using Shop.Data.Structure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetByCode(string name);
    }
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }

        public IEnumerable<ProductCategory> GetByCode(string name)
        {
            return this.DbContext.ProductCategories.Where(x => x.Name == name);
        }
    }
}
