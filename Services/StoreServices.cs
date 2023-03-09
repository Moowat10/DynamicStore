using DynamicStore.DTO;
using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.Repository;

namespace DynamicStore.Services
{
    public class StoreServices : IStoreServices
    {
        private readonly StoreRepository _storeRepository;

        public StoreServices(StoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<IEnumerable<NewStoreDTO>> GetStoresAsync()
        {
            var stores = await _storeRepository.GetAllAsync();
            var StoreDTOs = stores.Select(store => new NewStoreDTO
            {
                StoreId = store.StoreId,
                StoreName = store.StoreName,
                StoreAddress = store.StoreAddress,
                StoreEmail = store.StoreEmail,
                StorePhone = store.StorePhone
            }).ToList();

            return StoreDTOs;
        }

        public async Task<NewStoreDTO> GetStoreByIdAsync(int storeId)
        {
            var store = await _storeRepository.GetByIdAsync(storeId);
            if (store == null)
            {
                return null;
            }

            var StoreDTO = new NewStoreDTO
            {
                StoreId = store.StoreId,
                StoreName = store.StoreName,
                StoreAddress = store.StoreAddress,
                StoreEmail = store.StoreEmail,
                StorePhone = store.StorePhone
            };

            return StoreDTO;
        }

        public async Task<NewStoreDTO> AddStoreAsync(NewStoreDTO StoreDTO)
        {
            var store = new Store
            {
                StoreName = StoreDTO.StoreName,
                StoreAddress = StoreDTO.StoreAddress,
                StoreEmail = StoreDTO.StoreEmail,
                StorePhone = StoreDTO.StorePhone
            };

            var newStore = await _storeRepository.AddAsync(store);

            var newStoreDTO = new NewStoreDTO
            {
                StoreId = newStore.StoreId,
                StoreName = newStore.StoreName,
                StoreAddress = newStore.StoreAddress,
                StoreEmail = newStore.StoreEmail,
                StorePhone = newStore.StorePhone
            };

            return newStoreDTO;
        }

        public async Task<NewStoreDTO> UpdateStoreAsync(int storeId, UpdateStoreDTO store)
        {
            var existingStore = await _storeRepository.GetByIdAsync(storeId);

            if (existingStore == null)
            {
                return null;
            }

            if (store.StoreName != null)
            {
                existingStore.StoreName = store.StoreName;
            }

            if (store.StoreAddress != null)
            {
                existingStore.StoreAddress = store.StoreAddress;
            }

            // Check if the nullable fields are not null, and update them accordingly
            if (store.StoreDescription != null)
            {
                existingStore.StoreDescription = store.StoreDescription;
            }

            var updatedStore = await _storeRepository.UpdateAsync(storeId, existingStore);

            var updatedStoreDTO = new NewStoreDTO
            {
                StoreId = updatedStore.StoreId,
                StoreName = updatedStore.StoreName,
                StoreAddress = updatedStore.StoreAddress,
                StoreEmail = updatedStore.StoreEmail,
                StorePhone = updatedStore.StorePhone
            };

            return updatedStoreDTO;
        }

        public async Task<bool> DeleteStoreAsync(int storeId)
        {
            var result = await _storeRepository.DeleteAsync(storeId);
            return result;
        }
    }
}
