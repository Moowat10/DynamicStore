
using DynamicStore.Data;
using DynamicStoreBackend.Models;
using DynamicStore.Repository;
using Microsoft.EntityFrameworkCore;

namespace DynamicStoreBackend.Repositories
{
    public class RevenueRepository : Repository<Revenue> , IRevenueRepository
    {

        public RevenueRepository(DataContext context) : base(context) {}
       

        public async Task<IEnumerable<Revenue>> GetRevenuesForProduct(int productId, DateTime startDate, DateTime endDate)
        {
                return await this._context.Revenues
                .Where(r => r.Id == productId && r.Date >= startDate && r.Date <= endDate)
                .ToListAsync(); // Add ToListAsync() to execute the query and get the results as a list
        }


 
    }
}
