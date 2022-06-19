using NewsPortal.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.DataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        GetManyResult<TEntity> GetAll();
        GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
        GetOneResult<TEntity> GetById(int id);
        GetOneResult<TEntity> InsertOne(TEntity entity);
        //GetManyResult<TEntity> InsertMany(ICollection<TEntity> entities);
        //Task<GetManyResult<TEntity>> InsertManyAsync(ICollection<TEntity> entities);
        GetOneResult<TEntity> UpdateOne(TEntity entity);
        GetOneResult<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter);
        bool DeleteById(int id);
        bool SaveChanges();


    }
}
