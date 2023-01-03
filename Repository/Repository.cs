﻿using SchoolManagementAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace SchoolManagementAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}