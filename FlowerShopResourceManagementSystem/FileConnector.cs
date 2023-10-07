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
  /// Класс для получение и записованием данных в файл.
  /// </summary>
  internal static class FileConnector
  {
    public static List<Product> GetProducts()
    {
      using (ApplicationContext db = new ApplicationContext())
      {
        return db.Products.ToList();
      }
    }

    public static void Add(Product product)
    {
      using (ApplicationContext db = new ApplicationContext())
      {
        db.Products.Add(product);
        db.SaveChanges();
      }
    }

    public static void Update(Product product)
    {
      using (ApplicationContext db = new ApplicationContext())
      {
        db.Products.Update(product);
        db.SaveChanges();
      }
    }

    public static void Delete(Product product)
    {
      using (ApplicationContext db = new ApplicationContext())
      {
        db.Products.Remove(product);
        db.SaveChanges();
      }
    }
  }
}
