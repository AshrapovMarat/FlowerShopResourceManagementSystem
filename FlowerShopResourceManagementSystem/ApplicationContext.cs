using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FlowerShopResourceManagementSystem
{
  public class ApplicationContext : DbContext
  {
    public DbSet<Product> Products => Set<Product>();
    public ApplicationContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=FlowerShop.db");
    }
  }
}
