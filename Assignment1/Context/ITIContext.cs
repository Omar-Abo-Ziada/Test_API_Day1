using Assignment1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Context
{
    public class ITIContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ITIContext(DbContextOptions options) : base(options) 
        {
            
        }
    }
}
