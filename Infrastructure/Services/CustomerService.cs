using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CustomerService(DapperContext context):ICustomerService
{

    public async Task<List<Customers>> GetCustomers()
    {
        var sql = "select * from Customers";
        var result = await context.Connection().QueryAsync<Customers>(sql);
        return result.ToList();
    }


    public async Task AddCustomer(Customers customer)
    {
        var sql = @"insert into Customers (FirstName,LastName,Email,PhoneNumber)
                   values (@FirstName,@LastName,@Email,@PhoneNumber)";
        await context.Connection().ExecuteAsync(sql, customer);
    }

    public async Task UpdateCustomer(Customers customer)
    {
        var sql = @"update Customers set
                      FirstName=@FirstName,LastName=@LastName,Email=@Email,PhoneNumber=@PhoneNumber
                         where CustomerId=@CustomerId";

        await context.Connection().ExecuteAsync(sql, customer);
    }

    public async Task DeleteCustomer(int customerId)
    {
        var sql = "delete from Customers where CustomerId=@customerId";

        await context.Connection().ExecuteAsync(sql, new { CustomerId = customerId });
    }
}

