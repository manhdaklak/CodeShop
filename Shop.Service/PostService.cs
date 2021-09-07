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
    public interface IPostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int page, int pagesize, out int total);
        Post GetById(int id);
        IEnumerable<Post> GetALlTagPaging(int page, int pagesize, out int total);
        void SaveChanges();
    }
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitWork _unitWork;
        public PostService(IPostRepository postRepository, IUnitWork unitWork)
        {
            this._postRepository = postRepository;
            this._unitWork = unitWork;
        }
        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.DeleteByID(id);
        }

        /// <summary>
        /// khi truy vấn sẽ cho ra Post và PostCategory
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllPaging(int page, int pagesize, out int total)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetALlTagPaging(int page, int pagesize, out int total)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out total, page, pagesize);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
