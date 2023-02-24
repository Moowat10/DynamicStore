using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetStoresAsync();
        Task<Store> GetStoreByIdAsync(int storeId);
        Task<Store> AddStoreAsync(Store store);
        Task<Store> UpdateStoreAsync(int storeId, Store store);
        Task<bool> DeleteStoreAsync(int storeId);
    }
}
