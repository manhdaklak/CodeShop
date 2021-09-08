using Shop.Data.Structure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IApplicationRoleGroupRepository: IRepository<ApplicationRoleGroup>
    {

    }
    public class ApplicationRoleGroupRepository: Repository<ApplicationRoleGroup>
    {
        public ApplicationRoleGroupRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}
