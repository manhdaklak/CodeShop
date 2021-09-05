using Shop.Data.Structure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IApplictionRoleRepository
    {

    }
    public class ApplictionRoleRepository: Repository<ApplicationRole>, IApplictionRoleRepository
    {
        public ApplictionRoleRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}
