using Shop.Data.Structure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IApplictionUserGroupRepository
    {

    }
    public class ApplictionUserGroupRepository: Repository<ApplicationUserGroup>, IApplictionUserGroupRepository
    {
        public ApplictionUserGroupRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}
