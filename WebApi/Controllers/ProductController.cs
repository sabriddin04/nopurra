namespace WebApi.Controllers;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
[Controller]
[Route("[controller]")]
public class ProductController(IProductService productService)
{
   
    [HttpGet("Gets-Products")]
    public async Task<List<Products>> GetProducts()
    {
        return await productService.GetProducts();
    }

    [HttpPost("Add-Product")]

    public async Task AddProduct(Products product)
    {
        await productService.AddProduct(product);
    }


    [HttpDelete("Delete-Product")]

    public async Task DeleteProduct(int productId)
    {
        await productService.DeleteProduct(productId);
    }

    [HttpPut("Update-Product")]

    public async Task UpdateProduct(Products product)
    {
        await productService.UpdateProduct(product);
    }
    [HttpPut("Sum-StockQuantity-Of-Product")]
    public async Task SumStockQuantityOfProduct(int quantity, int productId)
    {
        await productService.SumStockQuantityOfProduct(quantity,productId);
    }
}
