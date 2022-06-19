//using Microsoft.EntityFrameworkCore;
//using NewsPortal.Contracts;
//using NewsPortal.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace NewsPortal.Repository
//{
//    public abstract class RepositoryBase<T> : IRepository<T> where T : class
//    {
//        protected readonly RepositoryContext RepositoryContext;

//        public RepositoryBase(RepositoryContext repositoryContext)
//        {
//            this.RepositoryContext = repositoryContext;
//        }

//        public void Create(T entity)
//        {
//            this.RepositoryContext.Set<T>().Add(entity);
            
//        }

//        public void Delete(T entity)
//        {
//            this.RepositoryContext.Set<T>().Remove(entity);
//        }

//        public IQueryable<T> FindAll()
//        {
//            return this.RepositoryContext.Set<T>().AsNoTracking();
//        }

//        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
//        {
//            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
//        }

//        public void Save()
//        {
//            this.RepositoryContext.SaveChanges();
//        }

//        public void Update(T entity)
//        {
//            this.RepositoryContext.Set<T>().Update(entity);
//        }
//    }
    
//}
