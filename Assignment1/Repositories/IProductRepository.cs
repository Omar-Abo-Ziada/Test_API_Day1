using Assignment1.Models;

namespace Assignment1.Repositories
{
    public interface IProductRepository
    {
        public List<Product> GetAll();

        public Product GetById(int id);

        public void Add(Product product);

        public void Edit(Product editedProduct);

        public void Remove(int id);

        public void Save();
    }
}