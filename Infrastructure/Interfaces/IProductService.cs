using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Task<List<Products>> GetProducts();
    Task AddProduct(Products product);
    Task UpdateProduct(Products product);
    Task DeleteProduct(int productId);
    Task SumStockQuantityOfProduct(int quantity, int productId);

}
