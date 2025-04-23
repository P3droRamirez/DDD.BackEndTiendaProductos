using Microsoft.EntityFrameworkCore;
using DDD.BackEndTiendaProductos.Domain.Entities;
using DDD.BackEndTiendaProductos.Infrastructure.Data;
using DDD.BackEndTiendaProductos.Domain.Contracts.Repositories;

namespace DDD.BackEndTiendaProductos.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product entity)
        {
             _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => 
            await _context.Products.ToListAsync();

        public async Task<Product> GetByIdAsync(int id) =>

            await _context.Products.FindAsync(id);
        

        public Task<Product?> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Product entity, int id)
        {
           var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"El juego con el id {id} no existe");
            }
            product.Name = entity.Name;
            product.Price = entity.Price;
            product.Stock = entity.Stock;

            await _context.SaveChangesAsync();
            
        }
    }
}
