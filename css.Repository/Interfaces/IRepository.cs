﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace css.Repository.Interfaces
{
    // Interface
    public interface IRepository<TEntity> where TEntity : class
    {
        // Get
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();


        // Find
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);


        // Add
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);


        // Remove
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
