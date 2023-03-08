using DynamicStore.Models;
using DynamicStoreBackend.Models;
using DynamicStoreBackend.Repositories;
using System.Collections.Generic;

namespace DynamicStoreBackend.Services
{
    public class RevenueServices : IRevenueServices
    {
        private readonly RevenueRepository _revenueRepository;

        public RevenueServices(RevenueRepository revenueRepository)
        {
            _revenueRepository = revenueRepository;
        }

        public async Task<Revenue> GetRevenueByIdAsync(int revenueId)
        {
            return await _revenueRepository.GetByIdAsync(revenueId);
        }

        public async Task<IEnumerable<Revenue>> GetAllRevenueAsync()
        {
            return await _revenueRepository.GetAllAsync();
        }

        public async Task<Revenue> AddRevenueAsync(Revenue revenue)
        {
            return await _revenueRepository.AddAsync(revenue);
        }

        public async Task<Revenue> UpdateRevenueAsync(int revenueId, Revenue revenue)
        {
           return await _revenueRepository.UpdateAsync(revenueId, revenue);
        }

        public async Task<bool> DeleteRevenueAsync(int revenueId)
        {
           return await _revenueRepository.DeleteAsync(revenueId);
        }

        public async Task<IEnumerable<Revenue>> GetRevenuesForProduct(int productId, DateTime startDate, DateTime endDate)
        {
            return await _revenueRepository.GetRevenuesForProduct(productId, startDate, endDate);
        }
    }
}
