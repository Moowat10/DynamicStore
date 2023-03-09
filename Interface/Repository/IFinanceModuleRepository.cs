using DynamicStore.Models;


namespace DynamicStore.Interface
{
public interface IFinanceModuleRepository
{
    // Retrieve all revenues within a given date range
    IEnumerable<Revenue> GetRevenues(DateTime startDate, DateTime endDate);

    // Retrieve all taxes within a given date range
    IEnumerable<Tax> GetTaxes(DateTime startDate, DateTime endDate);

    // Retrieve all payrolls within a given date range
    IEnumerable<Payroll> GetPayrolls(DateTime startDate, DateTime endDate);

    // Retrieve all expenses within a given date range
    IEnumerable<Expense> GetExpenses(DateTime startDate, DateTime endDate);

    //Retrieve all revenues for a specific product
   // IEnumerable<Revenue> GetRevenuesForProduct(int productId, DateTime startDate, DateTime endDate);

    //Retrieve all taxes for a specific product
  //  IEnumerable<Tax> GetTaxesForProduct(int productId, DateTime startDate, DateTime endDate);


    //Retrieve all expenses for a specific category
  //  IEnumerable<Expense> GetExpensesByCategory(string category, DateTime startDate, DateTime endDate);

    //Retrieve all payrolls for a specific employee
    IEnumerable<Payroll> GetPayrollsByEmployee(int employeeId, DateTime startDate, DateTime endDate);

    //Retrieve all revenues for a specific customer

   // IEnumerable<Revenue> GetRevenuesByCustomer(int customerId, DateTime startDate, DateTime endDate);

    //Calculate net profit for a given date range
    public decimal GetNetProfit(DateTime startDate, DateTime endDate);


}
}