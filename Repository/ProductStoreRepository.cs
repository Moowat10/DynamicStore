using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Repository
{
    public class ProductStoreRepository : IProductStoreRepository
    {
        private readonly DataContext _context;

        public ProductStoreRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductStore>> GetProductStoresAsync()
        {
            return await _context.ProductStores.ToListAsync();
        }

        public async Task<IEnumerable<ProductStore>> GetProductStoresByProductIdAsync(int productId)
        {
            return await _context.ProductStores.Where(ps => ps.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<ProductStore>> GetProductStoresByStoreIdAsync(int storeId)
        {
            return await _context.ProductStores.Where(ps => ps.StoreId == storeId).ToListAsync();
        }

        public async Task<ProductStore> GetProductStoreByIdAsync(int id)
        {
            return await _context.ProductStores.FindAsync(id);
        }

        public async Task<ProductStore> AddProductStoreAsync(ProductStore productStore)
        {
            _context.ProductStores.Add(productStore);
            await _context.SaveChangesAsync();
            return productStore;
        }

        public async Task<ProductStore> UpdateProductStoreAsync(int id, ProductStore productStore)
        {
            var existingProductStore = await _context.ProductStores.FindAsync(id);

            if (existingProductStore != null)
            {
                existingProductStore.ProductId = productStore.ProductId;
                existingProductStore.StoreId = productStore.StoreId;
                await _context.SaveChangesAsync();
            }

            return existingProductStore;
        }

        public async Task<bool> DeleteProductStoreAsync(int id)
        {
            var existingProductStore = await _context.ProductStores.FindAsync(id);

            if (existingProductStore != null)
            {
                _context.ProductStores.Remove(existingProductStore);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
