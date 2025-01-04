using css.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace css.Repository.Repositories
{
    // Class
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _DbContext;
        private DbSet<TEntity> _entities;


        public Repository(DbContext context)
        {
            _DbContext = context;
            _entities = _DbContext.Set<TEntity>();
        }



        #region IRepository Implementation
        public TEntity Get(int id)
        {
            // Here we are working with a DbContext, NOT our application specific DbContext (MyApp_DbContext). So we don't have DbSets 
            // such as Courses or Authors, and we need to use the generic Set() method to access them.

            // return db.Set<TEntity>().Find(id); // Mosh
            return _entities.Find(id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            // Note that here I've repeated Context.Set<TEntity>() in every method and this is causing
            // too much noise. I could get a reference to the DbSet returned from this method in the 
            // constructor and store it in a private field like _entities. This way, the implementation
            // of our methods would be cleaner:
            // 
            // _entities.ToList();
            // _entities.Where();
            // _entities.SingleOrDefault();
            // 
            // I didn't change it because I wanted the code to look like the videos. But feel free to change
            // this on your own.

            //return db.Set<TEntity>().ToList(); // Mosh
            return _entities.ToList();
        }



        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            //return db.Set<TEntity>().Where(predicate); // Mosh
            return _entities.Where(predicate);
        }
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            //return db.Set<TEntity>().SingleOrDefault(predicate); // Mosh
            return _entities.SingleOrDefault(predicate);
        }



        public void Add(TEntity entity)
        {
            //db.Set<TEntity>().Add(entity); // Mosh
            _entities.Add(entity);
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            //db.Set<TEntity>().AddRange(entities); // Mosh
            _entities.AddRange(entities);
        }



        public void Remove(TEntity entity)
        {
            //db.Set<TEntity>().Remove(entity); // Mosh
            _entities.Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            //db.Set<TEntity>().RemoveRange(entities); // Mosh
            _entities.RemoveRange(entities);
        }
        #endregion
    }
    
}
