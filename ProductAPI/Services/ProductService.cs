using System;
using System.Collections.Generic;
using System.Linq;
using ProductAPI.Models;
using ProductAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Services
{
    public class ProductService : IProductRepository
    {
        private readonly ProductContext _productContext;
        public ProductService(ProductContext ProductContext)
        {
            _productContext = ProductContext;
        }

        public IEnumerable<Product> Products
        {
            get
            {
                return _productContext.Set<Product>().ToList();
            }
        }

        public async Task<Product> Create(Product newProduct)
        {
            _productContext.Set<Product>().Add(newProduct);
            await _productContext.SaveChangesAsync();
            return newProduct;
        }

        public async Task<Product> Delete(Guid productID)
        {
            var entity = await _productContext.Set<Product>().FindAsync(productID);
            if (entity == null)
            {
                return entity;
            }
            
            entity.Active = false; 
            _productContext.Entry(entity).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Product> Read(Guid productID)
        {
            return await _productContext.Set<Product>().FindAsync(productID);
        }

        public async Task<Product> Update(Guid productID, Product updateProduct)
        {
            var entity = await _productContext.Set<Product>().FindAsync(productID);
            if (entity == null)
            {
                return entity;
            }

            _productContext.Entry(entity).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();
            return entity;
        }

    }
}