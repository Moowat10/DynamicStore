using DynamicStore.Data;
using DynamicStoreBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class FinanceModuleRepository : IFinanceModuleRepository
{
    private readonly DataContext _dbContext;

    public FinanceModuleRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Revenue> GetRevenues(DateTime startDate, DateTime endDate)
    {
        return _dbContext.Revenues.Where(r => r.Date >= startDate && r.Date <= endDate);
    }

    public IEnumerable<Tax> GetTaxes(DateTime startDate, DateTime endDate)
    {
        return _dbContext.Taxes.Where(t => t.Date >= startDate && t.Date <= endDate);
    }

    public IEnumerable<Payroll> GetPayrolls(DateTime startDate, DateTime endDate)
    {
        return _dbContext.Payrolls.Where(p => p.Date >= startDate && p.Date <= endDate);
    }

    public IEnumerable<Expense> GetExpenses(DateTime startDate, DateTime endDate)
    {
        return _dbContext.Expenses.Where(e => e.Date >= startDate && e.Date <= endDate);
    }

    /**public IEnumerable<Revenue> GetRevenuesForProduct(int productId, DateTime startDate, DateTime endDate)
    {
        return _dbContext.Orders
            .Where(o => o.OrderItems.Any(oi => oi.ProductId == productId))
            .SelectMany(o => o.Revenues)
            .Where(r => r.Date >= startDate && r.Date <= endDate);
    }

    public IEnumerable<Tax> GetTaxesForProduct(int productId, DateTime startDate, DateTime endDate)
    {
        return _dbContext.Orders
            .Where(o => o.OrderItems.Any(oi => oi.ProductId == productId))
            .SelectMany(o => o.Taxes)
            .Where(t => t.Date >= startDate && t.Date <= endDate);
    }
    
    public IEnumerable<Expense> GetExpensesByCategory(string category, DateTime startDate, DateTime endDate)
    {
        return _dbContext.Expenses.Where(e => e.Category == category && e.Date >= startDate && e.Date <= endDate);
    }
    **/
    public IEnumerable<Payroll> GetPayrollsByEmployee(int employeeId, DateTime startDate, DateTime endDate)
    {
        return _dbContext.Payrolls.Where(p => p.EmployeeId == employeeId && p.Date >= startDate && p.Date <= endDate);
    }

   /** public IEnumerable<Revenue> GetRevenuesByCustomer(string customerEamil, DateTime startDate, DateTime endDate)
    {
        return _dbContext.Orders
            .Where(o => o.CustomerEmail == customerEamil)
            .SelectMany(o => o.Revenues)
            .Where(r => r.Date >= startDate && r.Date <= endDate);
    }
   **/
    public decimal GetNetProfit(DateTime startDate, DateTime endDate)
    {
        var revenues = _dbContext.Revenues.Where(r => r.Date >= startDate && r.Date <= endDate).Sum(r => r.Amount);
        var expenses = _dbContext.Expenses.Where(e => e.Date >= startDate && e.Date <= endDate).Sum(e => e.Amount);
        var taxes = _dbContext.Taxes.Where(t => t.Date >= startDate && t.Date <= endDate).Sum(t => t.Amount);

        return revenues - expenses - taxes;
    }
}
