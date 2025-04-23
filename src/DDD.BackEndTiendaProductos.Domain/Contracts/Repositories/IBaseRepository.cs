﻿using DDD.BackEndTiendaProductos.Domain.Models;

namespace DDD.BackEndTiendaProductos.Domain.Contracts.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity, int id);
        Task DeleteAsync(T entity);
    }
}
