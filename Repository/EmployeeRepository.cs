using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Repository;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(DataContext context) : base(context)
        {
           
        }

      
    }

}
