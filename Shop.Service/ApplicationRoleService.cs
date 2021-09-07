using Shop.Common;
using Shop.Data.Repositories;
using Shop.Data.Structure;
using Shop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Service
{
    public interface IApplicationRoleService
    {
        ApplicationRole Add(ApplicationRole appRole);
        void Update(ApplicationRole appRole);
        void DeletebyID(string id);
        ApplicationRole GetDetail(string id);
        IEnumerable<ApplicationRole> GetAll();
        IEnumerable<ApplicationRole> GetAll(int page, int pagesize, out int totalRow, string filter);
        void Save();

        //
        IEnumerable<ApplicationRole> GetListRoleGroupById(int groupId);

        bool AddRolesToGroup(IEnumerable<ApplicationRoleGroup> roleGroups, int groupId);
    }

    public class ApplicationRoleService : IApplicationRoleService
    {
        private IApplicationRoleRepository _appRoleRepository;
        private IApplicationRoleGroupRepository _appRoleGroupRepository;
        private IUnitWork _unitWork;

        public ApplicationRoleService(IApplicationRoleRepository appRoleRepository,
            IApplicationRoleGroupRepository appRoleGroupRepository, IUnitWork unitWork)
        {
            this._appRoleRepository = appRoleRepository;
            this._appRoleGroupRepository = appRoleGroupRepository;
            this._unitWork = unitWork;
        }
        public ApplicationRole Add(ApplicationRole appRole)
        {
            if (_appRoleRepository.CheckContains(x => x.Description == appRole.Description))
                throw new NameDuplicatedException("Tên không được trùng");
            return _appRoleRepository.Add(appRole);
        }

        public bool AddRolesToGroup(IEnumerable<ApplicationRoleGroup> roleGroups, int groupId)
        {
            _appRoleGroupRepository.DeleteMulti(x => x.GroupId == groupId);
            foreach (var roleGroup in roleGroups)
            {
                _appRoleGroupRepository.Add(roleGroup);
            }
            return true;
        }

        public void DeletebyID(string id)
        {
            _appRoleRepository.DeleteMulti(x => x.Id==id);
        }

        public IEnumerable<ApplicationRole> GetAll()
        {
            return _appRoleRepository.GetAll();
        }
        public IEnumerable<ApplicationRole> GetAll(int page, int pagesize, out int totalRow, string filter)
        {
            var query = _appRoleRepository.GetAll();
            if(!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Description.Contains(filter));
            totalRow = query.Count();
            return query.OrderBy(x => x.Description).Skip((page - 1) * pagesize).Take(pagesize);
        }

        public ApplicationRole GetDetail(string id)
        {
            return _appRoleRepository.GetSingleByCondition(x => x.Id == id);
        }

        public IEnumerable<ApplicationRole> GetListRoleGroupById(int groupId)
        {
            return _appRoleRepository.GetListRoleByGroupId(groupId);
        }

        public void Save()
        {
            _unitWork.Commit();
        }

        public void Update(ApplicationRole appRole)
        {
            if (_appRoleRepository.CheckContains(x => x.Description == appRole.Description))
                throw new NameDuplicatedException("Tên không được trùng");
            _appRoleRepository.Update(appRole);
        }
    }
}