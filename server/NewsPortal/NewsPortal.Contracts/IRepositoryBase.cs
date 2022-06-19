using System.Linq.Expressions;

namespace NewsPortal.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        void Save();
        
    }
}
