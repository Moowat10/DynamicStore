using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;

namespace DynamicStore.Repository
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository(DataContext context) : base(context) { }
        
    }
}

