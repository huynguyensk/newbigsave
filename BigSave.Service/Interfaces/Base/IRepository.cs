using System;
using System.Collections.Generic;
using BigSave.Core.Entities.Base;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace BigSave.Service.Interfaces.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        List<T> GetAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(int id);
        bool IsExist(Expression<Func<T, bool>> where);
        int Count(Expression<Func<T, bool>> where);
        bool Any(Expression<Func<T, bool>> where);
        List<T> GetByCondition(Expression<Func<T, bool>> condition);
    }
}