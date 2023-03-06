using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicStore.Interface;
using DynamicStore.Models;

namespace DynamicStore.Services
{
    public class StoreStatisticsServices : IStoreStatisticsServices
    {
        private readonly StoreStatisticsRepository _repository;

        public StoreStatisticsServices(StoreStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StoreStatistics>> GetAllStoreStatisticsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<StoreStatistics> GetStoreStatisticsByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<StoreStatistics> CreateStoreStatisticsAsync(StoreStatistics storeStatistics)
        {
            return await _repository.AddAsync(storeStatistics);
        }

        public async Task<StoreStatistics> UpdateStoreStatisticsAsync(int ssId, StoreStatistics storeStatistics)
        {
            return await _repository.UpdateAsync(ssId, storeStatistics);
        }

        public async Task<bool> DeleteStoreStatisticsAsync(int ssId)
        {
            var result = await _repository.DeleteAsync(ssId);
            return result;
        }

        public async Task<int> GetTotalProductsAsync(int storeId)
        {
            return await _repository.GetTotalProductsAsync(storeId);
        }

        public async Task<int> GetTotalCategoriesAsync(int storeId)
        {
            return await _repository.GetTotalCategoriesAsync(storeId);
        }

        public async Task<decimal> GetTotalSalesAsync(int storeId)
        {
            return await _repository.GetTotalSalesAsync(storeId);
        }

        public async Task<int> GetTotalOrdersAsync(int storeId)
        {
            return await _repository.GetTotalOrdersAsync(storeId);
        }
    }
}
