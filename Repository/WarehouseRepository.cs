using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Repository
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
         public WarehouseRepository(DataContext context): base(context)
        {
            
        }
    }
}
