
using DynamicStore.DTO;

namespace DynamicStore.Interface
{
    public interface IStoreServices
    {
        Task<IEnumerable<NewStoreDTO>> GetStoresAsync();
        Task<NewStoreDTO> GetStoreByIdAsync(int storeId);
        Task<NewStoreDTO> AddStoreAsync(NewStoreDTO storeDTO);
        Task<NewStoreDTO> UpdateStoreAsync(int storeId, UpdateStoreDTO storeDTO);
        Task<bool> DeleteStoreAsync(int storeId);
    }
}
