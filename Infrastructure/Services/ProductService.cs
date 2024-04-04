using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ProductService(DapperContext context) : IProductService
{

    public async Task<List<Products>> GetProducts()
    {
        var sql = "select * from Products";
        var result = await context.Connection().QueryAsync<Products>(sql);
        return result.ToList();
    }


    public async Task AddProduct(Products product)
    {
        var sql = @"insert into Products (Name,Description,Price,StockQuantity)
                   values (@Name,@Description,@Price,@StockQuantity)";
        await context.Connection().ExecuteAsync(sql, product);
    }

    public async Task UpdateProduct(Products product)
    {
        var sql = @"update Products set
                      Name=@Name,Description=@Description,Price=@Price,StockQuantity=@StockQuantity
                         where ProductId=@ProductId";

        await context.Connection().ExecuteAsync(sql, product);
    }

    public async Task DeleteProduct(int productId)
    {
        var sql = "delete from Products where ProductId=@productId";

        await context.Connection().ExecuteAsync(sql, new { ProductId = productId });
    }

    public async Task SumStockQuantityOfProduct(int quantity, int productId)
    {
        var sql1 = "select Products.StockQuantity where ProductId=@productId";

        var stockQuantity = await context.Connection().ExecuteScalarAsync<int>(sql1, new { ProductId = productId });

        quantity += stockQuantity;

        var sql2 = @"update Products set StockQuantity=@quantity";

        await context.Connection().ExecuteScalarAsync(sql2, new { StockQuantity = quantity });

    }
}
