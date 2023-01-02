using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Mango.Services.ProductAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

    }
}
