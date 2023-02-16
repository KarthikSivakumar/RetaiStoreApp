using System.Collections.Generic;
using ProductAPI.Models;
namespace ProductAPI.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        Task<Product> Read(Guid productID);
        Task<Product> Create(Product t);
        Task<Product> Delete(Guid productID);
        Task<Product> Update(Guid productID, Product newAll);
    } 
}