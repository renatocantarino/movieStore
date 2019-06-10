﻿using Domain.Interfaces;
using Domain.Models;
using Dommel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly string ConnectionString;

        protected RepositoryBase()
        {
            ConnectionString = @"Server = STFBSBC028976-W\SQLEXPRESS; Database = Movies; User Id = dba; Password = s3nh4___; Integrated Security = false; MultipleActiveResultSets = True";
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetAll<TEntity>();
            }
        }

        public virtual TEntity GetById(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Get<TEntity>(id);
            }
        }

        public virtual void Insert(ref TEntity entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var obj = db.Insert(entity);
            }
        }

        public virtual bool Update(TEntity entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Update(entity);
            }
        }

        public virtual bool Delete(Int32 id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var entity = GetById(id);

                if (entity == null) throw new Exception("Registro não encontrado");

                return db.Delete(entity);
            }
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Select(predicate);
            }
        }
    }
}