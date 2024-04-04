
namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Interfaces;
using Domain.Models;

[Controller]
[Route("[controller]")]
public class CustomerController(ICustomerService customerService)
{
    [HttpGet("Gets-Customers")]
    public async Task<List<Customers>> GetCustomers()
    {
        return await customerService.GetCustomers();
    }

    [HttpPost("Add-Customers")]

    public async Task AddCustomer(Customers customer)
    {
        await customerService.AddCustomer(customer);
    }


    [HttpDelete("Delete-Customer")]

    public async Task DeleteCustomer(int customerId)
    {
        await customerService.DeleteCustomer(customerId);
    }

    [HttpPut("Update-Customer")]

    public async Task UpdateCustomer(Customers customer)
    {
        await customerService.UpdateCustomer(customer);
    }




}
