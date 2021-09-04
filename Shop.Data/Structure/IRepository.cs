using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shop.Data.Structure
{
    public interface IRepository <T> where T: class
    {
        // thêm mới 
        void Add(T entity);

        //cập nhật 
        void Update(T entity);

        // xóa bản ghi
        void Delete(T entity);

        void DeleteMulti(Expression<Func<T, bool>> where);

        //Tìm theo id
        T GetSingleById(int id);

        // Tìm theo điều kiện
        T GetSingleByCondition(Expression<Func<T, bool>>expression, string[]includes=null);

        IQueryable<T> GetAll(string[] includes=null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
