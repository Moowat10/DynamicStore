using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext _context;

        public StoreRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Store> GetStoreByIdAsync(int storeId)
        {
            return await _context.Stores.FindAsync(storeId);
        }

        public async Task<Store> AddStoreAsync(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task<Store> UpdateStoreAsync(int storeId, Store store)
        {
            var existingStore = await _context.Stores.FindAsync(storeId);

            if (existingStore != null)
            {
                existingStore.StoreName = store.StoreName;
                existingStore.StoreDescription = store.StoreDescription;
                existingStore.StorePhone = store.StorePhone;
                existingStore.StoreEmail = store.StoreEmail;
                existingStore.StoreAddress = store.StoreAddress;
                await _context.SaveChangesAsync();
            }

            return existingStore;
        }

        public async Task<bool> DeleteStoreAsync(int storeId)
        {
            var existingStore = await _context.Stores.FindAsync(storeId);

            if (existingStore != null)
            {
                _context.Stores.Remove(existingStore);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

