
using DynamicStore.Data;
using DynamicStoreBackend.Models;


namespace DynamicStoreBackend.Repositories
{
    public class RevenueRepository : IRevenueRepository
    {
        private readonly DataContext _context;

        public RevenueRepository(DataContext context)
        {
            _context = context;
        }

        public Revenue GetById(int id)
        {
            return _context.Revenues.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Revenue> GetAll()
        {
            return _context.Revenues.ToList();
        }
         public IEnumerable<Revenue> GetRevenuesForProduct(int productId, DateTime startDate, DateTime endDate)
    {
        return _context.Revenues
            .Where(r => r.Id == productId && r.Date >= startDate && r.Date <= endDate)
            .ToList();
    }

        public void Add(Revenue revenue)
        {
            _context.Revenues.Add(revenue);
            _context.SaveChanges();
        }

        public void Update(Revenue revenue)
        {
            _context.Revenues.Update(revenue);
            _context.SaveChanges();
        }

        public void Delete(Revenue revenue)
        {
            _context.Revenues.Remove(revenue);
            _context.SaveChanges();
        }
    }
}
