using Assignment1.Context;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ITIContext context;

        public ProductRepository(ITIContext _context)
        {
            context = _context;
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
           return context.Products.FirstOrDefault(p => p.Id == id);

            // I will handle the NULL in the controller
        }

        public void Add(Product product)
        {
            context.Add(product);
        }

        public void Edit(Product editedProduct)
        {
            //context.Update(editedProduct);

            Product productFromDB = context.Products.FirstOrDefault(p => p.Id == editedProduct.Id);

            productFromDB.Name = editedProduct.Name;
            productFromDB.Description = editedProduct.Description;
            productFromDB.Price = editedProduct.Price;  
        }

        public void Remove(int id)
        {
            Product product = context.Products.FirstOrDefault(p => p.Id == id);
            // can't be null because I handeled the null in the controller before calling (Remove func)

            context.Remove(product);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
