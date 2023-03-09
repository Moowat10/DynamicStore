using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;

namespace DynamicStore.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

      }
}
