using NewsPortal.DataAccess.Abstract;
using NewsPortal.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.DataAccess.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly DataContext _dbContext;

        public RepositoryBase(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool DeleteById(int id)
        {
            try
            {
                var entity = _dbContext.Set<TEntity>().Find(id);
                if (entity == null)
                    return false;
                
                _dbContext.Set<TEntity>().Remove(entity);
                return SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public GetOneResult<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var entity = _dbContext.Set<TEntity>().FirstOrDefault(filter);
                if (entity == null)
                {
                    result.Message = "Not found";
                    return result;
                }

                _dbContext.Set<TEntity>().Remove(entity);
                result.Success = SaveChanges();
            }

            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }

        public GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var entities = _dbContext.Set<TEntity>().Where(filter);
                result.Result = entities;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
                result.Result = null;
            }
            return result;
        }

        public GetManyResult<TEntity> GetAll()
        {
            var result = new GetManyResult<TEntity>();

            try
            {
                var data = _dbContext.Set<TEntity>();
                if (data.Count() > 0)
                    result.Result = data;
                else
                {
                    result.Success = false;
                    result.Message = "No data found";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
                result.Result = null;
            }

            return result;
        }

        public GetOneResult<TEntity> GetById(int id)
        {

            var result = new GetOneResult<TEntity>();
            try
            {

                var data = _dbContext.Set<TEntity>().Find(id);
                if (data != null)
                    result.Entity = data;
                else
                {
                    result.Success = false;
                    result.Message = "No data found";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
                result.Entity = null;
            }

            return result;
        }

        public GetOneResult<TEntity> InsertOne(TEntity entity)
        {

            var result = new GetOneResult<TEntity>();

            try
            {

                _dbContext.Set<TEntity>().Add(entity);
                result.Success = SaveChanges();
                result.Entity = entity;

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
                result.Entity = null;
            }

            return result;
        }

        public bool SaveChanges() => _dbContext.SaveChanges() > 0;

        public GetOneResult<TEntity> UpdateOne(TEntity entity)
        {

            var result = new GetOneResult<TEntity>();
            try
            {
                _dbContext.Set<TEntity>().Update(entity);
                result.Success = SaveChanges();
                result.Entity = entity;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
                result.Entity = null;
            }

            return result;
        }
    }
}
