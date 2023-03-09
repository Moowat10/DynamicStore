using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context): base(context)
        {
            
        }
      
    }
}
