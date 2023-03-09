using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;

namespace DynamicStore.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(DataContext context) : base(context)
        {
           
        }

      
    }

}
