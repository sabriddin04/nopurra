using Domain.Models;

namespace Infrastructure.Interfaces;

public interface ICustomerService
{
    Task<List<Customers>> GetCustomers();

    Task AddCustomer(Customers customer);

    Task UpdateCustomer(Customers customer);

    Task DeleteCustomer(int customerId);

}
