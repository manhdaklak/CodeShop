using Shop.Common;
using Shop.Data.Repositories;
using Shop.Data.Structure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service
{
    public interface IApplicationGroupService
    {
        ApplicationGroup Add(ApplicationGroup applicationGroup);
        ApplicationGroup DeleteById(int id);
        void Update(ApplicationGroup applicationGroup);

        ApplicationGroup GetDetaill(int id);
        IEnumerable<ApplicationGroup> GetAll(int page, int pagesize, out int totalRow, string filter);
        IEnumerable<ApplicationGroup> GetAll();
        bool AddUserToGroups(IEnumerable<ApplicationUserGroup> groups, string userId);
        IEnumerable<ApplicationGroup> GetListGroupByUserId(string userId);
        IEnumerable<ApplicationUser> GetListUserByGroupId(int groupId);
        void Save();

        
    }
    public class ApplicationGroupService : IApplicationGroupService
    {
        private IApplicationGroupRepository _appGroupRepository;
        private IApplicationUserGroupRepository _appUserGroupRepository;
        private IUnitWork _unitWork;
        public ApplicationGroupService(IApplicationGroupRepository appGroupRepository,
            IApplicationUserGroupRepository appUserGroupRepository, IUnitWork unitWork)
        {
            this._appGroupRepository = appGroupRepository;
            this._appUserGroupRepository = appUserGroupRepository;
            this._unitWork = unitWork;
        }
        public ApplicationGroup Add(ApplicationGroup applicationGroup)
        {
            if (_appGroupRepository.CheckContains(x => x.Name == applicationGroup.Name))
                throw new NameDuplicatedException("Tên không được trùng");
            return _appGroupRepository.Add(applicationGroup);
        }

        public bool AddUserToGroups(IEnumerable<ApplicationUserGroup> groups, string userId)
        {
            _appUserGroupRepository.DeleteMulti(x => x.UserId == userId);
            foreach (var usergroup in groups)
            {
                _appUserGroupRepository.Add(usergroup);
            }
            return true;
        }

        public ApplicationGroup DeleteById(int id)
        {
            return _appGroupRepository.DeleteByID(id);
        }

        public IEnumerable<ApplicationGroup> GetAll(int page, int pagesize, out int totalRow, string filter)
        {
            var query = _appGroupRepository.GetAll();
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter));
            totalRow = query.Count();
            return query.OrderBy(x => x.Name).Skip((page - 1) * pagesize).Take(pagesize);
        }

        public IEnumerable<ApplicationGroup> GetAll()
        {
            return _appGroupRepository.GetAll();
        }

        public ApplicationGroup GetDetaill(int id)
        {
            return _appGroupRepository.GetSingleById(id);
        }

        public IEnumerable<ApplicationGroup> GetListGroupByUserId(string userId)
        {
           return  _appGroupRepository.GetListGroupByUserId(userId);
        }

        public IEnumerable<ApplicationUser> GetListUserByGroupId(int groupId)
        {
            return _appGroupRepository.GetListUserByGroupId(groupId);
        }

        public void Save()
        {
            _unitWork.Commit();
        }

        public void Update(ApplicationGroup applicationGroup)
        {
            if (_appGroupRepository.CheckContains(x => x.Name == applicationGroup.Name && x.ID != applicationGroup.ID))
                throw new NameDuplicatedException("Tên không được trùng");
            _appGroupRepository.Update(applicationGroup);
        }
    }
}
