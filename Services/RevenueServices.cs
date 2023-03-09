using DynamicStore.Models;
using DynamicStore.Repository;
using DynamicStore.Interface;
using DynamicStore.DTO;

namespace DynamicStore.Services
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

        public async Task<Revenue> UpdateRevenueAsync(int revenueId, RevenueDTO revenue)
        {
            var existingRevenue = await _revenueRepository.GetByIdAsync(revenueId);

            if (existingRevenue == null)
            {
                return null;
            }

            if (revenue.Amount != null)
            {
                existingRevenue.Amount = revenue.Amount;
            }

            if (revenue.Description != null)
            {
                existingRevenue.Description = revenue.Description;
            }

              if (revenue.Type != null)
            {
                existingRevenue.Type = (DynamicStore.Models.RevenueType)revenue.Type;
            }

            var updatedRevenue = await _revenueRepository.UpdateAsync(revenueId, existingRevenue);

            return updatedRevenue;
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
