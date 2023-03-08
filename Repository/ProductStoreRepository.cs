using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Repository
{
    public class ProductStoreRepository :  Repository<ProductStore>, IProductStoreRepository
    {
    
        public ProductStoreRepository(DataContext context): base(context) {}
        
        public async Task<IEnumerable<ProductStore>> GetProductStoresByProductIdAsync(int productId)
        {
            return await _context.ProductStores.Where(ps => ps.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<ProductStore>> GetProductStoresByStoreIdAsync(int storeId)
        {
            return await _context.ProductStores.Where(ps => ps.StoreId == storeId).ToListAsync();
        }

    }
}
