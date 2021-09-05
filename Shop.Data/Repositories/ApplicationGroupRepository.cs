using Shop.Data.Structure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IApplicationGroupRepository
    {

    }
    public class ApplicationGroupRepository: Repository<ApplicationGroup>,IApplicationGroupRepository
    {
        public ApplicationGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
