using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Контекст базы данных приложения.
  /// </summary>
  public class ApplicationContext : DbContext
  {
    /// <summary>
    /// Редактирование данных Product.
    /// </summary>
    public DbSet<Product> Products => Set<Product>();

    /// <summary>
    /// Настроить подключение.
    /// </summary>
    /// <param name="optionsBuilder">Параметры подключения.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=FlowerShop.db");
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public ApplicationContext() => Database.EnsureCreated();
  }
}
