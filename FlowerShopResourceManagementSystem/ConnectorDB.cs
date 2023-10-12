using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace FlowerShopResourceManagementSystem
{
  /// <summary>
  /// Класс для получение и записованием данных в БД.
  /// </summary>
  internal static class ConnectorDB
  {
    #region Методы
    /// <summary>
    /// Получить все товары.
    /// </summary>
    /// <returns>Список товаров</returns>
    public static List<Product> GetProducts()
    {
      using (ApplicationContext db = new ApplicationContext())
      {
        return db.Products.ToList();
      }
    }

    /// <summary>
    /// Добавить товар.
    /// </summary>
    /// <param name="product">Товар, который нужно добавить.</param>
    public static void Add(Product product)
    {
      using (ApplicationContext db = new ApplicationContext())
      {
        db.Products.Add(product);
        db.SaveChanges();
      }
    }

    /// <summary>
    /// Обновить данные товара.
    /// </summary>
    /// <param name="product">Товар, который нужно обновить.</param>
    public static void Update(Product product)
    {
      using (ApplicationContext db = new ApplicationContext())
      {
        db.Products.Update(product);
        db.SaveChanges();
      }
    }

    /// <summary>
    /// Удалить товар.
    /// </summary>
    /// <param name="product">Товар, который нужно удалить.</param>
    public static void Delete(Product product)
    {
      using (ApplicationContext db = new ApplicationContext())
      {
        db.Products.Remove(product);
        db.SaveChanges();
      }
    }
    #endregion
  }
}
