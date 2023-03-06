using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicStore.DTO;

namespace DynamicStore.Services
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
